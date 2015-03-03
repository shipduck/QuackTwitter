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
        public TwitterUserIds FriendsIds(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "user_id", "screen_name");

            return JsonConvert.DeserializeObject<TwitterUserIds>(GET(Constants.FriendsURL + "/ids.json", parameters));
        }

        async public Task<TwitterUserIds> FriendsIdsAsync(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "user_id", "screen_name");

            return JsonConvert.DeserializeObject<TwitterUserIds>(await GETasync(Constants.FriendsURL + "/ids.json", parameters));
        }

        public TwitterUsers FriendsList(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "user_id", "screen_name");

            return JsonConvert.DeserializeObject<TwitterUsers>(GET(Constants.FriendsURL + "/list.json", parameters));
        }

        async public Task<TwitterUsers> FriendsListAsync(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "user_id", "screen_name");

            return JsonConvert.DeserializeObject<TwitterUsers>(await GETasync(Constants.FriendsURL + "/list.json", parameters));
        }
    }
}
