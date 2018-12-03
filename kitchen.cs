﻿using System;
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
    class kitchen : RealmObject
    {
        [PrimaryKey]
        public string iddata { get; set; }
        public string namedata { get; set; }
        public string pricedata { get; set; }
        public string quandata { get; set; }
    }
}