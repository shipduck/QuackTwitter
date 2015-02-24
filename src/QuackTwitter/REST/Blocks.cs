using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuackTwitter
{
	partial class Twitter
	{
		public class TwitterBlocks
		{
			private Twitter instance;
			public TwitterBlocks(Twitter instance)
			{
				this.instance = instance;
			}

			public TwitterUserList List(Dictionary<string, string> parameters)
			{
				return JsonConvert.DeserializeObject<TwitterUserList>(instance.Get(Constants.BlocksURL + "/list.json", parameters));
			}

			public TwitterUserIds Ids(Dictionary<string, string> parameters)
			{
				if (parameters.ContainsKey("stringify_ids"))
				{
					parameters["stringify_ids"] = "false";
				}
				return JsonConvert.DeserializeObject<TwitterUserIds>(instance.Get(Constants.BlocksURL + "/ids.json", parameters));
			}
		}
	}
}
