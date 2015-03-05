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
			var twitter = new Twitter();
			twitter.Authenticate();

			var parameters = new Dictionary<String, String>();
			parameters.Add("count", "3");
			var json = twitter.StatusesUserTimelineAsync(parameters);
			foreach (var tweet in json.Result)
			{
				Console.WriteLine(tweet.Text);
			}
            Console.WriteLine("url : ", twitter.AccountUpdateProfileAsync(url: "http://quaktwitter.com/quack").Result.URL);

			Console.ReadLine();
		}
	}
}
