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
            Utils.RequiredParameters(parameters,
                "list_id",
                Utils.And("slug",
                    Utils.Or("owner_screen_name", "owner_id")));

            return JsonConvert.DeserializeObject<IList<TwitterStatus>>(GET(Constants.ListsURL + "/statuses.json", parameters));
        }

        public TwitterList ListsMembersDestroy(Dictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters,
                Utils.And(
                    Utils.Or("list_id",
                        Utils.And("slug",
                            Utils.Or("owner_screen_name", "owner_id"))),
                    Utils.Or("user_id", "screen_name")));

            return JsonConvert.DeserializeObject<TwitterList>(POST(Constants.ListsURL + "/members/destroy.json", parameters));
        }

        public TwitterLists ListsMemberships(Dictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "user_id", "screen_name");

            return JsonConvert.DeserializeObject<TwitterLists>(GET(Constants.ListsURL + "/memberships.json", parameters));
        }

        public TwitterUsers ListsSubscribers(Dictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "list_id",
                Utils.And("slug",
                    Utils.Or("owner_screen_name", "owner_id")));

            return JsonConvert.DeserializeObject<TwitterUsers>(GET(Constants.ListsURL + "/subscribers.json", parameters));
        }

        public TwitterList ListsSubscribersCreate(Dictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "list_id",
                Utils.And("slug",
                    Utils.Or("owner_screen_name", "owner_id")));

            return JsonConvert.DeserializeObject<TwitterList>(POST(Constants.ListsURL + "/subscribers/create.json", parameters));
        }

        public TwitterUser ListsSubscribersShow(Dictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters,
                Utils.And(
                    Utils.Or("list_id",
                        Utils.And("slug",
                            Utils.Or("owner_screen_name", "owner_id"))),
                    Utils.Or("user_id", "screen_name")));

            return JsonConvert.DeserializeObject<TwitterUser>(GET(Constants.ListsURL + "/subscribers/show.json", parameters));
        }

        public TwitterList ListsSubscribersDestroy(Dictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "list_id",
                Utils.And("slug",
                    Utils.Or("owner_screen_name", "owner_id")));

            return JsonConvert.DeserializeObject<TwitterList>(POST(Constants.ListsURL + "/subscribers/destroy.json", parameters));
        }

        public TwitterList ListsMembersCreateAll(Dictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters,
                Utils.And(
                    Utils.Or("list_id",
                        Utils.And("slug",
                            Utils.Or("owner_screen_name", "owner_id"))),
                    Utils.Or("user_id", "screen_name")));

            return JsonConvert.DeserializeObject<TwitterList>(POST(Constants.ListsURL + "/members/create_all.json", parameters));
        }

        public TwitterUser ListsMembersShow(Dictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters,
                Utils.And(
                    Utils.Or("list_id",
                        Utils.And("slug",
                            Utils.Or("owner_screen_name", "owner_id"))),
                    Utils.Or("user_id", "screen_name")));

            return JsonConvert.DeserializeObject<TwitterUser>(GET(Constants.ListsURL + "/members/show.json", parameters));
        }

        public TwitterUsers ListsMembers(Dictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "list_id",
                Utils.And("slug",
                    Utils.Or("owner_screen_name", "owner_id")));

            return JsonConvert.DeserializeObject<TwitterUsers>(GET(Constants.ListsURL + "/members.json", parameters));
        }

        public TwitterList ListsMembersCreate(Dictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters,
                Utils.And(
                    Utils.Or("list_id",
                        Utils.And("slug",
                            Utils.Or("owner_screen_name", "owner_id"))),
                    Utils.Or("user_id", "screen_name")));

            return JsonConvert.DeserializeObject<TwitterList>(POST(Constants.ListsURL + "/members/create.json", parameters));
        }

        public TwitterList ListsDestroy(Dictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "list_id",
                Utils.And("slug",
                    Utils.Or("owner_screen_name", "owner_id")));

            return JsonConvert.DeserializeObject<TwitterList>(POST(Constants.ListsURL + "/destroy.json", parameters));
        }

        public TwitterList ListsUpdate(Dictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "list_id",
                Utils.And("slug",
                    Utils.Or("owner_screen_name", "owner_id")));

            return JsonConvert.DeserializeObject<TwitterList>(POST(Constants.ListsURL + "/update.json", parameters));
        }

        public TwitterList ListsCreate(Dictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "name");

            return JsonConvert.DeserializeObject<TwitterList>(POST(Constants.ListsURL + "/create.json", parameters));
        }

        public TwitterList ListsShow(Dictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "list_id",
                Utils.And("slug",
                    Utils.Or("owner_screen_name", "owner_id")));

            return JsonConvert.DeserializeObject<TwitterList>(GET(Constants.ListsURL + "/show.json", parameters));
        }

        public TwitterLists ListsSubscriptions(Dictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters,
                    Utils.Or("user_id", "screen_name"));

            return JsonConvert.DeserializeObject<TwitterLists>(GET(Constants.ListsURL + "/subscriptions.json", parameters));
        }

        public TwitterLists ListsOwnerships(Dictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters,
                    Utils.Or("user_id", "screen_name"));

            return JsonConvert.DeserializeObject<TwitterLists>(GET(Constants.ListsURL + "/ownerships.json", parameters));
        }

        public TwitterList ListsMembersDestroyAll(Dictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters,
                Utils.And(
                    Utils.Or("list_id",
                        Utils.And("slug",
                            Utils.Or("owner_screen_name", "owner_id"))),
                    Utils.Or("user_id", "screen_name")));

            return JsonConvert.DeserializeObject<TwitterList>(POST(Constants.ListsURL + "/members/destroy_all.json", parameters));
        }
    }
}
