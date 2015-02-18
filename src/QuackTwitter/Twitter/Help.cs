using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuackTwitter
{
	partial class Twitter
	{
		public enum Help
		{
			Configuration,
			Languages,
			Privacy,
			Tos
		};

		public dynamic REST(Help type, Dictionary<String, String> parameters)
		{
			switch (type)
			{
				case Help.Configuration:
					return Get(Constants.HelpUrl + "/configuration.json", parameters);
				case Help.Languages:
					return Get(Constants.HelpUrl + "/languages.json", parameters);
				case Help.Privacy:
					return Get(Constants.HelpUrl + "/privacy.json", parameters);
				case Help.Tos:
					return Get(Constants.HelpUrl + "/tos.json", parameters);
				default:
					throw new Exception();
			}
		}
	}
}
