using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using System.Xml.Linq;
using static StoreCheckInService.XMLParser;

namespace StoreCheckInService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "_StoreCheckInService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select _StoreCheckInService.svc or _StoreCheckInService.svc.cs at the Solution Explorer and start debugging.
    public class _StoreCheckInService : IStoreCheckInService
    {

        public void CheckInToStore(string name, string location)
        {
            Store newStore = new Store(name, location);
            XMLDataWriter writer = new XMLDataWriter();
            writer.writeToXMLFile(newStore);
        }

        public List<string> getListofStores()
        {
            string fileLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data");
            fileLocation = Path.Combine(fileLocation, "stores.xml");

            XMLParser xmlParser = new XMLParser(fileLocation);
            List<Stores> storeStructListing = xmlParser.getVisitedStoreListing();
            List<string> storeList = new List<string>();
            
            for(int i = 0; i != storeStructListing.Count; i++)
            {
                storeList.Add(storeStructListing[i].toString());
            }

            return storeList;
        }
    }
}
