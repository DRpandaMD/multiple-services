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

namespace StoreRatingService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "StoreRatingService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select StoreRatingService.svc or StoreRatingService.svc.cs at the Solution Explorer and start debugging.
    public class StoreRatingService : IStoreRatingService
    {
        // Search First to get a list of IDs

        public List<string> QueryYelpAPI(string term, string location)
        {
            //we want to make a new client connection
            var client = new YelpAPIClient();

            //get the response and put into a JSON Object
            JObject response = client.Search(term, location);

            JArray businesses = (JArray)response.GetValue("businesses");
            List<BusinessInfo> businessList = new List<BusinessInfo>();


            if (businesses.Count == 0)
            {
                throw new Exception(string.Format("No such bussinesses for {0} found in {1}", term, location));
            }

            for (int i = 0; i != businesses.Count; i++)
            {
                //make a struct
                BusinessInfo newBusinessInfo = new BusinessInfo();
                // get the id
                string business_id = (string)businesses[i]["id"];
                //store the id
                newBusinessInfo.businessID = business_id; 
                //now we fetch the particulars
                response = client.GetBusiness(business_id);
                newBusinessInfo.name = response.GetValue("name").ToString();
                newBusinessInfo.name = response.GetValue("rating").ToString();
                businessList.Add(newBusinessInfo);
            
            }

            List<string> outputList = new List<string>();
            for(int i = 0; i != businessList.Count; i++)
            {
                outputList.Add(businessList[i].toString());
            }
            return outputList;
        }


        public struct BusinessInfo
        {
            public string name;
            public string businessID;
            public string rank;

            public string toString()
            {
                string infoOut = string.Format("Name: {0} \nBusinessID: {1} \nRank: {2}\n\n", name, businessID, rank);
                return infoOut;
            }
        }
    }
}
