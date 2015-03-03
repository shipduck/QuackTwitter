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
        public IList<long> FriendshipsNoRetweetsIds(IDictionary<string, string> parameters = null)
        {
            Utils.SetDefaultValue(parameters, "stringfy_ids", false);

            return JsonConvert.DeserializeObject<IList<long>>(GET(Constants.FriendshipsURL + "/no_retweets/ids.json", parameters));
        }

        async public Task<IList<long>> FriendshipsNoRetweetsIdsAsync(IDictionary<string, string> parameters = null)
        {
            Utils.SetDefaultValue(parameters, "stringfy_ids", false);

            return JsonConvert.DeserializeObject<IList<long>>(await GETasync(Constants.FriendshipsURL + "/no_retweets/ids.json", parameters));
        }

        public TwitterUserIds FriendshipsIncoming(IDictionary<string, string> parameters = null)
        {
            Utils.SetDefaultValue(parameters, "stringfy_ids", false);

            return JsonConvert.DeserializeObject<TwitterUserIds>(GET(Constants.FriendshipsURL + "/incoming.json", parameters));
        }

        async public Task<TwitterUserIds> FriendshipsIncomingAsync(IDictionary<string, string> parameters = null)
        {
            Utils.SetDefaultValue(parameters, "stringfy_ids", false);

            return JsonConvert.DeserializeObject<TwitterUserIds>(await GETasync(Constants.FriendshipsURL + "/incoming.json", parameters));
        }

        public TwitterUserIds FriendshipsOutgoing(IDictionary<string, string> parameters = null)
        {
            Utils.SetDefaultValue(parameters, "stringfy_ids", false);

            return JsonConvert.DeserializeObject<TwitterUserIds>(GET(Constants.FriendshipsURL + "/outgoing.json", parameters));
        }

        async public Task<TwitterUserIds> FriendshipsOutgoingAsync(IDictionary<string, string> parameters = null)
        {
            Utils.SetDefaultValue(parameters, "stringfy_ids", false);

            return JsonConvert.DeserializeObject<TwitterUserIds>(await GETasync(Constants.FriendshipsURL + "/outgoing.json", parameters));
        }

        public TwitterUser FriendshipsCreate(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "user_id", "screen_name");

            return JsonConvert.DeserializeObject<TwitterUser>(POST(Constants.FriendshipsURL + "/create.json", parameters));
        }

        async public Task<TwitterUser> FriendshipsCreateAsync(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "user_id", "screen_name");

            return JsonConvert.DeserializeObject<TwitterUser>(await POSTasync(Constants.FriendshipsURL + "/create.json", parameters));
        }

        public TwitterUser FriendshipsDestroy(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "user_id", "screen_name");

            return JsonConvert.DeserializeObject<TwitterUser>(POST(Constants.FriendshipsURL + "/destroy.json", parameters));
        }

        async public Task<TwitterUser> FriendshipsDestroyAsync(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "user_id", "screen_name");

            return JsonConvert.DeserializeObject<TwitterUser>(await POSTasync(Constants.FriendshipsURL + "/destroy.json", parameters));
        }

        public TwitterRelationship FriendshipsUpdate(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "user_id", "screen_name");

            return JsonConvert.DeserializeObject<Dictionary<string, TwitterRelationship>>(POST(Constants.FriendshipsURL + "/update.json", parameters))["relationship"];
        }

        async public Task<TwitterRelationship> FriendshipsUpdateAsync(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "user_id", "screen_name");

            return JsonConvert.DeserializeObject<Dictionary<string, TwitterRelationship>>(await POSTasync(Constants.FriendshipsURL + "/update.json", parameters))["relationship"];
        }

        public TwitterRelationship FriendshipsShow(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters,
                Utils.And(
                    Utils.Or("source_id", "source_screen_name"),
                    Utils.Or("target_id", "target_screen_name")));

            return JsonConvert.DeserializeObject<Dictionary<string, TwitterRelationship>>(GET(Constants.FriendshipsURL + "/show.json", parameters))["relationship"];
        }

        async public Task<TwitterRelationship> FriendshipsShowAsync(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters,
                Utils.And(
                    Utils.Or("source_id", "source_screen_name"),
                    Utils.Or("target_id", "target_screen_name")));

            return JsonConvert.DeserializeObject<Dictionary<string, TwitterRelationship>>(await GETasync(Constants.FriendshipsURL + "/show.json", parameters))["relationship"];
        }

        public IList<TwitterFriendshipUser> FriendshipsLookup(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "user_id", "screen_name");

            return JsonConvert.DeserializeObject<IList<TwitterFriendshipUser>>(GET(Constants.FriendshipsURL + "/lookup.json", parameters));
        }

        async public Task<IList<TwitterFriendshipUser>> FriendshipsLookupAsync(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "user_id", "screen_name");

            return JsonConvert.DeserializeObject<IList<TwitterFriendshipUser>>(await GETasync(Constants.FriendshipsURL + "/lookup.json", parameters));
        }
    }
}
