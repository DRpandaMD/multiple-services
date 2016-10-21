using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreCheckInService
{
    public class Store
    {
        public int _id;
        public string storeName;
        public string storeLocation;
        public bool hasCheckedIn;


        public Store(int id, string name, string location, bool status)
        {
            this._id = id;
            this.storeName = name;
            this.storeLocation = location;
            hasCheckedIn = status; //maybe i won't need this?
        }
    }

}