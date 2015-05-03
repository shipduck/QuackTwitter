using System;
using System.Collections.Generic;
using DotNetOpenAuth.Messaging;
using DotNetOpenAuth.OAuth;
using DotNetOpenAuth.OAuth.ChannelElements;
using Newtonsoft.Json;
using QuackTwitter;
using System.IO;

namespace QuackTest
{
	class Program
	{
		static void Main(string[] args)
		{
			Twitter twitter = new Twitter();
			twitter.Authenticate();

            Twitter.BaseStream userStream = twitter.GetUserStream();

            userStream.StreamEventHandler += userStream_StreamEventHandler;

            Console.ReadLine();
		}

        static void userStream_StreamEventHandler(object sender, StreamEvent e)
        {
            TwitterStatus[] statuses = null;
            if (e.type == StreamEvent.EventType.Status)
            {
                statuses = new TwitterStatus[] { e.data as TwitterStatus };
            }
            else if (e.type == StreamEvent.EventType.Statuses )
            {
                statuses = e.data as TwitterStatus[];
            }

            foreach(TwitterStatus status in statuses)
            {   
                Console.WriteLine(String.Format("{0}({1})", status.User.ScreenName, ""));
                Console.WriteLine(String.Format("\t{0}", status.Text));
                Console.WriteLine("");
            }
            
        }
	}
}
