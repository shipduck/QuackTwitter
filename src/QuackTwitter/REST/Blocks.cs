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
        public TwitterUsers BlocksList(IDictionary<string, string> parameters = null)
        {
            return JsonConvert.DeserializeObject<TwitterUsers>(GET(Constants.BlocksURL + "/list.json", parameters));
        }

        async public Task<TwitterUsers> BlocksListAsync(IDictionary<string, string> parameters = null)
        {
            return JsonConvert.DeserializeObject<TwitterUsers>(await GETasync(Constants.BlocksURL + "/list.json", parameters));
        }

        public TwitterUserIds BlocksIds(IDictionary<string, string> parameters = null)
        {
            Utils.SetDefaultValue(parameters, "stringfy_ids", false);

            return JsonConvert.DeserializeObject<TwitterUserIds>(GET(Constants.BlocksURL + "/ids.json", parameters));
        }

        async public Task<TwitterUserIds> BlocksIdsAsync(IDictionary<string, string> parameters = null)
        {
            Utils.SetDefaultValue(parameters, "stringfy_ids", false);

            return JsonConvert.DeserializeObject<TwitterUserIds>(await GETasync(Constants.BlocksURL + "/ids.json", parameters));
        }
    }
}
