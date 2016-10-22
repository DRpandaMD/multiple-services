using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.IO;

namespace StoreCheckInService
{
    public class XMLParser
    {
        XmlDocument doc;

        public XMLParser(string  filePath)
        {
            doc = new XmlDocument();
            doc.Load(filePath);
        }

        public List<Stores> getVisitedStoreListing()
        {


            XmlNodeList nodeList;
            XmlNode root = doc.DocumentElement;
            nodeList = root.SelectNodes("Store");

            List<Stores> storeList = new List<Stores>();
            foreach(XmlNode store in nodeList)
            {
                Stores aStore = new Stores();
                if(store.ChildNodes != null)
                {
                    aStore.storeName = "<b>" + store.SelectNodes("StoreName").ToString() + "</b>";
                    aStore.storeLocation = store.SelectNodes("StoreLocation").ToString();
                }
                storeList.Add(aStore);
            }
            return storeList;
        }

        public struct Stores
        {
            public string storeName;
            public string storeLocation;
            public bool hasCheckedIn;

            public string toString()
            {
                string storeStringOut = string.Format("Store Name: {0} \nStore Location: {1} \n\n", storeName, storeLocation);
                return storeStringOut;
            }
        }
    }
}