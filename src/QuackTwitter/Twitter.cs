using DotNetOpenAuth.Messaging;
using DotNetOpenAuth.OAuth;
using DotNetOpenAuth.OAuth.ChannelElements;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace QuackTwitter
{
    public partial class Twitter
    {
        private DesktopConsumer consumer;

        public void Authenticate()
        {
            var serviceProviderDescription = new ServiceProviderDescription
            {
                UserAuthorizationEndpoint = new MessageReceivingEndpoint(Constants.OAuthURL, HttpDeliveryMethods.GetRequest),
                TamperProtectionElements = new ITamperProtectionChannelBindingElement[] { new HmacSha1SigningBindingElement() },
                ProtocolVersion = ProtocolVersion.V10a,
            };

            var tokenManager = new TwitterTokenManager(Tokens.ConsumerKey, Tokens.ConsumerSecret, new Dictionary<string, string>() { { Tokens.AccessToken, Tokens.AccessTokenSecret } });
            consumer = new DesktopConsumer(serviceProviderDescription, tokenManager);
        }

        async public Task<string> GETasync(String url, IDictionary<String, String> parameters)
        {
            return await Task.Factory.StartNew<string>(() =>
            {
                return GET(url, parameters);
            });
        }

        public string GET(String url, IDictionary<String, String> parameters)
        {
            if (parameters == null)
            {
                parameters = new Dictionary<string, string>();
            }

            var request = consumer.PrepareAuthorizedRequest(new MessageReceivingEndpoint(url, HttpDeliveryMethods.GetRequest), Tokens.AccessToken, parameters);
            var response = consumer.Channel.WebRequestHandler.GetResponse(request, DirectWebRequestOptions.AcceptAllHttpResponses);
            return response.GetResponseReader().ReadToEnd();
        }

        async public Task<string> POSTasync(String url, IDictionary<String, String> parameters)
        {
            return await Task.Factory.StartNew<string>(() =>
            {
                return POST(url, parameters);
            });
        }

        public string POST(String url, IDictionary<String, String> parameters)
        {
            if (parameters == null)
            {
                parameters = new Dictionary<string, string>();
            }

            var request = consumer.PrepareAuthorizedRequest(new MessageReceivingEndpoint(url, HttpDeliveryMethods.PostRequest), Tokens.AccessToken, parameters);
            var response = consumer.Channel.WebRequestHandler.GetResponse(request, DirectWebRequestOptions.AcceptAllHttpResponses);
            return response.GetResponseReader().ReadToEnd();
        }

        public void CreateTimeline(Action<TwitterStatus> callback)
        {
            MessageReceivingEndpoint endpoint = new MessageReceivingEndpoint("https://userstream.twitter.com/2/user.json", HttpDeliveryMethods.PostRequest | HttpDeliveryMethods.AuthorizationHeaderRequest);

            var req = consumer.PrepareAuthorizedRequest(endpoint, Tokens.AccessToken);
            var resTask = req.GetResponseAsync();
            resTask.Wait();
            var res = resTask.Result;

            Stream st = res.GetResponseStream();
            var sr = new StreamReader(st);

            var task = new Task(() =>
                {
                    while(true)
                    {
                        var str = sr.ReadLine();
                        if(str == "")
                        {
                            continue;
                        }

                        var status = JsonConvert.DeserializeObject<TwitterStatus>(str);
                        if(status.Id != 0)
                        {
                            callback(status);
                        }
                    }
                });

            task.Start();
        }
    }

    public class TwitterTokenManager : IConsumerTokenManager
    {
        private Dictionary<string, string> _accessKey;

        public TwitterTokenManager(string consumerKey, string consumerSecret, Dictionary<string, string> accessKey)
        {
            ConsumerKey = consumerKey;
            ConsumerSecret = consumerSecret;
            _accessKey = accessKey;
        }

        public string ConsumerKey { get; private set; }

        public string ConsumerSecret { get; private set; }

        public void ExpireRequestTokenAndStoreNewAccessToken(
            string consumerKey, string requestToken, string accessToken, string accessTokenSecret)
        {
            throw new NotImplementedException();
        }

        public string GetTokenSecret(string token)
        {
            return _accessKey[token];
        }

        public TokenType GetTokenType(string token)
        {
            throw new NotImplementedException();
        }

        public void StoreNewRequestToken(DotNetOpenAuth.OAuth.Messages.UnauthorizedTokenRequest request,
                                            DotNetOpenAuth.OAuth.Messages.ITokenSecretContainingMessage response)
        {
            throw new NotImplementedException();
        }
    }
}
