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
    class AddcartDB:RealmObject
    {
        public string C_Name { get; set; }
        public string Id_cart { get; set; }
        public string namedata_cart { get; set; }
        public string pricedata_cart { get; set; }
        public string quantity_cart { get; set; }
        

    }
}