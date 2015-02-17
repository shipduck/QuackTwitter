using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuackTwitter
{
	partial class Twitter
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
					return Get(Constants.BlocksUrl + "list.json", parameters);
				case Blocks.Ids:
					return Get(Constants.BlocksUrl + "ids.json", parameters);
				case Blocks.Create:
					if (parameters.ContainsKey("screen_name") || parameters.ContainsKey("user_id"))
					{
						return Post(Constants.BlocksUrl + "create.json", parameters);
					}
					else
					{
						throw new Exception();
					}
				case Blocks.Destroy:
					if (parameters.ContainsKey("screen_name") || parameters.ContainsKey("user_id"))
					{
						return Post(Constants.BlocksUrl + "destroy.json", parameters);
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
