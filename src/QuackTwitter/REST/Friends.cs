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
        public TwitterUserIds FriendsIds(Dictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "user_id", "screen_name");

            return JsonConvert.DeserializeObject<TwitterUserIds>(GET(Constants.FriendsURL + "/ids.json", parameters));
        }

        public TwitterUsers FriendsList(Dictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "user_id", "screen_name");

            return JsonConvert.DeserializeObject<TwitterUsers>(GET(Constants.FriendsURL + "/list.json", parameters));
        }
    }
}
