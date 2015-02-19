using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuackTwitter
{
	public class _Ids : Cursor
	{
		[JsonProperty("ids")]
		public IList<long> Ids { get; private set; }
	}
}
