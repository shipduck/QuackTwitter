using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace QuackTwitter
{
	partial class Twitter
	{
		public class BaseStream
		{
			private Twitter twitter;
			private String url;
			private StreamReader reader;

			public event EventHandler<StreamEvent> StreamEventHandler;
			private Queue<TwitterStatus> statusQueue;

			internal BaseStream(Twitter twitter, String endpoint)
            {
                this.twitter = twitter;
				statusQueue = new Queue<TwitterStatus>();
				url = endpoint;
			}

			internal void beginReadStream()
			{
				Task.Factory.StartNew(this.readStream, new Dictionary<string, string>());
			}

			protected async void readStream(object state)
			{
				reader = await twitter.POSTstream(url, state as Dictionary<string, string>);

				String line = null;
				do
				{
					line = await reader.ReadLineAsync();
					if (line == null)
					{
						break;
					}
                    if (line == "")
                    {
                        continue;
                    }

					TwitterStatus status = JsonConvert.DeserializeObject<TwitterStatus>(line);

					if (status != null && status.Id != 0)
					{
						sendEvent(status);
					}
				}
				while(true);

				if (StreamEventHandler != null)
				{
					StreamEventHandler(this, new StreamEvent (
						StreamEvent.EventType.Closed,
						null));
				}
			}

			protected void sendEvent(TwitterStatus status)
			{
				if (StreamEventHandler == null)
				{
					statusQueue.Enqueue(status);
					return;
				}

				if (statusQueue.Count != 0)
				{
					StreamEventHandler(this, new StreamEvent(
						StreamEvent.EventType.Statuses,
						statusQueue.ToArray()));
					statusQueue.Clear();
				}

				StreamEventHandler(this, new StreamEvent(
					StreamEvent.EventType.Status,
					status));
			}
		}
	}
}

