using Newtonsoft.Json;
using PCLStorage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuackTwitter
{
    partial class Twitter
    {
        private IDictionary<string, string> GenerateAccountSettingsParam()
        {
            return new Dictionary<string, string> { };
        }

        public TwitterSettings AccountSettingsGET()
        {
            var parameters = GenerateAccountSettingsParam();

            return JsonConvert.DeserializeObject<TwitterSettings>(GET(Constants.AccountURL + "/settings.json", parameters));
        }

        async public Task<TwitterSettings> AccountSettingsGETAsync()
        {
            var parameters = GenerateAccountSettingsParam();

            return JsonConvert.DeserializeObject<TwitterSettings>(await GETasync(Constants.AccountURL + "/settings.json", parameters));
        }

        private IDictionary<string, string> GenerateAccountVerifyCredentialsParam(bool? includeEntities, bool? skipStatus)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();

            Utils.SetParam(param, "include_entities", includeEntities);
            Utils.SetParam(param, "skip_status", skipStatus);

            return param;
        }

        public TwitterUser AccountVerifyCredentials(bool? includeEntities = null, bool? skipStatus = null)
        {
            var parameters = GenerateAccountVerifyCredentialsParam(includeEntities, skipStatus);

            return JsonConvert.DeserializeObject<TwitterUser>(GET(Constants.AccountURL + "/verify_credentials.json", parameters));
        }

        async public Task<TwitterUser> AccountVerifyCredentialsAsync(bool? includeEntities = null, bool? skipStatus = null)
        {
            var parameters = GenerateAccountVerifyCredentialsParam(includeEntities, skipStatus);

            return JsonConvert.DeserializeObject<TwitterUser>(await GETasync(Constants.AccountURL + "/verify_credentials.json", parameters));
        }

        private IDictionary<string, string> GenerateAccountSettingsPOSTParam(
            int? trendLocationWoeid, bool? sleepTimeEnabled, int? startSleepTime,
            int? endSleepTime, string timeZone, Language? lang)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();

            Utils.SetParam(param, "trend_location_woeid", trendLocationWoeid);
            Utils.SetParam(param, "sleep_time_enabled", sleepTimeEnabled);
            Utils.SetParam(param, "start_sleep_time", startSleepTime);
            Utils.SetParam(param, "end_sleep_time", endSleepTime);
            Utils.SetParam(param, "time_zone", timeZone);
            Utils.SetParam(param, "lang", lang);

            Utils.RequiredParameters(param,
                "trend_location_woe_id",
                "sleep_time_enabled",
                "start_sleep_time",
                "end_sleep_time",
                "time_zone",
                "lang");

            return param;
        }

        public TwitterSettings AccountSettingsPOST(
            int? trendLocationWoeid = null, bool? sleepTimeEnabled = null,
            int? startSleepTime = null, int? endSleepTime = null,
            String timeZone = null, Language? lang = null)
        {
            var parameters = GenerateAccountSettingsPOSTParam(
                trendLocationWoeid, sleepTimeEnabled,
                startSleepTime, endSleepTime,
                timeZone, lang);

            return JsonConvert.DeserializeObject<TwitterSettings>(POST(Constants.AccountURL + "settings.json", parameters));
        }

        async public Task<TwitterSettings> AccountSettingsPOSTAsync(
            int? trendLocationWoeid = null, bool? sleepTimeEnabled = null,
            int? startSleepTime = null, int? endSleepTime = null,
            String timeZone = null, Language? lang = null)
        {
            var parameters = GenerateAccountSettingsPOSTParam(
                trendLocationWoeid, sleepTimeEnabled,
                startSleepTime, endSleepTime,
                timeZone, lang);

            return JsonConvert.DeserializeObject<TwitterSettings>(await POSTasync(Constants.AccountURL + "settings.json", parameters));
        }

        [EnumValueMapped]
        public enum DeviceType
        {
            [EnumValue("sms")]
            SMS,
            [EnumValue("none")]
            NONE
        }

        private IDictionary<string, string> GenerateAccountUpdateDeliveryDeviceParam(
            DeviceType device, bool? include_entities)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();

            param.Add("device", ConversionToString.EnumValueMapToString(device));

            Utils.RequiredParameters(param, "device");

            return param;
        }

        public TwitterUser AccountUpdateDeliveryDevice(
            DeviceType device, bool? include_entities = null)
        {
            var parameters = GenerateAccountUpdateDeliveryDeviceParam(device, include_entities);

            return JsonConvert.DeserializeObject<TwitterUser>(POST(Constants.AccountURL + "/update_delivery_device.json", parameters));
        }

        async public Task<TwitterUser> AccountUpdateDeliveryDeviceAsync(
            DeviceType device, bool? include_entities = null)
        {
            var parameters = GenerateAccountUpdateDeliveryDeviceParam(device, include_entities);

            return JsonConvert.DeserializeObject<TwitterUser>(await POSTasync(Constants.AccountURL + "/update_delivery_device.json", parameters));
        }

        private IDictionary<string, string> GenerateAccountUpdateProfileParam(
            string name, string url,
            string location, string description,
            Color profileLinkColor, bool? includeEntities,
            bool? skipStatus)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();

            Utils.SetParam(param, "name", name);
            Utils.SetParam(param, "url", url);
            Utils.SetParam(param, "location", location);
            Utils.SetParam(param, "description", description);
            Utils.SetParam(param, "profile_link_color", profileLinkColor);
            Utils.SetParam(param, "include_entities", includeEntities);
            Utils.SetParam(param, "skip_status", skipStatus);

            Utils.RequiredParameters(param,
                "name",
                "url",
                "location",
                "description",
                "profile_link_color",
                "include_entities",
                "skip_status");

            return param;
        }

        public TwitterUser AccountUpdateProfile(
            string name = null, string url = null,
            string location = null, string description = null,
            Color profileLinkColor = null, bool? includeEntities = null,
            bool? skipStatus = null)
        {
            var parameters = GenerateAccountUpdateProfileParam(
                name, url,
                location, description,
                profileLinkColor, includeEntities,
                skipStatus);

            var response = POST(Constants.AccountURL + "/update_profile.json", parameters);

            return JsonConvert.DeserializeObject<TwitterUser>(response);
        }

        async public Task<TwitterUser> AccountUpdateProfileAsync(
            string name = null, string url = null,
            string location = null, string description = null,
            Color profileLinkColor = null, bool? includeEntities = null,
            bool? skipStatus = null)
        {
            var parameters = GenerateAccountUpdateProfileParam(
                name, url,
                location, description,
                profileLinkColor, includeEntities,
                skipStatus);

            return JsonConvert.DeserializeObject<TwitterUser>(await POSTasync(Constants.AccountURL + "/update_profile.json", parameters));
        }
        
        private IDictionary<string, string> GenerateAccountUpdateProfileBackgroundImageParam(
            string image, string title,
            bool? includeEntities, bool? skipStatus,
            bool? use)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();

            Utils.SetParam(param, "image", image);
            Utils.SetParam(param, "title", title);
            Utils.SetParam(param, "include_entities", includeEntities);
            Utils.SetParam(param, "skip_status", skipStatus);
            Utils.SetParam(param, "use", use);

            return param;
        }

        public TwitterUser AccountUpdateProfileBackgroundImage(
            string image = null, string title = null,
            bool? includeEntities = null, bool? skipStatus = null,
            bool? use = null)
        {
            var parameters = GenerateAccountUpdateProfileBackgroundImageParam(
                image, title,
                includeEntities, skipStatus,
                use);

            return JsonConvert.DeserializeObject<TwitterUser>(POST(Constants.AccountURL + "/update_profile_background_image.json", parameters));
        }

        async public Task<TwitterUser> AccountUpdateProfileBackgroundImageAsync(
            string image = null, string title = null,
            bool? includeEntities = null, bool? skipStatus = null,
            bool? use = null)
        {
            var parameters = GenerateAccountUpdateProfileBackgroundImageParam(
                image, title,
                includeEntities, skipStatus,
                use);

            return JsonConvert.DeserializeObject<TwitterUser>(await POSTasync(Constants.AccountURL + "/update_profile_background_image.json", parameters));
        }

        private IDictionary<string, string> GenerateAccountUpdateProfileImageParam(
            string image, bool? includeEntities, bool? skipStatus)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();

            Utils.SetParam(param, "image", image);
            Utils.SetParam(param, "include_entities", includeEntities);
            Utils.SetParam(param, "skip_status", skipStatus);

            return param;
        }

        public TwitterUser AccountUpdateProfileImage(
            string image = null, bool? includeEntities = null, bool? skipStatus = null)
        {
            var parameters = GenerateAccountUpdateProfileImageParam(
                image, includeEntities, skipStatus);

            return JsonConvert.DeserializeObject<TwitterUser>(POST(Constants.AccountURL + "/update_profile_image.json", parameters));
        }

        async public Task<TwitterUser> AccountUpdateProfileImageAsync(
            string image = null, bool? includeEntities = null, bool? skipStatus = null)
        {
            var parameters = GenerateAccountUpdateProfileImageParam(
                image, includeEntities, skipStatus);

            return JsonConvert.DeserializeObject<TwitterUser>(await POSTasync(Constants.AccountURL + "/update_profile_image.json", parameters));
        }

        public void AccountRemoveProfileBanner()
        {
            var parameters = new Dictionary<string, string>();

            POST(Constants.AccountURL + "/remove_profile_banner.json", parameters);
        }

        async public Task AccountRemoveProfileBannerAsync()
        {
            var parameters = new Dictionary<string, string>();

            await POSTasync(Constants.AccountURL + "/remove_profile_banner.json", parameters);
        }
        
        private IDictionary<string, string> GenerateAccountUpdateProfileBannerParam(
            Byte[] bannerData, IFile bannerFile, string bannerPath,
            UInt32? width, UInt32? height,
            UInt32? offsetLeft, UInt32? offsetRight)
        {
            Dictionary<string, string> param = new Dictionary<string,string>();

            string bannerImage = null;
            
            if (bannerPath != null)
            {
                var task = FileSystem.Current.GetFileFromPathAsync(bannerPath);
                task.Wait();
                bannerFile = task.Result;
            }

            if (bannerFile != null)
            {
                var streamTask = bannerFile.OpenAsync(FileAccess.Read);
                streamTask.Wait();
                var stream = streamTask.Result;

                BinaryReader reader = new BinaryReader(stream);
                bannerData = new Byte[stream.Length];
                reader.Read(bannerData, 0, (int)stream.Length);
            }

            if (bannerData == null || bannerData.Length != 0)
            {
                bannerImage = System.Convert.ToBase64String(bannerData);
            }

            if (bannerImage == null)
            {
                throw new ArgumentNullException("one of parameters(bannerData, bannerStream, bannerPath) should be not null");
            }

            param.Add("banner", bannerImage);
            Utils.SetParam(param, "width", width);
            Utils.SetParam(param, "height", height);
            Utils.SetParam(param, "offset_left", offsetLeft);
            Utils.SetParam(param, "offset_right", offsetRight);

            return param;
        }

        public void AccountUpdateProfileBanner(
            Byte[] bannerData = null, IFile bannerFile = null, string bannerPath = null,
            UInt32? width = null, UInt32? height = null,
            UInt32? offsetLeft = null, UInt32? offsetRight = null)
        {
            var parameters = GenerateAccountUpdateProfileBannerParam(
                bannerData, bannerFile, bannerPath,
                width, height,
                offsetLeft, offsetRight);

            POST(Constants.AccountURL + "/update_profile_banner.json", parameters);
        }

        async public Task AccountUpdateProfileBannerAsync(
            Byte[] bannerData = null, IFile bannerFile = null, string bannerPath = null,
            UInt32? width = null, UInt32? height = null,
            UInt32? offsetLeft = null, UInt32? offsetRight = null)
        {
            var parameters = GenerateAccountUpdateProfileBannerParam(
                bannerData, bannerFile, bannerPath,
                width, height,
                offsetLeft, offsetRight);

            await POSTasync(Constants.AccountURL + "/update_profile_banner.json", parameters);
        }
    }
}
