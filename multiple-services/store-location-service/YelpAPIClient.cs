using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Xml;
using System.IO;
using SimpleOAuth;
using System.Net;
using DotNetOpenAuth.OAuth2;

namespace store_location_service
{
    public class YelpAPIClient
    {
        /* 
         * Author: Michael Zarate
         * source assistance files and documentation for this api: https://github.com/Yelp/yelp-api 
         * 
         */


        //Following the example documentaion I created a list of required request statics
        // These are unique to me so please be kind.
        private const string CONSUMER_KEY = "V8rA6dsNgOuan8_ZhFaNOA";
        private const string CONSUMER_SECRET = "SPvESbvXi1-Bdx4iu3lkPBDyOu0";
        private const string TOKEN = "IIsgHqj8GIcoj5iTsevsa8eLqc8aK1cM";
        private const string TOKEN_SECRET = "bvfa17jkcFVY7y-ZkAzbFk3o9gQ";
        private const string API_HOST = "https://api.yelp.com";
        private const string SEARCH_PATH = "/v2/search/";
        private const string BUSINESS_PATH = "/v2/business/";
        private const int SEARCH_LIMIT = 5;

        

        //We need to make a JSON object to perfom the reques
        private JObject PerformRequest(string baseURL, Dictionary<string,string> queryParams = null)
        {
            var query = System.Web.HttpUtility.ParseQueryString(String.Empty);

            if(queryParams == null)
            {
                queryParams = new Dictionary<string, string>();
            }

            foreach(var queryParam in queryParams)
            {
                query[queryParam.Key] = queryParam.Value;
            }

            var uriBuilder = new UriBuilder(baseURL);
            uriBuilder.Query = query.ToString();

            var request = WebRequest.Create(uriBuilder.ToString());
            request.Method = "GET";

            request.SignRequest(
                new Tokens
                {
                    ConsumerKey = CONSUMER_KEY,
                    ConsumerSecret = CONSUMER_SECRET,
                    AccessToken = TOKEN,
                    AccessTokenSecret = TOKEN_SECRET
                }).WithEncryption(EncryptionMethod.HMACSHA1).InHeader();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            var stream = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            return JObject.Parse(stream.ReadToEnd());
        }

        public JObject Search(string term, string location)
        {
            string baseURL = API_HOST + SEARCH_PATH;
            var queryParams = new Dictionary<string, string>()
            {
                {"term", term },
                {"location", location },
                {"limit", SEARCH_LIMIT.ToString() }
            };
            return PerformRequest(baseURL, queryParams);
        }

        public JObject GetBusiness(string business_id)
        {
            string baseURL = API_HOST + BUSINESS_PATH + business_id;
            return PerformRequest(baseURL);
        }
    }
}