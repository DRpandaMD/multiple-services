﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreCheckInService
{
    public class Store
    {
        //public int _id;
        public string storeName;
        public string storeLocation;
        public bool hasCheckedIn;


        public Store(string name, string location)
        {
            //this._id = id;
            this.storeName = name;
            this.storeLocation = location;
            hasCheckedIn = true; //maybe i won't need this?
        }
    }

}