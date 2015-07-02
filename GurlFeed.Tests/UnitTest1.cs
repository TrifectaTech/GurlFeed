using System;
using System.Configuration;
using System.Globalization;
using InstaSharp;
using InstaSharp.Endpoints;
using InstaSharp.Models;
using InstaSharp.Models.Responses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Media = InstaSharp.Endpoints.Media;

namespace GurlFeed.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void InstaSharpGetTest()
        {
            UserInfo info = new UserInfo
            {
                Id = 1952620338,
                Username = "gurl_feed"
            };

            OAuthResponse response = new OAuthResponse
            {
                AccessToken = ConfigurationManager.AppSettings["AccessToken"],
                User = info
            };

            InstagramConfig config = new InstagramConfig(ConfigurationManager.AppSettings["ClientId"], ConfigurationManager.AppSettings["ClientSecret"]);

            Users users = new Users(config, response);

            UsersResponse userResponse = users.Search("yoventura", 1).Result;

            int userId = userResponse.Data[0].Id;

            MediasResponse medias = users.Recent(userId.ToString(CultureInfo.InvariantCulture), Int64.MaxValue.ToString(), Int64.MinValue.ToString(), int.MaxValue, null, null).Result;
            
        }
    }
}
