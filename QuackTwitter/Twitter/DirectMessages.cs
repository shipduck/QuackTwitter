using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuackTwitter
{
	partial class Twitter
	{
		public enum DirectMessages
		{
			Sent,
			Show,
			List,
			Destroy,
			New
		};

		public dynamic REST(DirectMessages type, Dictionary<String, String> parameters)
		{
			switch (type)
			{
				case DirectMessages.Sent:
					return Get(Constants.DirectMessagesUrl + "/sent.json", parameters);
				case DirectMessages.Show:
					if (parameters.ContainsKey("id"))
					{
						return Get(Constants.DirectMessagesUrl + "/show.json", parameters);
					}
					else
					{
						throw new Exception();
					}
				case DirectMessages.List:
					return Get(Constants.DirectMessagesUrl + ".json", parameters);
				case DirectMessages.Destroy:
					if (parameters.ContainsKey("id"))
					{
						return Post(Constants.DirectMessagesUrl + "/destory.json", parameters);
					}
					else
					{
						throw new Exception();
					}
				case DirectMessages.New:
					if (parameters.ContainsKey("user_id") || parameters.ContainsKey("screen_name"))
					{
						return Post(Constants.DirectMessagesUrl + "/new.json", parameters);
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
