using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuackTwitter
{
	partial class QuackTwitter
	{
		public enum Account
		{
			SettingsGet,
			VerifyCredentials,
			SettingsPost,
			UpdateDeliveryDevice,
			UpdateProfile,
			UpdateProfileBackgroundImage,
			UpdateProfileImage,
			RemoveProfileBanner,
			UpdateProfileBanner
		};

		public dynamic REST(Account type, Dictionary<String, String> parameters)
		{
			switch (type)
			{
				case Account.SettingsGet:
					return Get(Constants.AccountURL + "settings.json", parameters);
				case Account.VerifyCredentials:
					return Get(Constants.AccountURL + "verify_credentials.json", parameters);
				case Account.SettingsPost:
					if (parameters.ContainsKey("trend_location_woe_id")
						|| parameters.ContainsKey("sleep_time_enabled")
						|| parameters.ContainsKey("start_sleep_time")
						|| parameters.ContainsKey("end_sleep_time")
						|| parameters.ContainsKey("time_zone")
						|| parameters.ContainsKey("lang"))
					{
						return Post(Constants.AccountURL + "settings.json", parameters);
					}
					else
					{
						throw new Exception();
					}
				case Account.UpdateDeliveryDevice:
					if (parameters.ContainsKey("device"))
					{
						return Post(Constants.AccountURL + "update_delivery_device.json", parameters);
					}
					else
					{
						throw new Exception();
					}
				case Account.UpdateProfile:
					if (parameters.ContainsKey("name")
						|| parameters.ContainsKey("url")
						|| parameters.ContainsKey("location")
						|| parameters.ContainsKey("description")
						|| parameters.ContainsKey("profile_link_color"))
					{
						return Post(Constants.AccountURL + "update_profile.json", parameters);
					}
					else
					{
						throw new Exception();
					}
				case Account.UpdateProfileBackgroundImage:
					return Post(Constants.AccountURL + "update_profile_background_image.json", parameters);
				case Account.UpdateProfileImage:
					if (parameters.ContainsKey("image"))
					{
						return Post(Constants.AccountURL + "update_profile_image.json", parameters);
					}
					else
					{
						throw new Exception();
					}
				case Account.RemoveProfileBanner:
					return Post(Constants.AccountURL + "remove_profile_banner.json", parameters);
				case Account.UpdateProfileBanner:
					if (parameters.ContainsKey("banner"))
					{
						return Post(Constants.AccountURL + "update_profile_banner.json", parameters);
					}
					else
					{
						throw new Exception();
					}
				default:
					throw new Exception();
			}
		}
	}
}
