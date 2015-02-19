using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuackTwitter
{
	partial class QuackTwitter
	{
		public enum Blocks
		{
			List,
			Ids,
			Create,
			Destroy
		};

		public dynamic REST(Blocks type, Dictionary<String, String> parameters)
		{
			switch (type)
			{
				case Blocks.List:
					return Get(Constants.BlocksURL + "list.json", parameters);
				case Blocks.Ids:
					return Get(Constants.BlocksURL + "ids.json", parameters);
				case Blocks.Create:
					if (parameters.ContainsKey("screen_name") || parameters.ContainsKey("user_id"))
					{
						return Post(Constants.BlocksURL + "create.json", parameters);
					}
					else
					{
						throw new Exception();
					}
				case Blocks.Destroy:
					if (parameters.ContainsKey("screen_name") || parameters.ContainsKey("user_id"))
					{
						return Post(Constants.BlocksURL + "destroy.json", parameters);
					}
					else
					{
						throw new Exception();
					}
				default:
					throw new Exception();
			}
		}
	}
}
