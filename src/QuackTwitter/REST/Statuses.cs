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
        public IList<TwitterStatus> StatusesMentionsTimeline(Dictionary<string, string> parameters = null)
        {
            return JsonConvert.DeserializeObject<IList<TwitterStatus>>(GET(Constants.StatusesURL + "/mentions_timeline.json", parameters));
        }

        public IList<TwitterStatus> StatusesUserTimeline(Dictionary<string, string> parameters = null)
        {
            return JsonConvert.DeserializeObject<IList<TwitterStatus>>(GET(Constants.StatusesURL + "/user_timeline.json", parameters));
        }

        public IList<TwitterStatus> StatusesHomeTimeline(Dictionary<string, string> parameters = null)
        {
            return JsonConvert.DeserializeObject<IList<TwitterStatus>>(GET(Constants.StatusesURL + "/home_timeline.json", parameters));
        }

        public IList<TwitterStatus> StatusesRetweetsOfMe(Dictionary<string, string> parameters = null)
        {
            return JsonConvert.DeserializeObject<IList<TwitterStatus>>(GET(Constants.StatusesURL + "/retweets_of_me.json", parameters));
        }

        public IList<TwitterStatus> StatusesRetweets(Dictionary<string, string> parameters = null)
        {
            Utils.RequiredParameters(parameters, "id");

            return JsonConvert.DeserializeObject<IList<TwitterStatus>>(GET(Constants.StatusesURL + "/retweets/" + parameters["id"] + ".json", parameters));
        }

        public TwitterStatus StatusesShow(Dictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "id");

            return JsonConvert.DeserializeObject<TwitterStatus>(GET(Constants.StatusesURL + "/show.json", parameters));
        }

        public TwitterStatus StatusesDestroy(Dictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "id");

            return JsonConvert.DeserializeObject<TwitterStatus>(POST(Constants.StatusesURL + "/destroy/" + parameters["id"] + ".json", parameters));
        }

        public TwitterStatus StatusesUpdate(Dictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "status");

            return JsonConvert.DeserializeObject<TwitterStatus>(POST(Constants.StatusesURL + "/update.json", parameters));
        }

        public TwitterStatus StatusesRetweet(Dictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "id");

            return JsonConvert.DeserializeObject<TwitterStatus>(POST(Constants.StatusesURL + "/retweet/" + parameters["id"] + ".json", parameters));
        }

        public TwitterStatus StatusesUpdateWithMedia(Dictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, Utils.And("status", "media[]"));

            return JsonConvert.DeserializeObject<TwitterStatus>(POST(Constants.StatusesURL + "/update_with_media.json", parameters));
        }

        //		public TwitterOEmbed StatusesOEmbed(Dictionary<string, string> parameters) {}

        public TwitterUserIds StatusesRetweetersIds(Dictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "id");

            return JsonConvert.DeserializeObject<TwitterUserIds>(GET(Constants.StatusesURL + "/retweeters/ids.json", parameters));
        }

        public IList<TwitterStatus> StatusesLookup(Dictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "id");

            return JsonConvert.DeserializeObject<IList<TwitterStatus>>(GET(Constants.StatusesURL + "/lookup.json", parameters));
        }
    }
}
