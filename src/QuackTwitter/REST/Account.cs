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
        public TwitterSettings AccountSettingsGET(Dictionary<string, string> parameters = null)
        {
            return JsonConvert.DeserializeObject<TwitterSettings>(GET(Constants.AccountURL + "/settings.json", parameters));
        }

        public TwitterUser AccountVerifyCredentials(Dictionary<string, string> parameters = null)
        {
            return JsonConvert.DeserializeObject<TwitterUser>(GET(Constants.AccountURL + "/verify_credentials.json", parameters));
        }

        public TwitterSettings AccountSettingsPOST(Dictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters,
                "trend_location_woe_id",
                "sleep_time_enabled",
                "start_sleep_time",
                "end_sleep_time",
                "time_zone",
                "lang");

            return JsonConvert.DeserializeObject<TwitterSettings>(POST(Constants.AccountURL + "settings.json", parameters));
        }

        public TwitterUser AccountUpdateDeliveryDevice(Dictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "device");

            return JsonConvert.DeserializeObject<TwitterUser>(POST(Constants.AccountURL + "/update_delivery_device.json", parameters));
        }

        public TwitterUser AccountUpdateProfile(Dictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters,
                "name",
                "url",
                "location",
                "description",
                "profile_link_color",
                "include_entities",
                "skip_status");

            return JsonConvert.DeserializeObject<TwitterUser>(POST(Constants.AccountURL + "/update_profile.json", parameters));
        }

        public TwitterUser AccountUpdateProfileBackgroundImage(Dictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "image");

            return JsonConvert.DeserializeObject<TwitterUser>(POST(Constants.AccountURL + "/update_profile_background_image.json", parameters));
        }

        public TwitterUser AccountUpdateProfileImage(Dictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "image");

            return JsonConvert.DeserializeObject<TwitterUser>(POST(Constants.AccountURL + "/update_profile_image.json", parameters));
        }

        public void AccountRemoveProfileBanner(Dictionary<string, string> parameters = null)
        {
            POST(Constants.AccountURL + "/remove_profile_banner.json", parameters);
        }

        public void AccountUpdateProfileBanner(Dictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "banner");

            POST(Constants.AccountURL + "/update_profile_banner.json", parameters);
        }
    }
}
