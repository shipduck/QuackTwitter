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
		public TwitterUsers BlocksList(Dictionary<string, string> parameters = null)
		{
			return JsonConvert.DeserializeObject<TwitterUsers>(GET(Constants.BlocksURL + "/list.json", parameters));
		}

		public TwitterUserIds BlocksIds(Dictionary<string, string> parameters = null)
		{
			if (parameters.ContainsKey("stringify_ids"))
			{
				parameters["stringify_ids"] = "false";
			}
			return JsonConvert.DeserializeObject<TwitterUserIds>(GET(Constants.BlocksURL + "/ids.json", parameters));
		}
	}
}
