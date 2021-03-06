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
        public TwitterMedia MediaUpload(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "media");

            return JsonConvert.DeserializeObject<TwitterMedia>(POST(Constants.MediaURL + "/upload.json", parameters));
        }

        async public Task<TwitterMedia> MediaUploadAsync(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "media");

            return JsonConvert.DeserializeObject<TwitterMedia>(await POSTasync(Constants.MediaURL + "/upload.json", parameters));
        }
    }
}
