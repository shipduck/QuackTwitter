using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuackTwitter
{
    public class Utils
    {
        private class Or_
        {
            public Or_(object l, object r)
            {
                L = l;
                R = r;
            }

            public override string ToString()
            {
                return string.Format("({0} | {1})", L, R);
            }

            public object L { get; private set; }
            public object R { get; private set; }
        }

        public static object Or(object l, object r)
        {
            return new Or_(l, r);
        }

        private class And_
        {
            public And_(object l, object r)
            {
                L = l;
                R = r;
            }

            public override string ToString()
            {
                return string.Format("({0} & {1})", L, R);
            }

            public object L { get; private set; }
            public object R { get; private set; }
        }

        public static object And(object l, object r)
        {
            return new And_(l, r);
        }

        public static void RequiredParameters(IDictionary<string, string> parameters, params object[] required)
        {
            foreach (object cond in required)
            {
                if (EvalCond(parameters, cond))
                {
                    throw new ArgumentException(string.Format("Required argument is missing ({0})", string.Join(" | ", required)), cond.ToString());
                }
            }
        }

        private static bool EvalCond(IDictionary<string, string> target, object cond)
        {
            if (cond is string)
            {
                string paramName = cond as string;
                if (!target.ContainsKey(paramName))
                {
                    return false;
                }
            }
            else if (cond is And_)
            {
                return EvalCond(target, (cond as And_).L) && EvalCond(target, (cond as And_).R);
            }
            else if (cond is Or_)
            {
                return EvalCond(target, (cond as Or_).L) && EvalCond(target, (cond as Or_).R);
            }

            return true;
        }

        public static void SetDefaultValue(IDictionary<string, string> parameters, string paramName, object defaultValue)
        {
            if (!parameters.ContainsKey(paramName))
            {
                parameters.Add(paramName, ToString(defaultValue));
            }
        }

        public static string ToString(object val)
        {
            if (val is bool)
            {
                if ((bool)val)
                {
                    return "true";
                }

                return "false";
            }
            if (val is string)
            {
                return val as string;
            }

            return val.ToString();
        }
    }
}
