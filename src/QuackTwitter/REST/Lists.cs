using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuackTwitter
{
	partial class QuackTwitter
	{
		public enum Lists
		{
			List,
			Statuses,
			MembersDestroy,
			Memberships,
			Subscribers,
			SubscribersCreate,
			SubscribersShow,
			SubscribersDestroy,
			MembersCreateAll,
			MembersShow,
			Members,
			MembersCreate,
			Destroy,
			Update,
			Create,
			Show,
			Subscriptions,
			MembersDestroyAll,
			Ownerships
		};

		public dynamic REST(Lists type, Dictionary<String, String> parameters)
		{
			switch (type)
			{
				case Lists.List:
					return Get(Constants.ListsURL + "/list.json", parameters);
				case Lists.Statuses:
					if (parameters.ContainsKey("list_id")
						|| (parameters.ContainsKey("slug")
							&& (parameters.ContainsKey("owner_screen_name")
								|| parameters.ContainsKey("owner_id"))))
					{
						return Get(Constants.ListsURL + "/statuses.json", parameters);
					}
					else
					{
						throw new Exception();
					}
				case Lists.MembersDestroy:
					if (parameters.ContainsKey("list_id")
						|| (parameters.ContainsKey("slug")
							&& (parameters.ContainsKey("owner_screen_name")
								|| parameters.ContainsKey("owner_id"))))
					{
						return Post(Constants.ListsURL + "/members/destroy.json", parameters);
					}
					else
					{
						throw new Exception();
					}
				case Lists.Memberships:
					if (parameters.ContainsKey("user_id") || parameters.ContainsKey("screen_name"))
					{
						return Get(Constants.ListsURL + "/memberships.json", parameters);
					}
					else
					{
						throw new Exception();
					}
				case Lists.Subscribers:
					if (parameters.ContainsKey("list_id")
						|| (parameters.ContainsKey("slug")
							&& (parameters.ContainsKey("owner_screen_name")
								|| parameters.ContainsKey("owner_id"))))
					{
						return Get(Constants.ListsURL + "/subscribers.json", parameters);
					}
					else
					{
						throw new Exception();
					}
				case Lists.SubscribersCreate:
					if (parameters.ContainsKey("list_id")
						|| (parameters.ContainsKey("slug")
							&& (parameters.ContainsKey("owner_screen_name")
								|| parameters.ContainsKey("owner_id"))))
					{
						return Get(Constants.ListsURL + "/subscribers/create.json", parameters);
					}
					else
					{
						throw new Exception();
					}
				case Lists.SubscribersShow:
					if (parameters.ContainsKey("list_id")
						|| (parameters.ContainsKey("slug")
							&& (parameters.ContainsKey("owner_screen_name")
								|| parameters.ContainsKey("owner_id"))))
					{
						return Get(Constants.ListsURL + "/subscribers/show.json", parameters);
					}
					else
					{
						throw new Exception();
					}
				case Lists.SubscribersDestroy:
					if (parameters.ContainsKey("list_id")
						|| (parameters.ContainsKey("slug")
							&& (parameters.ContainsKey("owner_screen_name")
								|| parameters.ContainsKey("owner_id"))))
					{
						return Get(Constants.ListsURL + "/subscribers/destroy.json", parameters);
					}
					else
					{
						throw new Exception();
					}
				case Lists.MembersCreateAll:
					if (parameters.ContainsKey("list_id")
						|| (parameters.ContainsKey("slug")
							&& (parameters.ContainsKey("owner_screen_name")
								|| parameters.ContainsKey("owner_id"))))
					{
						return Get(Constants.ListsURL + "/members/create_all.json", parameters);
					}
					else
					{
						throw new Exception();
					}
				case Lists.MembersShow:
					if (parameters.ContainsKey("list_id")
						|| (parameters.ContainsKey("slug")
							&& (parameters.ContainsKey("owner_screen_name")
								|| parameters.ContainsKey("owner_id"))))
					{
						return Get(Constants.ListsURL + "/members/show.json", parameters);
					}
					else
					{
						throw new Exception();
					}
				case Lists.Members:
					if (parameters.ContainsKey("list_id")
						|| (parameters.ContainsKey("slug")
							&& (parameters.ContainsKey("owner_screen_name")
								|| parameters.ContainsKey("owner_id"))))
					{
						return Get(Constants.ListsURL + "/members.json", parameters);
					}
					else
					{
						throw new Exception();
					}
				case Lists.MembersCreate:
					if (parameters.ContainsKey("list_id")
						|| (parameters.ContainsKey("slug")
							&& (parameters.ContainsKey("owner_screen_name")
								|| parameters.ContainsKey("owner_id"))))
					{
						return Get(Constants.ListsURL + "/members/create.json", parameters);
					}
					else
					{
						throw new Exception();
					}
				case Lists.Destroy:
					if (parameters.ContainsKey("list_id")
						|| (parameters.ContainsKey("slug")
							&& (parameters.ContainsKey("owner_screen_name")
								|| parameters.ContainsKey("owner_id"))))
					{
						return Get(Constants.ListsURL + "/destroy.json", parameters);
					}
					else
					{
						throw new Exception();
					}
				case Lists.Update:
					if (parameters.ContainsKey("list_id")
						|| (parameters.ContainsKey("slug")
							&& (parameters.ContainsKey("owner_screen_name")
								|| parameters.ContainsKey("owner_id"))))
					{
						return Get(Constants.ListsURL + "/update.json", parameters);
					}
					else
					{
						throw new Exception();
					}
				case Lists.Create:
					if (parameters.ContainsKey("name"))
					{
						return Post(Constants.ListsURL + "/create.json", parameters);
					}
					else
					{
						throw new Exception();
					}
				case Lists.Show:
					if (parameters.ContainsKey("list_id")
						|| (parameters.ContainsKey("slug")
							&& (parameters.ContainsKey("owner_screen_name")
								|| parameters.ContainsKey("owner_id"))))
					{
						return Get(Constants.ListsURL + "/show.json", parameters);
					}
					else
					{
						throw new Exception();
					}
				case Lists.Subscriptions:
					if (parameters.ContainsKey("user_id") || parameters.ContainsKey("screen_name"))
					{
						return Get(Constants.ListsURL + "/subscriptions.json", parameters);
					}
					else
					{
						throw new Exception();
					}
				case Lists.MembersDestroyAll:
					if (parameters.ContainsKey("list_id")
						|| (parameters.ContainsKey("slug")
							&& (parameters.ContainsKey("owner_screen_name")
								|| parameters.ContainsKey("owner_id"))))
					{
						return Get(Constants.ListsURL + "/members/destroy_all.json", parameters);
					}
					else
					{
						throw new Exception();
					}
				case Lists.Ownerships:
					if (parameters.ContainsKey("user_id") || parameters.ContainsKey("screen_name"))
					{
						return Get(Constants.ListsURL + "/ownerships.json", parameters);
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
