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
        public TwitterSearch SearchTweets(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "q");

            return JsonConvert.DeserializeObject<TwitterSearch>(GET(Constants.SearchURL + "/tweets.json", parameters));
        }

        async public Task<TwitterSearch> SearchTweetsAsync(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "q");

            return JsonConvert.DeserializeObject<TwitterSearch>(await GETasync(Constants.SearchURL + "/tweets.json", parameters));
        }
    }
}
