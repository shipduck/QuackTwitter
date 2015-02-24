using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuackTwitter
{
	public class TwitterSearch
	{
		[JsonProperty("statuses")]
		public IList<TwitterStatus> Statuses { get; private set; }
		[JsonProperty("search_metadata")]
		public TwitterSearchMetadata SearchMetadata { get; private set; }

		public class TwitterSearchMetadata
		{
			[JsonProperty("completed_in")]
			public float CompletedIn { get; private set; }
			[JsonProperty("max_id")]
			public long MaxId { get; private set; }
			[JsonProperty("max_id_str")]
			public string MaxIdStr { get; private set; }
			[JsonProperty("next_results")]
			public string NextResults { get; private set; }
			[JsonProperty("query")]
			public string Query { get; private set; }
			[JsonProperty("refresh_url")]
			public string RefreshURL { get; private set; }
			[JsonProperty("count")]
			public int Count { get; private set; }
			[JsonProperty("since_id")]
			public long SinceId { get; private set; }
			[JsonProperty("since_id_str")]
			public string SinceIdStr { get; private set; }
		}
	}
}
