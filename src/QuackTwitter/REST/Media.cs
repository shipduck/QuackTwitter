using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuackTwitter
{
	partial class Twitter
	{
		public enum Media
		{
			Upload
		};

		public dynamic REST(Media type, Dictionary<String, String> parameters)
		{
			switch (type)
			{
				case Media.Upload:
					if (parameters.ContainsKey("media"))
					{
						return Post(Constants.MediaURL + "/upload.json", parameters);
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
