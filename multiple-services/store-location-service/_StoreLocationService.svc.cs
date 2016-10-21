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

namespace store_location_service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "_StoreLocationService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select _StoreLocationService.svc or _StoreLocationService.svc.cs at the Solution Explorer and start debugging.
    public class _StoreLocationService : IStoreLocationService
    {
       public List<string>QueryYelpAPI(string term, string location)
        {
            //we want to make a new client connection
            var client = new YelpAPIClient();

            //get the response and put into a JSON Object
            JObject response = client.Search(term, location);

            JArray businesses = (JArray)response.GetValue("businesses");
            List<string> businessList = new List<string>();

            if (businesses.Count == 0)
            {
                throw new Exception(string.Format("No such bussinesses for {0} found in {1}", term, location));
            }

            for(int i = 0; i != businesses.Count; i++)
            {
                string business_id = (string)businesses[i]["id"];
                response = client.GetBusiness(business_id);
                
                businessList.Add(response.GetValue("name").ToString());
            }
            return businessList;
        }

    }
}
