using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace StoreCheckInService
{
    public class XMLDataWriter
    {
        
        public void writeToXMLFile(Store store)
        {
            string fileLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"AppData"); //Remember: for LocalHost its "App_Data", but on the server its a <dir> "AppData"
            fileLocation = Path.Combine(fileLocation, "stores.xml");


            if (File.Exists(fileLocation))
            {
                XDocument doc = XDocument.Load(fileLocation);
                XElement newStore = doc.Element("Stores");
                newStore.Add(new XElement("Store",
                             new XElement("StoreName", store.storeName),
                             new XElement("StoreLocation", store.storeLocation),
                             new XElement("HasCheckedIn", store.hasCheckedIn.ToString())));
                doc.Save(fileLocation);
                 
            }
            else
            {
                using (XmlWriter writer = XmlWriter.Create(fileLocation))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Stores");
                    writer.WriteStartElement("Store");
                    //writer.WriteElementString("ID", store._id.ToString());
                    writer.WriteElementString("StoreName", store.storeName);
                    writer.WriteElementString("StoreLocation", store.storeLocation);
                    writer.WriteElementString("HasCheckedIn", store.hasCheckedIn.ToString());
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.WriteEndDocument();

                    //What happens if I have to append to a document?
                    
                }
            }
        }

    }

}