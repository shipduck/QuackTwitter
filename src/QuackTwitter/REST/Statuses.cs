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
        public IList<TwitterStatus> StatusesMentionsTimeline(IDictionary<string, string> parameters = null)
        {
            return JsonConvert.DeserializeObject<IList<TwitterStatus>>(GET(Constants.StatusesURL + "/mentions_timeline.json", parameters));
        }

        public IList<TwitterStatus> StatusesUserTimeline(IDictionary<string, string> parameters = null)
        {
            return JsonConvert.DeserializeObject<IList<TwitterStatus>>(GET(Constants.StatusesURL + "/user_timeline.json", parameters));
        }

        public IList<TwitterStatus> StatusesHomeTimeline(IDictionary<string, string> parameters = null)
        {
            return JsonConvert.DeserializeObject<IList<TwitterStatus>>(GET(Constants.StatusesURL + "/home_timeline.json", parameters));
        }

        public IList<TwitterStatus> StatusesRetweetsOfMe(IDictionary<string, string> parameters = null)
        {
            return JsonConvert.DeserializeObject<IList<TwitterStatus>>(GET(Constants.StatusesURL + "/retweets_of_me.json", parameters));
        }

        public IList<TwitterStatus> StatusesRetweets(IDictionary<string, string> parameters = null)
        {
            Utils.RequiredParameters(parameters, "id");

            return JsonConvert.DeserializeObject<IList<TwitterStatus>>(GET(Constants.StatusesURL + "/retweets/" + parameters["id"] + ".json", parameters));
        }

        public TwitterStatus StatusesShow(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "id");

            return JsonConvert.DeserializeObject<TwitterStatus>(GET(Constants.StatusesURL + "/show.json", parameters));
        }

        public TwitterStatus StatusesDestroy(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "id");

            return JsonConvert.DeserializeObject<TwitterStatus>(POST(Constants.StatusesURL + "/destroy/" + parameters["id"] + ".json", parameters));
        }

        public TwitterStatus StatusesUpdate(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "status");

            return JsonConvert.DeserializeObject<TwitterStatus>(POST(Constants.StatusesURL + "/update.json", parameters));
        }

        public TwitterStatus StatusesRetweet(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "id");

            return JsonConvert.DeserializeObject<TwitterStatus>(POST(Constants.StatusesURL + "/retweet/" + parameters["id"] + ".json", parameters));
        }

        public TwitterStatus StatusesUpdateWithMedia(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, Utils.And("status", "media[]"));

            return JsonConvert.DeserializeObject<TwitterStatus>(POST(Constants.StatusesURL + "/update_with_media.json", parameters));
        }

        //		public TwitterOEmbed StatusesOEmbed(IDictionary<string, string> parameters) {}

        public TwitterUserIds StatusesRetweetersIds(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "id");

            return JsonConvert.DeserializeObject<TwitterUserIds>(GET(Constants.StatusesURL + "/retweeters/ids.json", parameters));
        }

        public IList<TwitterStatus> StatusesLookup(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "id");

            return JsonConvert.DeserializeObject<IList<TwitterStatus>>(GET(Constants.StatusesURL + "/lookup.json", parameters));
        }
    }
}
