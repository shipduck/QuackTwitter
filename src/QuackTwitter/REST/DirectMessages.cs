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
		public class TwitterDirectMessages
		{
			private Twitter instance;
			public TwitterDirectMessages(Twitter instance)
			{
				this.instance = instance;
			}

			public IList<TwitterDirectMessage> Sent(Dictionary<string, string> parameters = null)
			{
				return JsonConvert.DeserializeObject<IList<TwitterDirectMessage>>(instance.Get(Constants.DirectMessagesURL + "/sent.json", parameters));
			}

			public TwitterDirectMessage Show(Dictionary<string, string> parameters)
			{
				if (parameters.ContainsKey("id"))
				{
					return JsonConvert.DeserializeObject<IList<TwitterDirectMessage>>(instance.Get(Constants.DirectMessagesURL + "/show.json", parameters))[0];
				}
				else
				{
					throw new Exception();
				}
			}

			public IList<TwitterDirectMessage> List(Dictionary<string, string> parameters = null)
			{
				return JsonConvert.DeserializeObject<IList<TwitterDirectMessage>>(instance.Get(Constants.DirectMessagesURL + ".json", parameters));
			}

			public TwitterDirectMessage Destroy(Dictionary<string, string> parameters)
			{
				return JsonConvert.DeserializeObject<TwitterDirectMessage>(instance.Post(Constants.DirectMessagesURL + "/destroy.json", parameters));
			}

			public TwitterDirectMessage New(Dictionary<string, string> parameters)
			{
				if (parameters.ContainsKey("text"))
				{
					return JsonConvert.DeserializeObject<TwitterDirectMessage>(instance.Post(Constants.DirectMessagesURL + "/new.json", parameters));
				}
				else
				{
					throw new Exception();
				}
			}
		}
	}
}
