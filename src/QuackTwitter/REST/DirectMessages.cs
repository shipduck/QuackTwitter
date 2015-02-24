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
		public IList<TwitterDirectMessage> DirectMessagesSent(Dictionary<string, string> parameters = null)
		{
			return JsonConvert.DeserializeObject<IList<TwitterDirectMessage>>(GET(Constants.DirectMessagesURL + "/sent.json", parameters));
		}

		public IList<TwitterDirectMessage> DirectMessagesShow(Dictionary<string, string> parameters)
		{
			if (parameters.ContainsKey("id"))
			{
				return JsonConvert.DeserializeObject<IList<TwitterDirectMessage>>(GET(Constants.DirectMessagesURL + "/show.json", parameters));
			}
			else
			{
				throw new Exception();
			}
		}

		public IList<TwitterDirectMessage> DirectMessages(Dictionary<string, string> parameters = null)
		{
			return JsonConvert.DeserializeObject<IList<TwitterDirectMessage>>(GET(Constants.DirectMessagesURL + ".json", parameters));
		}

		public TwitterDirectMessage DirectMessagesDestroy(Dictionary<string, string> parameters = null)
		{
			return JsonConvert.DeserializeObject<TwitterDirectMessage>(POST(Constants.DirectMessagesURL + "/destroy.json", parameters));
		}

		public TwitterDirectMessage DirectMessagesNew(Dictionary<string, string> parameters)
		{
			if (parameters.ContainsKey("text"))
			{
				return JsonConvert.DeserializeObject<TwitterDirectMessage>(POST(Constants.DirectMessagesURL + "/new.json", parameters));
			}
			else
			{
				throw new Exception();
			}
		}
	}
}
