using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Realms;


namespace Project
{
    class Users:RealmObject
    {
        [PrimaryKey]
        public string name { get; set; }
        public string unamedata { get; set; }
        public string emaildata { get; set; }
        public string passdata { get; set; }
        public string phndata { get; set; }
        public string bdatedata { get; set; }


    }
}