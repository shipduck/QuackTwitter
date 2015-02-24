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
			if (parameters.ContainsKey("trend_location_woe_id")
				|| parameters.ContainsKey("sleep_time_enabled")
				|| parameters.ContainsKey("start_sleep_time")
				|| parameters.ContainsKey("end_sleep_time")
				|| parameters.ContainsKey("time_zone")
				|| parameters.ContainsKey("lang"))
			{
				return JsonConvert.DeserializeObject<TwitterSettings>(POST(Constants.AccountURL + "settings.json", parameters));
			}
			else
			{
				throw new Exception();
			}
		}

		public TwitterUser AccountUpdateDeliveryDevice(Dictionary<string, string> parameters)
		{
			if (parameters.ContainsKey("device"))
			{
				return JsonConvert.DeserializeObject<TwitterUser>(POST(Constants.AccountURL + "/update_delivery_device.json", parameters));
			}
			else
			{
				throw new Exception();
			}
		}

		public TwitterUser AccountUpdateProfile(Dictionary<string, string> parameters)
		{
			if (parameters.ContainsKey("name")
				|| parameters.ContainsKey("url")
				|| parameters.ContainsKey("location")
				|| parameters.ContainsKey("description")
				|| parameters.ContainsKey("profile_link_color")
				|| parameters.ContainsKey("include_entities")
				|| parameters.ContainsKey("skip_status"))
			{
				return JsonConvert.DeserializeObject<TwitterUser>(POST(Constants.AccountURL + "/update_profile.json", parameters));
			}
			else
			{
				throw new Exception();
			}
		}

		public TwitterUser AccountUpdateProfileBackgroundImage(Dictionary<string, string> parameters)
		{
			if (parameters.ContainsKey("image"))
			{
				return JsonConvert.DeserializeObject<TwitterUser>(POST(Constants.AccountURL + "/update_profile_background_image.json", parameters));
			}
			else
			{
				throw new Exception();
			}
		}

		public TwitterUser AccountUpdateProfileImage(Dictionary<string, string> parameters)
		{
			if (parameters.ContainsKey("image"))
			{
				return JsonConvert.DeserializeObject<TwitterUser>(POST(Constants.AccountURL + "/update_profile_image.json", parameters));
			}
			else
			{
				throw new Exception();
			}
		}

		public void AccountRemoveProfileBanner(Dictionary<string, string> parameters = null)
		{
			POST(Constants.AccountURL + "/remove_profile_banner.json", parameters);
		}

		public void AccountUpdateProfileBanner(Dictionary<string, string> parameters)
		{
			if (parameters.ContainsKey("banner"))
			{
				POST(Constants.AccountURL + "/update_profile_banner.json", parameters);
			}
			else
			{
				throw new Exception();
			}
		}
	}
}
