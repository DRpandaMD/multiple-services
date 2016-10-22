using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace StoreCheckInService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IStoreCheckInService" in both code and config file together.
    [ServiceContract]
    public interface IStoreCheckInService
    {
        [OperationContract]
        void CheckInToStore(string name, string location);

        [OperationContract]
        List<string> getListofStores();

    }
}
