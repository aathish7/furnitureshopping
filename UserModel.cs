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

namespace Project
{

    public class UserModel
    {
        public String id;
        public String name;
        public String price;
        public String quantity;
        public int imageId;





        public UserModel()
        {
            id = "";
            name = "";
            price = "";
            quantity = "";
            
        }

        public UserModel(string idInfo, string nameInfo, string priceInfo, string quantInfo, int imageIdInfo)
        {
            id = idInfo;
            name = nameInfo;
            price = priceInfo;
            quantity = quantInfo;
            imageId = imageIdInfo;

        }
    }
}