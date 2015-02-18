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
						return Post(Constants.MutesUrl + "/users/create.json", parameters);
					}
					else
					{
						throw new Exception();
					}
				case Mutes.UsersDestroy:
					if (parameters.ContainsKey("screen_name")
						|| parameters.ContainsKey("usre_id"))
					{
						return Post(Constants.MutesUrl + "/users/destroy.json", parameters);
					}
					else
					{
						throw new Exception();
					}
				case Mutes.UsersIds:
					return Get(Constants.MutesUrl + "users/ids.json", parameters);
				case Mutes.UsersList:
					return Get(Constants.MutesUrl + "usres/list.json", parameters);
				default:
					throw new Exception();
			}
		}
	}
}
