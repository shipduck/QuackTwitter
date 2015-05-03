using DotNetOpenAuth.Messaging;
using DotNetOpenAuth.OAuth;
using DotNetOpenAuth.OAuth.ChannelElements;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace QuackTwitter
{
    public partial class Twitter
    {
        private DesktopConsumer consumer = null;

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

		async protected Task<StreamReader> ExecuteRequest(bool postRequest, String url, IDictionary<String, String> parameters)
		{
			if (parameters == null)
			{
				parameters = new Dictionary<string, string>();
			}

			HttpDeliveryMethods method = HttpDeliveryMethods.AuthorizationHeaderRequest;
			if (postRequest)
			{
				method |= HttpDeliveryMethods.PostRequest;
			}
			else
			{
				method |= HttpDeliveryMethods.GetRequest;
			}

			var request = consumer.PrepareAuthorizedRequest(new MessageReceivingEndpoint(url, method), Tokens.AccessToken, parameters);
            var response = consumer.Channel.WebRequestHandler.GetResponse(request, DirectWebRequestOptions.AcceptAllHttpResponses);
			return response.GetResponseReader();
		}

		async public Task<StreamReader> GETstream(String url, IDictionary<String, String> parameters)
		{
			return await ExecuteRequest(false, url, parameters);
		}

        async public Task<string> GETasync(String url, IDictionary<String, String> parameters)
        {
			StreamReader reader = await ExecuteRequest(false, url, parameters);
			return await reader.ReadToEndAsync();
        }

        public string GET(String url, IDictionary<String, String> parameters)
        {
			StreamReader reader = ExecuteRequest(false, url, parameters).Result;
			return reader.ReadToEnd();
        }

		async public Task<StreamReader> POSTstream(String url, IDictionary<String, String> parameters)
		{
			return await ExecuteRequest(true, url, parameters);
		}

        async public Task<string> POSTasync(String url, IDictionary<String, String> parameters)
        {
			StreamReader reader = await ExecuteRequest(true, url, parameters);
			return await reader.ReadToEndAsync();
        }

        public string POST(String url, IDictionary<String, String> parameters)
        {
			StreamReader reader = ExecuteRequest(true, url, parameters).Result;
			return reader.ReadToEnd();
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
