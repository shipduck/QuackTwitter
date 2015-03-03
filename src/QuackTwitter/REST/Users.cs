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
        public IList<TwitterUser> UsersLookup(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "screen_name", "user_id");

            return JsonConvert.DeserializeObject<IList<TwitterUser>>(GET(Constants.UsersURL + "/lookup.json", parameters));
        }

        async public Task<IList<TwitterUser>> UsersLookupAsync(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "screen_name", "user_id");

            return JsonConvert.DeserializeObject<IList<TwitterUser>>(await GETasync(Constants.UsersURL + "/lookup.json", parameters));
        }

        public TwitterUser UsersShow(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "screen_name", "user_id");

            return JsonConvert.DeserializeObject<TwitterUser>(GET(Constants.UsersURL + "/show.json", parameters));
        }

        async public Task<TwitterUser> UsersShowAsync(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "screen_name", "user_id");

            return JsonConvert.DeserializeObject<TwitterUser>(await GETasync(Constants.UsersURL + "/show.json", parameters));
        }

        public IList<TwitterUser> UsersSearch(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "q");

            return JsonConvert.DeserializeObject<IList<TwitterUser>>(GET(Constants.UsersURL + "/search.json", parameters));
        }

        async public Task<IList<TwitterUser>> UsersSearchAsync(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "q");

            return JsonConvert.DeserializeObject<IList<TwitterUser>>(await GETasync(Constants.UsersURL + "/search.json", parameters));
        }

        public TwitterBannerSizes UsersProfileBanner(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "screen_name", "user_id");

            return JsonConvert.DeserializeObject<TwitterBannerSizes>(GET(Constants.UsersURL + "/profile_banner.json", parameters));
        }

        async public Task<TwitterBannerSizes> UsersProfileBannerAsync(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "screen_name", "user_id");

            return JsonConvert.DeserializeObject<TwitterBannerSizes>(await GETasync(Constants.UsersURL + "/profile_banner.json", parameters));
        }

        public TwitterSlug UsersSuggestionsSlug(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "slug");

            return JsonConvert.DeserializeObject<TwitterSlug>(GET(Constants.UsersURL + "/suggestions/" + parameters["slug"] + ".json", parameters));
        }

        async public Task<TwitterSlug> UsersSuggestionsSlugAsync(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "slug");

            return JsonConvert.DeserializeObject<TwitterSlug>(await GETasync(Constants.UsersURL + "/suggestions/" + parameters["slug"] + ".json", parameters));
        }

        public IList<TwitterSlug> UsersSuggestions(IDictionary<string, string> parameters = null)
        {
            return JsonConvert.DeserializeObject<IList<TwitterSlug>>(GET(Constants.UsersURL + "/suggestions.json", parameters));
        }

        async public Task<IList<TwitterSlug>> UsersSuggestionsAsync(IDictionary<string, string> parameters = null)
        {
            return JsonConvert.DeserializeObject<IList<TwitterSlug>>(await GETasync(Constants.UsersURL + "/suggestions.json", parameters));
        }

        public IList<TwitterUser> UsersSuggestionsSlugMembers(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "slug");

            return JsonConvert.DeserializeObject<IList<TwitterUser>>(GET(Constants.UsersURL + "/suggestions/" + parameters["slug"] + "/members.json", parameters));
        }

        async public Task<IList<TwitterUser>> UsersSuggestionsSlugMembersAsync(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "slug");

            return JsonConvert.DeserializeObject<IList<TwitterUser>>(await GETasync(Constants.UsersURL + "/suggestions/" + parameters["slug"] + "/members.json", parameters));
        }

        public TwitterUser UsersReportSpam(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "screen_name", "user_id");

            return JsonConvert.DeserializeObject<TwitterUser>(POST(Constants.UsersURL + "/report_spam.json", parameters));
        }

        async public Task<TwitterUser> UsersReportSpamAsync(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "screen_name", "user_id");

            return JsonConvert.DeserializeObject<TwitterUser>(await POSTasync(Constants.UsersURL + "/report_spam.json", parameters));
        }
    }
}
