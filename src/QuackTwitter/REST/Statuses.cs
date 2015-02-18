using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuackTwitter
{
	public partial class QuackTwitter
	{
		public interface ITwitterStatuses
		{
			IList<Status> UserTimeline(Dictionary<string, string> parameters);
		}

		private class TwitterStatuses : ITwitterStatuses
		{
			private QuackTwitter instance;
			public TwitterStatuses(QuackTwitter instance)
			{
				this.instance = instance;
			}

			public IList<Status> UserTimeline(Dictionary<string, string> parameters)
			{
				var json = instance.Get(Constants.StatusesUrl + "/user_timeline.json", parameters);
				IList<Status> list = new List<Status>();
				foreach (var tweet in json)
				{
					Status status = JsonConvert.DeserializeObject<Status>(tweet.ToString());
					list.Add(status);
				}
				return list;
			}
		}
	}
}
