using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuackTwitter
{
	partial class QuackTwitter
	{
		public enum Mutes
		{
			UsersCreate,
			UsersDestroy,
			UsersIds,
			UsersList
		};

		public dynamic REST(Mutes type, Dictionary<String, String> parameters)
		{
			switch (type)
			{
				case Mutes.UsersCreate:
					if (parameters.ContainsKey("screen_name")
						|| parameters.ContainsKey("user_id"))
					{
						return Post(Constants.MutesURL + "/users/create.json", parameters);
					}
					else
					{
						throw new Exception();
					}
				case Mutes.UsersDestroy:
					if (parameters.ContainsKey("screen_name")
						|| parameters.ContainsKey("usre_id"))
					{
						return Post(Constants.MutesURL + "/users/destroy.json", parameters);
					}
					else
					{
						throw new Exception();
					}
				case Mutes.UsersIds:
					return Get(Constants.MutesURL + "users/ids.json", parameters);
				case Mutes.UsersList:
					return Get(Constants.MutesURL + "usres/list.json", parameters);
				default:
					throw new Exception();
			}
		}
	}
}
