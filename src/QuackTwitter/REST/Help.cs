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
		public TwitterConfiguration HelpConfiguration(IDictionary<string, string> parameters = null)
		{
			return JsonConvert.DeserializeObject<TwitterConfiguration>(GET(Constants.HelpURL + "/configuration.json", parameters));
		}

        async public Task<TwitterConfiguration> HelpConfigurationAsync(IDictionary<string, string> parameters = null)
        {
            return JsonConvert.DeserializeObject<TwitterConfiguration>(await GETasync(Constants.HelpURL + "/configuration.json", parameters));
        }

		public IList<TwitterLanguage> HelpLanguages(IDictionary<string, string> parameters = null)
		{
			return JsonConvert.DeserializeObject<IList<TwitterLanguage>>(GET(Constants.HelpURL + "/languages.json", parameters));
		}

        async public Task<IList<TwitterLanguage>> HelpLanguagesAsync(IDictionary<string, string> parameters = null)
        {
            return JsonConvert.DeserializeObject<IList<TwitterLanguage>>(await GETasync(Constants.HelpURL + "/languages.json", parameters));
        }

		public TwitterPrivacy HelpPrivacy(IDictionary<string, string> parameters = null)
		{
			return JsonConvert.DeserializeObject<TwitterPrivacy>(GET(Constants.HelpURL + "/privacy.json", parameters));
		}

        async public Task<TwitterPrivacy> HelpPrivacyAsync(IDictionary<string, string> parameters = null)
        {
            return JsonConvert.DeserializeObject<TwitterPrivacy>(await GETasync(Constants.HelpURL + "/privacy.json", parameters));
        }

		public TwitterTOS HelpTOS(IDictionary<string, string> parameters = null)
		{
			return JsonConvert.DeserializeObject<TwitterTOS>(GET(Constants.HelpURL + "/tos.json", parameters));
		}

        async public Task<TwitterTOS> HelpTOSAsync(IDictionary<string, string> parameters = null)
        {
            return JsonConvert.DeserializeObject<TwitterTOS>(await GETasync(Constants.HelpURL + "/tos.json", parameters));
        }
	}
}
