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
		public TwitterMedia MediaUpload(Dictionary<string, string> parameters)
		{
			if (parameters.ContainsKey("media"))
			{
				return JsonConvert.DeserializeObject<TwitterMedia>(POST(Constants.MediaURL + "/upload.json", parameters));
			}
			else {
				throw new Exception();
			}
		}
	}
}
