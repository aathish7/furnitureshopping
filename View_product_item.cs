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
    [Activity(Label = "View_product_item")]
    public class View_product_item : Activity
    {
        Realm view_proObj;
        string Id_view;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.ViewProduct_cart);
            TextView View_Cname = FindViewById<TextView>(Resource.Id.PV_Cname);
            TextView View_name = FindViewById<TextView>(Resource.Id.PV_name);
            TextView View_Price = FindViewById<TextView>(Resource.Id.PV_Price);
            TextView View_Quantity = FindViewById<TextView>(Resource.Id.PV_Quantity);
            //ImageView image = FindViewById<ImageView>(Resource.Id.imageId);
            Button View_btn = FindViewById<Button>(Resource.Id.PV_Btn);            
            String View_prod_id = Intent.GetStringExtra("Product_Id_view");
            String View_prod_Cname = Intent.GetStringExtra("Cust_name");
            View_Cname.Text = View_prod_Cname;
            
            view_proObj = Realm.GetInstance();
            var view_realObj = view_proObj.All<livingroom>();
            var view_realkObj = view_proObj.All<kitchen>();
            var view_realbObj = view_proObj.All<bedroom>();
            var view_realdObj = view_proObj.All<dinning>();
            var view_realoObj = view_proObj.All<outdoor>();
            foreach (var temp in view_realObj)
            {
                if (View_prod_id == temp.iddata)
                {
                    Id_view = temp.iddata;
                    View_name.Text = temp.namedata;
                    View_Price.Text = temp.pricedata;
                    View_Quantity.Text = temp.quandata;
                }
            }
            foreach (var temp in view_realkObj)
            {
                
                if (View_prod_id == temp.iddata)
                {
                    Id_view = temp.iddata;
                    View_name.Text = temp.namedata;
                    View_Price.Text = temp.pricedata;
                    View_Quantity.Text = temp.quandata;
                }
            }
            foreach (var temp in view_realbObj)
            {
                if (View_prod_id == temp.iddata)
                {
                    Id_view = temp.iddata;
                    View_name.Text = temp.namedata;
                    View_Price.Text = temp.pricedata;
                    View_Quantity.Text = temp.quandata;
                }
            }
            foreach (var temp in view_realdObj)
            {
                if (View_prod_id == temp.iddata)
                {
                    Id_view = temp.iddata;
                    View_name.Text = temp.namedata;
                    View_Price.Text = temp.pricedata;
                    View_Quantity.Text = temp.quandata;
                }
            }
            foreach (var temp in view_realoObj)
            {
                if (View_prod_id == temp.iddata)
                {
                    Id_view = temp.iddata;
                    View_name.Text = temp.namedata;
                    View_Price.Text = temp.pricedata;
                    View_Quantity.Text = temp.quandata;
                }
            }
            string quantity1 = View_Quantity.Text.ToString();
            int decquan = Convert.ToInt16(quantity1) - 1;
            View_btn.Click += delegate
            {
                var Add_cart_db = new AddcartDB();
                Add_cart_db.C_Name = View_Cname.Text;
                Add_cart_db.Id_cart = Id_view;
                Add_cart_db.namedata_cart = View_name.Text;
                Add_cart_db.pricedata_cart = View_Price.Text;
                Add_cart_db.quantity_cart = View_Quantity.Text;

                view_proObj.Write(()=> {

                    view_proObj.Add(Add_cart_db);
                });
                
               
                    
                    var alllist = view_proObj.All<AddcartDB>();
                
                foreach (var temp in alllist)
                {
                    Console.WriteLine(temp.C_Name);
                    Console.WriteLine(temp.Id_cart);
                    Console.WriteLine(temp.namedata_cart);
                    Console.WriteLine(temp.pricedata_cart);
                }

                System.Console.WriteLine("++++++"+ decquan);
                var DecLivingroom = new livingroom();
                DecLivingroom.iddata = Id_view;
                DecLivingroom.namedata = View_name.Text;
                DecLivingroom.pricedata = View_Price.Text;
                DecLivingroom.quandata = decquan.ToString();
                 view_proObj.Write(() => {

                     view_proObj.Add(DecLivingroom, update: true);
                 });
                System.Console.WriteLine("********" + DecLivingroom.quandata);
                var Deckitchen = new kitchen();
                Deckitchen.iddata = Id_view;
                Deckitchen.namedata = View_name.Text;
                Deckitchen.pricedata = View_Price.Text;
                Deckitchen.quandata = decquan.ToString();
                view_proObj.Write(() => {

                    view_proObj.Add(Deckitchen, update: true);
                });
                var Decbedroom = new bedroom();
                Decbedroom.iddata = Id_view;
                Decbedroom.namedata = View_name.Text;
                Decbedroom.pricedata = View_Price.Text;
                Decbedroom.quandata = decquan.ToString();
                view_proObj.Write(() => {

                    view_proObj.Add(Decbedroom, update: true);
                });
                var Decdinning = new dinning();
                Decdinning.iddata = Id_view;
                Decdinning.namedata = View_name.Text;
                Decdinning.pricedata = View_Price.Text;
                Decdinning.quandata = decquan.ToString();
                view_proObj.Write(() => {

                    view_proObj.Add(Decdinning, update: true);
                });
                var Decoutdoor = new outdoor();
                Decoutdoor.iddata = Id_view;
                Decoutdoor.namedata = View_name.Text;
                Decoutdoor.pricedata = View_Price.Text;
                Decoutdoor.quandata = decquan.ToString();
                view_proObj.Write(() => {

                    view_proObj.Add(Decoutdoor, update: true);
                });
                Toast.MakeText(this, "product added to cart successfully", ToastLength.Long).Show();
            };
        }
    }
}