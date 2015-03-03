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
        public IList<TwitterDirectMessage> DirectMessagesSent(IDictionary<string, string> parameters = null)
        {
            return JsonConvert.DeserializeObject<IList<TwitterDirectMessage>>(GET(Constants.DirectMessagesURL + "/sent.json", parameters));
        }

        async public Task<IList<TwitterDirectMessage>> DirectMessagesSentAsync(IDictionary<string, string> parameters = null)
        {
            return JsonConvert.DeserializeObject<IList<TwitterDirectMessage>>(await GETasync(Constants.DirectMessagesURL + "/sent.json", parameters));
        }

        public IList<TwitterDirectMessage> DirectMessagesShow(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "id");

            return JsonConvert.DeserializeObject<IList<TwitterDirectMessage>>(GET(Constants.DirectMessagesURL + "/show.json", parameters));
        }

        async public Task<IList<TwitterDirectMessage>> DirectMessagesShowAsync(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "id");

            return JsonConvert.DeserializeObject<IList<TwitterDirectMessage>>(await GETasync(Constants.DirectMessagesURL + "/show.json", parameters));
        }

        public IList<TwitterDirectMessage> DirectMessages(IDictionary<string, string> parameters = null)
        {
            return JsonConvert.DeserializeObject<IList<TwitterDirectMessage>>(GET(Constants.DirectMessagesURL + ".json", parameters));
        }

        async public Task<IList<TwitterDirectMessage>> DirectMessagesAsync(IDictionary<string, string> parameters = null)
        {
            return JsonConvert.DeserializeObject<IList<TwitterDirectMessage>>(await GETasync(Constants.DirectMessagesURL + ".json", parameters));
        }

        public TwitterDirectMessage DirectMessagesDestroy(IDictionary<string, string> parameters = null)
        {
            return JsonConvert.DeserializeObject<TwitterDirectMessage>(POST(Constants.DirectMessagesURL + "/destroy.json", parameters));
        }

        async public Task<TwitterDirectMessage> DirectMessagesDestroyAsync(IDictionary<string, string> parameters = null)
        {
            return JsonConvert.DeserializeObject<TwitterDirectMessage>(await POSTasync(Constants.DirectMessagesURL + "/destroy.json", parameters));
        }

        public TwitterDirectMessage DirectMessagesNew(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "text");

            return JsonConvert.DeserializeObject<TwitterDirectMessage>(POST(Constants.DirectMessagesURL + "/new.json", parameters));
        }

        async public Task<TwitterDirectMessage> DirectMessagesNewAsync(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "text");

            return JsonConvert.DeserializeObject<TwitterDirectMessage>(await POSTasync(Constants.DirectMessagesURL + "/new.json", parameters));
        }
    }
}
