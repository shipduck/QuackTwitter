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
        public IList<TwitterList> ListsList(IDictionary<string, string> parameters = null)
        {
            return JsonConvert.DeserializeObject<IList<TwitterList>>(GET(Constants.ListsURL + "/list.json", parameters));
        }

        async public Task<IList<TwitterList>> ListsListAsync(IDictionary<string, string> parameters = null)
        {
            return JsonConvert.DeserializeObject<IList<TwitterList>>(await GETasync(Constants.ListsURL + "/list.json", parameters));
        }

        public IList<TwitterStatus> ListsStatuses(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters,
                "list_id",
                Utils.And("slug",
                    Utils.Or("owner_screen_name", "owner_id")));

            return JsonConvert.DeserializeObject<IList<TwitterStatus>>(GET(Constants.ListsURL + "/statuses.json", parameters));
        }

        async public Task<IList<TwitterStatus>> ListsStatusesAsync(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters,
                "list_id",
                Utils.And("slug",
                    Utils.Or("owner_screen_name", "owner_id")));

            return JsonConvert.DeserializeObject<IList<TwitterStatus>>(await GETasync(Constants.ListsURL + "/statuses.json", parameters));
        }

        public TwitterList ListsMembersDestroy(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters,
                Utils.And(
                    Utils.Or("list_id",
                        Utils.And("slug",
                            Utils.Or("owner_screen_name", "owner_id"))),
                    Utils.Or("user_id", "screen_name")));

            return JsonConvert.DeserializeObject<TwitterList>(POST(Constants.ListsURL + "/members/destroy.json", parameters));
        }

        async public Task<TwitterList> ListsMembersDestroyAsync(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters,
                Utils.And(
                    Utils.Or("list_id",
                        Utils.And("slug",
                            Utils.Or("owner_screen_name", "owner_id"))),
                    Utils.Or("user_id", "screen_name")));

            return JsonConvert.DeserializeObject<TwitterList>(await POSTasync(Constants.ListsURL + "/members/destroy.json", parameters));
        }

        public TwitterLists ListsMemberships(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "user_id", "screen_name");

            return JsonConvert.DeserializeObject<TwitterLists>(GET(Constants.ListsURL + "/memberships.json", parameters));
        }

        async public Task<TwitterLists> ListsMembershipsAsync(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "user_id", "screen_name");

            return JsonConvert.DeserializeObject<TwitterLists>(await GETasync(Constants.ListsURL + "/memberships.json", parameters));
        }

        public TwitterUsers ListsSubscribers(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "list_id",
                Utils.And("slug",
                    Utils.Or("owner_screen_name", "owner_id")));

            return JsonConvert.DeserializeObject<TwitterUsers>(GET(Constants.ListsURL + "/subscribers.json", parameters));
        }

        async public Task<TwitterUsers> ListsSubscribersAsync(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "list_id",
                Utils.And("slug",
                    Utils.Or("owner_screen_name", "owner_id")));

            return JsonConvert.DeserializeObject<TwitterUsers>(await GETasync(Constants.ListsURL + "/subscribers.json", parameters));
        }

        public TwitterList ListsSubscribersCreate(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "list_id",
                Utils.And("slug",
                    Utils.Or("owner_screen_name", "owner_id")));

            return JsonConvert.DeserializeObject<TwitterList>(POST(Constants.ListsURL + "/subscribers/create.json", parameters));
        }

        async public Task<TwitterList> ListsSubscribersCreateAsync(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "list_id",
                Utils.And("slug",
                    Utils.Or("owner_screen_name", "owner_id")));

            return JsonConvert.DeserializeObject<TwitterList>(await POSTasync(Constants.ListsURL + "/subscribers/create.json", parameters));
        }

        public TwitterUser ListsSubscribersShow(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters,
                Utils.And(
                    Utils.Or("list_id",
                        Utils.And("slug",
                            Utils.Or("owner_screen_name", "owner_id"))),
                    Utils.Or("user_id", "screen_name")));

            return JsonConvert.DeserializeObject<TwitterUser>(GET(Constants.ListsURL + "/subscribers/show.json", parameters));
        }

        async public Task<TwitterUser> ListsSubscribersShowAsync(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters,
                Utils.And(
                    Utils.Or("list_id",
                        Utils.And("slug",
                            Utils.Or("owner_screen_name", "owner_id"))),
                    Utils.Or("user_id", "screen_name")));

            return JsonConvert.DeserializeObject<TwitterUser>(await GETasync(Constants.ListsURL + "/subscribers/show.json", parameters));
        }

        public TwitterList ListsSubscribersDestroy(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "list_id",
                Utils.And("slug",
                    Utils.Or("owner_screen_name", "owner_id")));

            return JsonConvert.DeserializeObject<TwitterList>(POST(Constants.ListsURL + "/subscribers/destroy.json", parameters));
        }

        async public Task<TwitterList> ListsSubscribersDestroyAsync(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "list_id",
                Utils.And("slug",
                    Utils.Or("owner_screen_name", "owner_id")));

            return JsonConvert.DeserializeObject<TwitterList>(await POSTasync(Constants.ListsURL + "/subscribers/destroy.json", parameters));
        }

        public TwitterList ListsMembersCreateAll(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters,
                Utils.And(
                    Utils.Or("list_id",
                        Utils.And("slug",
                            Utils.Or("owner_screen_name", "owner_id"))),
                    Utils.Or("user_id", "screen_name")));

            return JsonConvert.DeserializeObject<TwitterList>(POST(Constants.ListsURL + "/members/create_all.json", parameters));
        }

        async public Task<TwitterList> ListsMembersCreateAllAsync(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters,
                Utils.And(
                    Utils.Or("list_id",
                        Utils.And("slug",
                            Utils.Or("owner_screen_name", "owner_id"))),
                    Utils.Or("user_id", "screen_name")));

            return JsonConvert.DeserializeObject<TwitterList>(await POSTasync(Constants.ListsURL + "/members/create_all.json", parameters));
        }

        public TwitterUser ListsMembersShow(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters,
                Utils.And(
                    Utils.Or("list_id",
                        Utils.And("slug",
                            Utils.Or("owner_screen_name", "owner_id"))),
                    Utils.Or("user_id", "screen_name")));

            return JsonConvert.DeserializeObject<TwitterUser>(GET(Constants.ListsURL + "/members/show.json", parameters));
        }

        async public Task<TwitterUser> ListsMembersShowAsync(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters,
                Utils.And(
                    Utils.Or("list_id",
                        Utils.And("slug",
                            Utils.Or("owner_screen_name", "owner_id"))),
                    Utils.Or("user_id", "screen_name")));

            return JsonConvert.DeserializeObject<TwitterUser>(await GETasync(Constants.ListsURL + "/members/show.json", parameters));
        }

        public TwitterUsers ListsMembers(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "list_id",
                Utils.And("slug",
                    Utils.Or("owner_screen_name", "owner_id")));

            return JsonConvert.DeserializeObject<TwitterUsers>(GET(Constants.ListsURL + "/members.json", parameters));
        }

        async public Task<TwitterUsers> ListsMembersAsync(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "list_id",
                Utils.And("slug",
                    Utils.Or("owner_screen_name", "owner_id")));

            return JsonConvert.DeserializeObject<TwitterUsers>(await GETasync(Constants.ListsURL + "/members.json", parameters));
        }

        public TwitterList ListsMembersCreate(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters,
                Utils.And(
                    Utils.Or("list_id",
                        Utils.And("slug",
                            Utils.Or("owner_screen_name", "owner_id"))),
                    Utils.Or("user_id", "screen_name")));

            return JsonConvert.DeserializeObject<TwitterList>(POST(Constants.ListsURL + "/members/create.json", parameters));
        }

        async public Task<TwitterList> ListsMembersCreateAsync(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters,
                Utils.And(
                    Utils.Or("list_id",
                        Utils.And("slug",
                            Utils.Or("owner_screen_name", "owner_id"))),
                    Utils.Or("user_id", "screen_name")));

            return JsonConvert.DeserializeObject<TwitterList>(await POSTasync(Constants.ListsURL + "/members/create.json", parameters));
        }

        public TwitterList ListsDestroy(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "list_id",
                Utils.And("slug",
                    Utils.Or("owner_screen_name", "owner_id")));

            return JsonConvert.DeserializeObject<TwitterList>(POST(Constants.ListsURL + "/destroy.json", parameters));
        }

        async public Task<TwitterList> ListsDestroyAsync(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "list_id",
                Utils.And("slug",
                    Utils.Or("owner_screen_name", "owner_id")));

            return JsonConvert.DeserializeObject<TwitterList>(await POSTasync(Constants.ListsURL + "/destroy.json", parameters));
        }

        public TwitterList ListsUpdate(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "list_id",
                Utils.And("slug",
                    Utils.Or("owner_screen_name", "owner_id")));

            return JsonConvert.DeserializeObject<TwitterList>(POST(Constants.ListsURL + "/update.json", parameters));
        }

        async public Task<TwitterList> ListsUpdateAsync(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "list_id",
                Utils.And("slug",
                    Utils.Or("owner_screen_name", "owner_id")));

            return JsonConvert.DeserializeObject<TwitterList>(await POSTasync(Constants.ListsURL + "/update.json", parameters));
        }

        public TwitterList ListsCreate(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "name");

            return JsonConvert.DeserializeObject<TwitterList>(POST(Constants.ListsURL + "/create.json", parameters));
        }

        async public Task<TwitterList> ListsCreateAsync(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "name");

            return JsonConvert.DeserializeObject<TwitterList>(await POSTasync(Constants.ListsURL + "/create.json", parameters));
        }

        public TwitterList ListsShow(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "list_id",
                Utils.And("slug",
                    Utils.Or("owner_screen_name", "owner_id")));

            return JsonConvert.DeserializeObject<TwitterList>(GET(Constants.ListsURL + "/show.json", parameters));
        }

        async public Task<TwitterList> ListsShowAsync(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "list_id",
                Utils.And("slug",
                    Utils.Or("owner_screen_name", "owner_id")));

            return JsonConvert.DeserializeObject<TwitterList>(await GETasync(Constants.ListsURL + "/show.json", parameters));
        }

        public TwitterLists ListsSubscriptions(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters,
                    Utils.Or("user_id", "screen_name"));

            return JsonConvert.DeserializeObject<TwitterLists>(GET(Constants.ListsURL + "/subscriptions.json", parameters));
        }

        async public Task<TwitterLists> ListsSubscriptionsAsync(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters,
                    Utils.Or("user_id", "screen_name"));

            return JsonConvert.DeserializeObject<TwitterLists>(await GETasync(Constants.ListsURL + "/subscriptions.json", parameters));
        }

        public TwitterLists ListsOwnerships(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters,
                    Utils.Or("user_id", "screen_name"));

            return JsonConvert.DeserializeObject<TwitterLists>(GET(Constants.ListsURL + "/ownerships.json", parameters));
        }

        async public Task<TwitterLists> ListsOwnershipsAsync(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters,
                    Utils.Or("user_id", "screen_name"));

            return JsonConvert.DeserializeObject<TwitterLists>(await GETasync(Constants.ListsURL + "/ownerships.json", parameters));
        }

        public TwitterList ListsMembersDestroyAll(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters,
                Utils.And(
                    Utils.Or("list_id",
                        Utils.And("slug",
                            Utils.Or("owner_screen_name", "owner_id"))),
                    Utils.Or("user_id", "screen_name")));

            return JsonConvert.DeserializeObject<TwitterList>(POST(Constants.ListsURL + "/members/destroy_all.json", parameters));
        }

        async public Task<TwitterList> ListsMembersDestroyAllAsync(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters,
                Utils.And(
                    Utils.Or("list_id",
                        Utils.And("slug",
                            Utils.Or("owner_screen_name", "owner_id"))),
                    Utils.Or("user_id", "screen_name")));

            return JsonConvert.DeserializeObject<TwitterList>(await POSTasync(Constants.ListsURL + "/members/destroy_all.json", parameters));
        }
    }
}
