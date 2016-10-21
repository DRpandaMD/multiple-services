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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IStoreLocationService" in both code and config file together.
    [ServiceContract]
    public interface IStoreLocationService
    {
        // TODO: Add your service operations here
        [OperationContract]
        List<string> QueryYelpAPI(string term, string location);

    }
}
