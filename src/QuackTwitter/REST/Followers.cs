﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuackTwitter
{
    partial class Twitter
    {
        public TwitterUserIds FollowersIds(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "user_id", "screen_name");

            return JsonConvert.DeserializeObject<TwitterUserIds>(GET(Constants.FollowersURL + "/ids.json", parameters));
        }

        public TwitterUsers FollowersList(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "user_id", "screen_name");

            return JsonConvert.DeserializeObject<TwitterUsers>(GET(Constants.FollowersURL + "/list.json", parameters));
        }
    }
}
