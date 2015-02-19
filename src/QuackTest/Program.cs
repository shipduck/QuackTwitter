using System;
using System.Collections.Generic;
using DotNetOpenAuth.Messaging;
using DotNetOpenAuth.OAuth;
using DotNetOpenAuth.OAuth.ChannelElements;
using Newtonsoft.Json;
using QuackTwitter;

namespace QuackTest
{
	class Program
	{
		static void Main(string[] args)
		{
			var twitter = new QuackTwitter.QuackTwitter();
			twitter.Authenticate();

			var parameters = new Dictionary<String, String>();
			parameters.Add("count", "2");
			IList<Status> json = twitter.Statuses.UserTimeline();
			foreach (Status tweet in json)
			{
				Console.WriteLine(tweet.Text);
			}

			Console.ReadLine();
		}
	}
}
