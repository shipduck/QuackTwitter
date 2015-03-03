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
        public TwitterUser MutesUsersCreate(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "screen_name", "user_id");

            return JsonConvert.DeserializeObject<TwitterUser>(POST(Constants.MutesURL + "/users/create.json", parameters));
        }

        public TwitterUser MutesUsersDestroy(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "screen_name", "user_id");

            return JsonConvert.DeserializeObject<TwitterUser>(POST(Constants.MutesURL + "/users/destroy.json", parameters));
        }

        public TwitterUserIds MutesUsersIds(IDictionary<string, string> parameters = null)
        {
            return JsonConvert.DeserializeObject<TwitterUserIds>(GET(Constants.MutesURL + "/users/ids.json", parameters));
        }

        public TwitterUsers MutesUsersList(IDictionary<string, string> parameters = null)
        {
            return JsonConvert.DeserializeObject<TwitterUsers>(GET(Constants.MutesURL + "/users/list.json", parameters));
        }
    }
}
