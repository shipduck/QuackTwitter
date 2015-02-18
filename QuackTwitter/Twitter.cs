﻿using DotNetOpenAuth.Messaging;
using DotNetOpenAuth.OAuth;
using DotNetOpenAuth.OAuth.ChannelElements;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuackTwitter
{
	partial class Twitter
	{
		private DesktopConsumer consumer;

		public void Authenticate()
		{
			var serviceProviderDescription = new ServiceProviderDescription
			{
				UserAuthorizationEndpoint = new MessageReceivingEndpoint(Constants.OAuthUrl, HttpDeliveryMethods.GetRequest),
				TamperProtectionElements = new ITamperProtectionChannelBindingElement[] { new HmacSha1SigningBindingElement() },
				ProtocolVersion = ProtocolVersion.V10a,
			};

			var tokenManager = new TwitterTokenManager(Tokens.ConsumerKey, Tokens.ConsumerSecret, new Dictionary<string, string>() { { Tokens.AccessToken, Tokens.AccessTokenSecret } });
			consumer = new DesktopConsumer(serviceProviderDescription, tokenManager);
		}

		public dynamic Get(String url, Dictionary<String, String> parameters)
		{
			var request = consumer.PrepareAuthorizedRequest(new MessageReceivingEndpoint(url, HttpDeliveryMethods.GetRequest), Tokens.AccessToken, parameters);
			var response = consumer.Channel.WebRequestHandler.GetResponse(request, DirectWebRequestOptions.AcceptAllHttpResponses);
			return ParseJson(response);
		}

		public dynamic Post(String url, Dictionary<String, String> parameters)
		{
			var request = consumer.PrepareAuthorizedRequest(new MessageReceivingEndpoint(url, HttpDeliveryMethods.PostRequest), Tokens.AccessToken, parameters);
			var response = consumer.Channel.WebRequestHandler.GetResponse(request, DirectWebRequestOptions.AcceptAllHttpResponses);
			return ParseJson(response);
		}

		private static dynamic ParseJson(IncomingWebResponse response)
		{
			using (var stream = response.GetResponseReader())
			{
				return JValue.Parse(stream.ReadToEnd());
			}
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
