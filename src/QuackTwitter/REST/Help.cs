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
		public TwitterConfiguration HelpConfiguration(Dictionary<string, string> parameters = null)
		{
			return JsonConvert.DeserializeObject<TwitterConfiguration>(GET(Constants.HelpURL + "/configuration.json", parameters));
		}

		public IList<TwitterLanguage> HelpLanguages(Dictionary<string, string> parameters = null)
		{
			return JsonConvert.DeserializeObject<IList<TwitterLanguage>>(GET(Constants.HelpURL + "/languages.json", parameters));
		}

		public TwitterPrivacy HelpPrivacy(Dictionary<string, string> parameters = null)
		{
			return JsonConvert.DeserializeObject<TwitterPrivacy>(GET(Constants.HelpURL + "/privacy.json", parameters));
		}

		public TwitterTOS HelpTOS(Dictionary<string, string> parameters = null)
		{
			return JsonConvert.DeserializeObject<TwitterTOS>(GET(Constants.HelpURL + "/tos.json", parameters));
		}
	}
}
