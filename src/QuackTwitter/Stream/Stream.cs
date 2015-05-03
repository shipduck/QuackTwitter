using System;

namespace QuackTwitter
{
	partial class Twitter
	{
		private BaseStream userStream = null;

        public BaseStream GetUserStream()
        {
            if (userStream == null)
            {
                userStream = new BaseStream(this, Constants.UserStreamURL);

                userStream.beginReadStream();
            }

            return userStream;
        }
	}
}

