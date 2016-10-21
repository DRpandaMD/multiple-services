using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace StoreCheckInService
{
    public class XMLDataWriter
    {
        
        public void writeToXMLFile(Store store)
        {
            using (XmlWriter writer = XmlWriter.Create("stores.xml"))
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