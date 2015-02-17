using DotNetOpenAuth.Messaging;
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
    class Twitter
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
            var response = consumer.Channel.WebRequestHandler.GetResponse(request);
            return ParseJson(response);
        }

        public dynamic Post(String url, Dictionary<String, String> parameters)
        {
            var request = consumer.PrepareAuthorizedRequest(new MessageReceivingEndpoint(url, HttpDeliveryMethods.PostRequest), Tokens.AccessToken, parameters);
            var response = consumer.Channel.WebRequestHandler.GetResponse(request);
            return ParseJson(response);
        }

        private static dynamic ParseJson(IncomingWebResponse response)
        {
            using (var stream = response.GetResponseReader())
            {
                return JValue.Parse(stream.ReadToEnd());
            }
        }

        public enum Statuses
        {
            MentionsTimeline,
            UserTimeline,
            HomeTimeline,
            RetweetsOfMe,
            Retweets,
            Show,
            Destroy,
            Update,
            Retweet,
            UpdateWithMedia,
            Oembed,
            Retweeters,
            Lookup
        };

        public dynamic REST(Statuses type, Dictionary<String, String> parameters)
        {
            switch (type)
            {
                case Statuses.MentionsTimeline:
                    return Get(Constants.StatusesUrl + "/mentions_timeline.json", parameters);
                case Statuses.UserTimeline:
                    return Get(Constants.StatusesUrl + "/user_timeline.json", parameters);
                case Statuses.HomeTimeline:
                    return Get(Constants.StatusesUrl + "/home_timeline.json", parameters);
                case Statuses.RetweetsOfMe:
                    return Get(Constants.StatusesUrl + "/retweets_of_me.json", parameters);
                case Statuses.Retweets:
                    if (parameters.ContainsKey("id"))
                    {
                        return Get(Constants.StatusesUrl + "/retweets/" + parameters["id"] + ".json", parameters);
                    }
                    else
                    {
                        throw new Exception();
                    }
                case Statuses.Show:
                    if (parameters.ContainsKey("id"))
                    {
                        return Get(Constants.StatusesUrl + "/show.json", parameters);
                    }
                    else
                    {
                        throw new Exception();
                    }
                case Statuses.Destroy:
                    if (parameters.ContainsKey("id"))
                    {
                        return Post(Constants.StatusesUrl + "/destroy/" + parameters["id"] + ".json", parameters);
                    }
                    else
                    {
                        throw new Exception();
                    }
                case Statuses.Update:
                    if (parameters.ContainsKey("status"))
                    {
                        return Post(Constants.StatusesUrl + "/update.json", parameters);
                    }
                    else
                    {
                        throw new Exception();
                    }
                case Statuses.Retweet:
                    if (parameters.ContainsKey("id"))
                    {
                        return Post(Constants.StatusesUrl + "/retweet/" + parameters["id"] + ".json", parameters);
                    }
                    else
                    {
                        throw new Exception();
                    }
                case Statuses.UpdateWithMedia:
                    throw new Exception();
                case Statuses.Oembed:
                    throw new Exception();
                case Statuses.Retweeters:
                    if (parameters.ContainsKey("id"))
                    {
                        return Get(Constants.StatusesUrl + "/retweeters/ids.json", parameters);
                    }
                    else
                    {
                        throw new Exception();
                    }
                case Statuses.Lookup:
                    if (parameters.ContainsKey("id"))
                    {
                        return Get(Constants.StatusesUrl + "/lookup.json", parameters);
                    }
                    else
                    {
                        throw new Exception();
                    }
                default:
                    throw new Exception();
            }
        }

        public enum Media
        {
            Upload
        };

        public dynamic REST(Media type, Dictionary<String, String> parameters)
        {
            switch (type)
            {
                case Media.Upload:
                    if (parameters.ContainsKey("media"))
                    {
                        return Post(Constants.MediaUrl + "/upload.json", parameters);
                    }
                    else
                    {
                        throw new Exception();
                    }
                default:
                    throw new Exception();
            }
        }

        public enum DirectMessages
        {
            Sent,
            Show,
            List,
            Destroy,
            New
        };

        public dynamic REST(DirectMessages type, Dictionary<String, String> parameters)
        {
            switch (type)
            {
                case DirectMessages.Sent:
                    return Get(Constants.DirectMessagesUrl + "/sent.json", parameters);
                case DirectMessages.Show:
                    if (parameters.ContainsKey("id"))
                    {
                        return Get(Constants.DirectMessagesUrl + "/show.json", parameters);
                    }
                    else
                    {
                        throw new Exception();
                    }
                case DirectMessages.List:
                    return Get(Constants.DirectMessagesUrl + ".json", parameters);
                case DirectMessages.Destroy:
                    if (parameters.ContainsKey("id"))
                    {
                        return Post(Constants.DirectMessagesUrl + "/destory.json", parameters);
                    }
                    else
                    {
                        throw new Exception();
                    }
                case DirectMessages.New:
                    if (parameters.ContainsKey("user_id") || parameters.ContainsKey("screen_name"))
                    {
                        return Post(Constants.DirectMessagesUrl + "/new.json", parameters);
                    }
                    else
                    {
                        throw new Exception();
                    }
                default:
                    throw new Exception();
            }
        }

        public enum Search
        {
            Tweets
        };

        public dynamic REST(Search type, Dictionary<String, String> parameters)
        {
            switch (type)
            {
                case Search.Tweets:
                    if (parameters.ContainsKey("q"))
                    {
                        return Get(Constants.SearchUrl + "/tweets.json", parameters);
                    }
                    else
                    {
                        throw new Exception();
                    }
                default:
                    throw new Exception();
            }
        }

        public enum Friendships
        {
            NoRetweets,
            Incoming,
            Outgoing,
            Create,
            Destroy,
            Update,
            Show,
            Lookup
        };

        public dynamic REST(Friendships type, Dictionary<String, String> parameters)
        {
            switch (type)
            {
                case Friendships.NoRetweets:
                    return Get(Constants.FriendshipsUrl + "/ids.json", parameters);
                case Friendships.Incoming:
                    return Get(Constants.FriendshipsUrl + "/incoming.json", parameters);
                case Friendships.Outgoing:
                    return Get(Constants.FriendshipsUrl + "/outgoing.json", parameters);
                case Friendships.Create:
                    if (parameters.ContainsKey("screen_name") || parameters.ContainsKey("user_id"))
                    {
                        return Post(Constants.FriendshipsUrl + "/create.json", parameters);
                    }
                    else
                    {
                        throw new Exception();
                    }
                case Friendships.Destroy:
                    if (parameters.ContainsKey("screen_name") || parameters.ContainsKey("user_id"))
                    {
                        return Post(Constants.FriendshipsUrl + "/destroy.json", parameters);
                    }
                    else
                    {
                        throw new Exception();
                    }
                case Friendships.Update:
                    if (parameters.ContainsKey("screen_name") || parameters.ContainsKey("user_id"))
                    {
                        return Post(Constants.FriendshipsUrl + "/update.json", parameters);
                    }
                    else
                    {
                        throw new Exception();
                    }
                case Friendships.Show:
                    if ((parameters.ContainsKey("source_id") || parameters.ContainsKey("source_screen_name")
                        && parameters.ContainsKey("target_id") || parameters.ContainsKey("target_screen_name")))
                    {
                        return Post(Constants.FriendshipsUrl + "/show.json", parameters);
                    }
                    else
                    {
                        throw new Exception();
                    }
                case Friendships.Lookup:
                    return Get(Constants.FriendshipsUrl + "/lookup.json", parameters);
                default:
                    throw new Exception();
            }
        }

        public enum Friends
        {
            Ids,
            List
        };

        public dynamic REST(Friends type, Dictionary<String, String> parameters)
        {
            switch (type)
            {
                case Friends.Ids:
                    if (parameters.ContainsKey("user_id") || parameters.ContainsKey("screen_name"))
                    {
                        return Get(Constants.FriendsUrl + "/ids.json", parameters);
                    }
                    else
                    {
                        throw new Exception();
                    }
                case Friends.List:
                    if (parameters.ContainsKey("user_id") || parameters.ContainsKey("screen_name"))
                    {
                        return Get(Constants.FriendsUrl + "/list.json", parameters);
                    }
                    else
                    {
                        throw new Exception();
                    }
                default:
                    throw new Exception();
            }
        }

        public enum Followers
        {
            Ids,
            List
        };

        public dynamic REST(Followers type, Dictionary<String, String> parameters)
        {
            switch (type)
            {
                case Followers.Ids:
                    if (parameters.ContainsKey("user_id") || parameters.ContainsKey("screen_name"))
                    {
                        return Get(Constants.FollowersUrl + "/ids.json", parameters);
                    }
                    else
                    {
                        throw new Exception();
                    }
                default:
                    throw new Exception();
            }
        }

        public enum Account
        {
            SettingsGet,
            VerifyCredentials,
            SettingsPost,
            UpdateDeliveryDevice,
            UpdateProfile,
            UpdateProfileBackgroundImage,
            UpdateProfileImage,
            RemoveProfileBanner,
            UpdateProfileBanner
        };

        public dynamic REST(Account type, Dictionary<String, String> parameters)
        {
            switch (type)
            {
                case Account.SettingsGet:
                    return Get(Constants.AccountUrl + "settings.json", parameters);
                case Account.VerifyCredentials:
                    return Get(Constants.AccountUrl + "verify_credentials.json", parameters);
                case Account.SettingsPost:
                    if (parameters.ContainsKey("trend_location_woe_id")
                        || parameters.ContainsKey("sleep_time_enabled")
                        || parameters.ContainsKey("start_sleep_time")
                        || parameters.ContainsKey("end_sleep_time")
                        || parameters.ContainsKey("time_zone")
                        || parameters.ContainsKey("lang"))
                    {
                        return Post(Constants.AccountUrl + "settings.json", parameters);
                    }
                    else
                    {
                        throw new Exception();
                    }
                case Account.UpdateDeliveryDevice:
                    if (parameters.ContainsKey("device"))
                    {
                        return Post(Constants.AccountUrl + "update_delivery_device.json", parameters);
                    }
                    else
                    {
                        throw new Exception();
                    }
                case Account.UpdateProfile:
                    if (parameters.ContainsKey("name")
                        || parameters.ContainsKey("url")
                        || parameters.ContainsKey("location")
                        || parameters.ContainsKey("description")
                        || parameters.ContainsKey("profile_link_color"))
                    {
                        return Post(Constants.AccountUrl + "update_profile.json", parameters);
                    }
                    else
                    {
                        throw new Exception();
                    }
                case Account.UpdateProfileBackgroundImage:
                    return Post(Constants.AccountUrl + "update_profile_background_image.json", parameters);
                case Account.UpdateProfileImage:
                    if (parameters.ContainsKey("image"))
                    {
                        return Post(Constants.AccountUrl + "update_profile_image.json", parameters);
                    }
                    else
                    {
                        throw new Exception();
                    }
                case Account.RemoveProfileBanner:
                    return Post(Constants.AccountUrl + "remove_profile_banner.json", parameters);
                case Account.UpdateProfileBanner:
                    if (parameters.ContainsKey("banner"))
                    {
                        return Post(Constants.AccountUrl + "update_profile_banner.json", parameters);
                    }
                    else
                    {
                        throw new Exception();
                    }
                default:
                    throw new Exception();
            }
        }

        public enum Blocks
        {
            List,
            Ids,
            Create,
            Destroy
        };

        public dynamic REST(Blocks type, Dictionary<String, String> parameters)
        {
            switch (type)
            {
                case Blocks.List:
                    return Get(Constants.BlocksUrl + "list.json", parameters);
                case Blocks.Ids:
                    return Get(Constants.BlocksUrl + "ids.json", parameters);
                case Blocks.Create:
                    if (parameters.ContainsKey("screen_name") || parameters.ContainsKey("user_id"))
                    {
                        return Post(Constants.BlocksUrl + "create.json", parameters);
                    }
                    else
                    {
                        throw new Exception();
                    }
                case Blocks.Destroy:
                    if (parameters.ContainsKey("screen_name") || parameters.ContainsKey("user_id"))
                    {
                        return Post(Constants.BlocksUrl + "destroy.json", parameters);
                    }
                    else
                    {
                        throw new Exception();
                    }
                default:
                    throw new Exception();
            }
        }

        public enum Users
        {
            Lookup,
            Show,
            Search,
            ProfileBanner,
            SuggestionsSlug,
            Suggestions,
            SuggestionsSlugMembers,
            ReportSpam
        };

        public dynamic REST(Users type, Dictionary<String, String> parameters)
        {
            switch (type)
            {
                case Users.Lookup:
                    return Get(Constants.UsersUrl + "lookup.json", parameters);
                case Users.Show:
                    if (parameters.ContainsKey("user_id") || parameters.ContainsKey("screen_name"))
                    {
                        return Get(Constants.UsersUrl + "show.json", parameters);
                    }
                    else
                    {
                        throw new Exception();
                    }
                case Users.Search:
                    if (parameters.ContainsKey("q"))
                    {
                        return Get(Constants.UsersUrl + "search.json", parameters);
                    }
                    else
                    {
                        throw new Exception();
                    }
                case Users.ProfileBanner:
                    if (parameters.ContainsKey("user_id")
                        || parameters.ContainsKey("screen_name"))
                    {
                        return Get(Constants.UsersUrl + "profile_banner.json", parameters);
                    }
                    else
                    {
                        throw new Exception();
                    }
                case Users.SuggestionsSlug:
                    if (parameters.ContainsKey("slug"))
                    {
                        return Get(Constants.UsersUrl + "suggestions/" + parameters["slug"] + ".json", parameters);
                    }
                    else
                    {
                        throw new Exception();
                    }
                case Users.Suggestions:
                    return Get(Constants.UsersUrl + "suggestions.json", parameters);
                case Users.SuggestionsSlugMembers:
                    return Get(Constants.UsersUrl + "suggestions/" + parameters["slug"] + "/members.json", parameters);
                case Users.ReportSpam:
                    return Post(Constants.UsersUrl + "report_spam.json", parameters);
                default:
                    throw new Exception();
            }
        }

        public enum Mutes
        {
            UsersCreate,
            UsersDestroy,
            UsersIds,
            UsersList
        };

        public dynamic REST(Mutes type, Dictionary<String, String> parameters)
        {
            switch (type)
            {
                case Mutes.UsersCreate:
                    if(parameters.ContainsKey("screen_name")
                        || parameters.ContainsKey("user_id"))
                    {
                        return Post(Constants.MutesUrl + "/users/create.json", parameters);
                    }
                    else
                    {
                        throw new Exception();
                    }
                case Mutes.UsersDestroy:
                    if(parameters.ContainsKey("screen_name")
                        || parameters.ContainsKey("usre_id"))
                    {
                        return Post(Constants.MutesUrl + "/users/destroy.json", parameters);
                    }
                    else
                    {
                        throw new Exception();
                    }
                case Mutes.UsersIds:
                    return Get(Constants.MutesUrl + "users/ids.json", parameters);
                case Mutes.UsersList:
                    return Get(Constants.MutesUrl + "usres/list.json", parameters);
                default:
                    throw new Exception();
            }
        }

        public enum Favorites
        {
            List,
            Destroy,
            Create
        };
        
        public dynamic REST(Favorites type, Dictionary<String, String> parameters)
        {
            switch (type)
            {
                case Favorites.List:
                    return Get(Constants.FavoritesUrl + "list.json", parameters);
                case Favorites.Destroy:
                    if (parameters.ContainsKey("id"))
                    {
                        return Post(Constants.FavoritesUrl + "destroy.json", parameters);
                    }
                    else
                    {
                        throw new Exception();
                    }
                case Favorites.Create:
                    if (parameters.ContainsKey("id"))
                    {
                        return Post(Constants.FavoritesUrl + "create.json", parameters);
                    }
                    else
                    {
                        throw new Exception();
                    }
                default:
                    throw new Exception();
            }
        }

        public enum Lists
        {
            List,
            Statuses,
            MembersDestroy,
            Memberships,
            Subscribers,
            SubscribersCreate,
            SubscribersShow,
            SubscribersDestroy,
            MembersCreateAll,
            MembersShow,
            Members,
            MembersCreate,
            Destroy,
            Update,
            Create,
            Show,
            Subscriptions,
            MembersDestroyAll,
            Ownerships
        };

        public dynamic REST(Lists type, Dictionary<String, String> parameters)
        {
            switch (type)
            {
                case Lists.List:
                    return Get(Constants.ListsUrl + "/list.json", parameters);
                case Lists.Statuses:
                    if (parameters.ContainsKey("list_id")
                        || (parameters.ContainsKey("slug")
                            && (parameters.ContainsKey("owner_screen_name")
                                || parameters.ContainsKey("owner_id"))))
                    {
                        return Get(Constants.ListsUrl + "/statuses.json", parameters);
                    }
                    else
                    {
                        throw new Exception();
                    }
                case Lists.MembersDestroy:
                    if(parameters.ContainsKey("list_id")
                        || (parameters.ContainsKey("slug")
                            && (parameters.ContainsKey("owner_screen_name")
                                || parameters.ContainsKey("owner_id"))))
                    {
                        return Post(Constants.ListsUrl + "/members/destroy.json", parameters);
                    }
                    else
                    {
                        throw new Exception();
                    }
                case Lists.Memberships:
                    if (parameters.ContainsKey("user_id") || parameters.ContainsKey("screen_name"))
                    {
                        return Get(Constants.ListsUrl + "/memberships.json", parameters);
                    }
                    else
                    {
                        throw new Exception();
                    }
                case Lists.Subscribers:
                    if (parameters.ContainsKey("list_id")
                        || (parameters.ContainsKey("slug")
                            && (parameters.ContainsKey("owner_screen_name")
                                || parameters.ContainsKey("owner_id"))))
                    {
                        return Get(Constants.ListsUrl + "/subscribers.json", parameters);
                    }
                    else
                    {
                        throw new Exception();
                    }
                case Lists.SubscribersCreate:
                    if (parameters.ContainsKey("list_id")
                        || (parameters.ContainsKey("slug")
                            && (parameters.ContainsKey("owner_screen_name")
                                || parameters.ContainsKey("owner_id"))))
                    {
                        return Get(Constants.ListsUrl + "/subscribers/create.json", parameters);
                    }
                    else
                    {
                        throw new Exception();
                    }
                case Lists.SubscribersShow:
                    if (parameters.ContainsKey("list_id")
                        || (parameters.ContainsKey("slug")
                            && (parameters.ContainsKey("owner_screen_name")
                                || parameters.ContainsKey("owner_id"))))
                    {
                        return Get(Constants.ListsUrl + "/subscribers/show.json", parameters);
                    }
                    else
                    {
                        throw new Exception();
                    }
                case Lists.SubscribersDestroy:
                    if (parameters.ContainsKey("list_id")
                        || (parameters.ContainsKey("slug")
                            && (parameters.ContainsKey("owner_screen_name")
                                || parameters.ContainsKey("owner_id"))))
                    {
                        return Get(Constants.ListsUrl + "/subscribers/destroy.json", parameters);
                    }
                    else
                    {
                        throw new Exception();
                    }
                case Lists.MembersCreateAll:
                    if (parameters.ContainsKey("list_id")
                        || (parameters.ContainsKey("slug")
                            && (parameters.ContainsKey("owner_screen_name")
                                || parameters.ContainsKey("owner_id"))))
                    {
                        return Get(Constants.ListsUrl + "/members/create_all.json", parameters);
                    }
                    else
                    {
                        throw new Exception();
                    }
                case Lists.MembersShow:
                    if (parameters.ContainsKey("list_id")
                        || (parameters.ContainsKey("slug")
                            && (parameters.ContainsKey("owner_screen_name")
                                || parameters.ContainsKey("owner_id"))))
                    {
                        return Get(Constants.ListsUrl + "/members/show.json", parameters);
                    }
                    else
                    {
                        throw new Exception();
                    }
                case Lists.Members:
                    if (parameters.ContainsKey("list_id")
                        || (parameters.ContainsKey("slug")
                            && (parameters.ContainsKey("owner_screen_name")
                                || parameters.ContainsKey("owner_id"))))
                    {
                        return Get(Constants.ListsUrl + "/members.json", parameters);
                    }
                    else
                    {
                        throw new Exception();
                    }
                case Lists.MembersCreate:
                    if (parameters.ContainsKey("list_id")
                        || (parameters.ContainsKey("slug")
                            && (parameters.ContainsKey("owner_screen_name")
                                || parameters.ContainsKey("owner_id"))))
                    {
                        return Get(Constants.ListsUrl + "/members/create.json", parameters);
                    }
                    else
                    {
                        throw new Exception();
                    }
                case Lists.Destroy:
                    if (parameters.ContainsKey("list_id")
                        || (parameters.ContainsKey("slug")
                            && (parameters.ContainsKey("owner_screen_name")
                                || parameters.ContainsKey("owner_id"))))
                    {
                        return Get(Constants.ListsUrl + "/destroy.json", parameters);
                    }
                    else
                    {
                        throw new Exception();
                    }
                case Lists.Update:
                    if (parameters.ContainsKey("list_id")
                        || (parameters.ContainsKey("slug")
                            && (parameters.ContainsKey("owner_screen_name")
                                || parameters.ContainsKey("owner_id"))))
                    {
                        return Get(Constants.ListsUrl + "/update.json", parameters);
                    }
                    else
                    {
                        throw new Exception();
                    }
                case Lists.Create:
                    if (parameters.ContainsKey("name"))
                    {
                        return Post(Constants.ListsUrl + "/create.json", parameters);
                    }
                    else
                    {
                        throw new Exception();
                    }
                case Lists.Show:
                    if (parameters.ContainsKey("list_id")
                        || (parameters.ContainsKey("slug")
                            && (parameters.ContainsKey("owner_screen_name")
                                || parameters.ContainsKey("owner_id"))))
                    {
                        return Get(Constants.ListsUrl + "/show.json", parameters);
                    }
                    else
                    {
                        throw new Exception();
                    }
                case Lists.Subscriptions:
                    if (parameters.ContainsKey("user_id") || parameters.ContainsKey("screen_name"))
                    {
                        return Get(Constants.ListsUrl + "/subscriptions.json", parameters);
                    }
                    else
                    {
                        throw new Exception();
                    }
                case Lists.MembersDestroyAll:
                    if (parameters.ContainsKey("list_id")
                        || (parameters.ContainsKey("slug")
                            && (parameters.ContainsKey("owner_screen_name")
                                || parameters.ContainsKey("owner_id"))))
                    {
                        return Get(Constants.ListsUrl + "/members/destroy_all.json", parameters);
                    }
                    else
                    {
                        throw new Exception();
                    }
                case Lists.Ownerships:
                    if (parameters.ContainsKey("user_id") || parameters.ContainsKey("screen_name"))
                    {
                        return Get(Constants.ListsUrl + "/ownerships.json", parameters);
                    }
                    else
                    {
                        throw new Exception();
                    }
                default:
                    throw new Exception();
            }
        }

        public enum SavedSearches
        {
            List,
            Show,
            Create,
            Destroy
        };

        public dynamic REST(SavedSearches type, Dictionary<String, String> parameters)
        {
            switch (type)
            {
                case SavedSearches.List:
                    return Get(Constants.SavedSearchesUrl + "/list.json", parameters);
                case SavedSearches.Show:
                    if (parameters.ContainsKey("id"))
                    {
                        return Get(Constants.SavedSearchesUrl + "/show/" + parameters["id"] + ".json", parameters);
                    }
                    else
                    {
                        throw new Exception();
                    }
                case SavedSearches.Create:
                    if (parameters.ContainsKey("query"))
                    {
                        return Post(Constants.SavedSearchesUrl + "/create.json", parameters);
                    }
                    else
                    {
                        throw new Exception();
                    }
                case SavedSearches.Destroy:
                    if (parameters.ContainsKey("id"))
                    {
                        return Post(Constants.SavedSearchesUrl + "/destroy/" + parameters["id"] + ".json", parameters);
                    }
                    else
                    {
                        throw new Exception();
                    }
                default:
                    throw new Exception();
            }
        }

        public enum Geo
        {
            Id,
            ReverseGeocode,
            Search
        };

        public dynamic REST(Geo type, Dictionary<String, String> parameters)
        {
            switch (type)
            {
                case Geo.Id:
                    if (parameters.ContainsKey("place_id"))
                    {
                        return Get(Constants.GeoUrl + "/id/" + parameters["place_id"] + ".json", parameters);
                    }
                    else
                    {
                        throw new Exception();
                    }
                case Geo.ReverseGeocode:
                    if (parameters.ContainsKey("lat") && parameters.ContainsKey("long"))
                    {
                        return Get(Constants.GeoUrl + "/reverse_geocode.json", parameters);
                    }
                    else
                    {
                        throw new Exception();
                    }
                case Geo.Search:
                    if((parameters.ContainsKey("lat") && parameters.ContainsKey("long"))
                        || parameters.ContainsKey("ip")
                        || parameters.ContainsKey("query")) {
                        return Get(Constants.GeoUrl + "/search.json", parameters);
                    }
                    else {
                        throw new Exception();
                    }
                default:
                    throw new Exception();
            }
        }

        public enum Trends
        {
            Place,
            Available,
            Closest
        };

        public dynamic REST(Trends type, Dictionary<String, String> parameters)
        {
            switch(type) {
                case Trends.Place:
                    if(parameters.ContainsKey("id")) {
                        return Get(Constants.TrendsUrl + "/place.json", parameters);
                    }
                    else {
                        throw new Exception();
                    }
                case Trends.Available:
                    return Get(Constants.TrendsUrl + "/available.json", parameters);
                case Trends.Closest:
                    if(parameters.ContainsKey("lat") && parameters.ContainsKey("long")) {
                        return Get(Constants.TrendsUrl + "/closest.json", parameters);
                    }
                    else {
                        throw new Exception();
                    }
                default:
                    throw new Exception();
            }
        }

        public enum Application
        {
            RateLimitStatus
        };

        public dynamic REST(Application type, Dictionary<String, String> parameters)
        {
            switch (type)
            {
                case Application.RateLimitStatus:
                    return Get(Constants.ApplicationUrl + "/rate_limit_status.json", parameters);
                default:
                    throw new Exception();
            }
        }

        public enum Help
        {
            Configuration,
            Languages,
            Privacy,
            Tos
        };

        public dynamic REST(Help type, Dictionary<String, String> parameters)
        {
            switch (type)
            {
                case Help.Configuration:
                    return Get(Constants.HelpUrl + "/configuration.json", parameters);
                case Help.Languages:
                    return Get(Constants.HelpUrl + "/languages.json", parameters);
                case Help.Privacy:
                    return Get(Constants.HelpUrl + "/privacy.json", parameters);
                case Help.Tos:
                    return Get(Constants.HelpUrl + "/tos.json", parameters);
                default:
                    throw new Exception();
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
