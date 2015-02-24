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
		public IList<TwitterList> ListsList(Dictionary<string, string> parameters = null)
		{
			return JsonConvert.DeserializeObject<IList<TwitterList>>(GET(Constants.ListsURL + "/list.json", parameters));
		}

		public IList<TwitterStatus> ListsStatuses(Dictionary<string, string> parameters)
		{
			if(parameters.ContainsKey("list_id")
				|| (parameters.ContainsKey("slug")
					&& (parameters.ContainsKey("owner_screen_name") || parameters.ContainsKey("owner_id"))))
			{
				return JsonConvert.DeserializeObject<IList<TwitterStatus>>(GET(Constants.ListsURL + "/statuses.json", parameters));
			}
			else {
				throw new Exception();
			}
		}

		public TwitterList ListsMembersDestroy(Dictionary<string, string> parameters)
		{
			if ((parameters.ContainsKey("list_id")
				|| (parameters.ContainsKey("slug")
					&& (parameters.ContainsKey("owner_screen_name") || parameters.ContainsKey("owner_id"))))
				&& (parameters.ContainsKey("user_id") || parameters.ContainsKey("screen_name"))
			)
			{
				return JsonConvert.DeserializeObject<TwitterList>(POST(Constants.ListsURL + "/members/destroy.json", parameters));
			}
			else
			{
				throw new Exception();
			}
		}

		public TwitterLists ListsMemberships(Dictionary<string, string> parameters)
		{
			if(parameters.ContainsKey("user_id") || parameters.ContainsKey("screen_name"))
			{
				return JsonConvert.DeserializeObject<TwitterLists>(GET(Constants.ListsURL + "/memberships.json", parameters));
			}
			else
			{
				throw new Exception();
			}
		}

		public TwitterUsers ListsSubscribers(Dictionary<string, string> parameters)
		{
			if(parameters.ContainsKey("list_id")
				|| (parameters.ContainsKey("slug")
					&& (parameters.ContainsKey("owner_screen_name") || parameters.ContainsKey("owner_id"))))
			{
				return JsonConvert.DeserializeObject<TwitterUsers>(GET(Constants.ListsURL + "/subscribers.json", parameters));
			}
			else {
				throw new Exception();
			}
		}

		public TwitterList ListsSubscribersCreate(Dictionary<string, string> parameters)
		{
			if (parameters.ContainsKey("list_id")
				|| (parameters.ContainsKey("slug")
					&& (parameters.ContainsKey("owner_screen_name") || parameters.ContainsKey("owner_id"))))
			{
				return JsonConvert.DeserializeObject<TwitterList>(POST(Constants.ListsURL + "/subscribers/create.json", parameters));
			}
			else
			{
				throw new Exception();
			}
		}

		public TwitterUser ListsSubscribersShow(Dictionary<string, string> parameters)
		{
			if ((parameters.ContainsKey("list_id")
				|| (parameters.ContainsKey("slug")
					&& (parameters.ContainsKey("owner_screen_name") || parameters.ContainsKey("owner_id"))))
				&& (parameters.ContainsKey("user_id") || parameters.ContainsKey("screen_name"))
			)
			{
				return JsonConvert.DeserializeObject<TwitterUser>(GET(Constants.ListsURL + "/subscribers/show.json", parameters));
			}
			else
			{
				throw new Exception();
			}
		}

		public TwitterList ListsSubscribersDestroy(Dictionary<string, string> parameters)
		{
			if (parameters.ContainsKey("list_id")
				|| (parameters.ContainsKey("slug")
					&& (parameters.ContainsKey("owner_screen_name") || parameters.ContainsKey("owner_id"))))
			{
				return JsonConvert.DeserializeObject<TwitterList>(POST(Constants.ListsURL + "/subscribers/destroy.json", parameters));
			}
			else
			{
				throw new Exception();
			}
		}

		public TwitterList ListsMembersCreateAll(Dictionary<string, string> parameters)
		{
			if ((parameters.ContainsKey("list_id")
				|| (parameters.ContainsKey("slug")
					&& (parameters.ContainsKey("owner_screen_name") || parameters.ContainsKey("owner_id"))))
				&& (parameters.ContainsKey("user_id") || parameters.ContainsKey("screen_name"))
			)
			{
				return JsonConvert.DeserializeObject<TwitterList>(POST(Constants.ListsURL + "/members/create_all.json", parameters));
			}
			else
			{
				throw new Exception();
			}
		}

		public TwitterUser ListsMembersShow(Dictionary<string, string> parameters)
		{
			if ((parameters.ContainsKey("list_id")
				|| (parameters.ContainsKey("slug")
					&& (parameters.ContainsKey("owner_screen_name") || parameters.ContainsKey("owner_id"))))
				&& (parameters.ContainsKey("user_id") || parameters.ContainsKey("screen_name"))
			)
			{
				return JsonConvert.DeserializeObject<TwitterUser>(GET(Constants.ListsURL + "/members/show.json", parameters));
			}
			else
			{
				throw new Exception();
			}
		}

		public TwitterUsers ListsMembers(Dictionary<string, string> parameters)
		{
			if (parameters.ContainsKey("list_id")
				|| (parameters.ContainsKey("slug")
					&& (parameters.ContainsKey("owner_screen_name") || parameters.ContainsKey("owner_id"))))
			{
				return JsonConvert.DeserializeObject<TwitterUsers>(GET(Constants.ListsURL + "/members.json", parameters));
			}
			else {
				throw new Exception();
			}
		}

		public TwitterList ListsMembersCreate(Dictionary<string, string> parameters)
		{
			if ((parameters.ContainsKey("list_id")
				|| (parameters.ContainsKey("slug")
					&& (parameters.ContainsKey("owner_screen_name") || parameters.ContainsKey("owner_id"))))
				&& (parameters.ContainsKey("user_id") || parameters.ContainsKey("screen_name"))
			)
			{
				return JsonConvert.DeserializeObject<TwitterList>(POST(Constants.ListsURL + "/members/create.json", parameters));
			}
			else
			{
				throw new Exception();
			}
		}

		public TwitterList ListsDestroy(Dictionary<string, string> parameters)
		{
			if (parameters.ContainsKey("list_id")
				|| (parameters.ContainsKey("slug")
					&& (parameters.ContainsKey("owner_screen_name") || parameters.ContainsKey("owner_id"))))
			{
				return JsonConvert.DeserializeObject<TwitterList>(POST(Constants.ListsURL + "/destroy.json", parameters));
			}
			else
			{
				throw new Exception();
			}
		}

		public TwitterList ListsUpdate(Dictionary<string, string> parameters)
		{
			if (parameters.ContainsKey("list_id")
				|| (parameters.ContainsKey("slug")
					&& (parameters.ContainsKey("owner_screen_name") || parameters.ContainsKey("owner_id"))))
			{
				return JsonConvert.DeserializeObject<TwitterList>(POST(Constants.ListsURL + "/update.json", parameters));
			}
			else
			{
				throw new Exception();
			}
		}

		public TwitterList ListsCreate(Dictionary<string, string> parameters)
		{
			if (parameters.ContainsKey("name"))
			{
				return JsonConvert.DeserializeObject<TwitterList>(POST(Constants.ListsURL + "/create.json", parameters));
			}
			else
			{
				throw new Exception();
			}
		}

		public TwitterList ListsShow(Dictionary<string, string> parameters)
		{
			if (parameters.ContainsKey("list_id")
				|| (parameters.ContainsKey("slug")
					&& (parameters.ContainsKey("owner_screen_name") || parameters.ContainsKey("owner_id"))))
			{
				return JsonConvert.DeserializeObject<TwitterList>(GET(Constants.ListsURL + "/show.json", parameters));
			}
			else
			{
				throw new Exception();
			}
		}

		public TwitterLists ListsSubscriptions(Dictionary<string, string> parameters)
		{
			if (parameters.ContainsKey("user_id") || parameters.ContainsKey("screen_name"))
			{
				return JsonConvert.DeserializeObject<TwitterLists>(GET(Constants.ListsURL + "/subscriptions.json", parameters));
			}
			else
			{
				throw new Exception();
			}
		}

		public TwitterLists ListsOwnerships(Dictionary<string, string> parameters)
		{
			if (parameters.ContainsKey("user_id") || parameters.ContainsKey("screen_name"))
			{
				return JsonConvert.DeserializeObject<TwitterLists>(GET(Constants.ListsURL + "/ownerships.json", parameters));
			}
			else
			{
				throw new Exception();
			}
		}

		public TwitterList ListsMembersDestroyAll(Dictionary<string, string> parameters)
		{
			if ((parameters.ContainsKey("list_id")
				|| (parameters.ContainsKey("slug")
					&& (parameters.ContainsKey("owner_screen_name") || parameters.ContainsKey("owner_id"))))
				&& (parameters.ContainsKey("user_id") || parameters.ContainsKey("screen_name"))
			)
			{
				return JsonConvert.DeserializeObject<TwitterList>(POST(Constants.ListsURL + "/members/destroy_all.json", parameters));
			}
			else
			{
				throw new Exception();
			}
		}
	}
}
