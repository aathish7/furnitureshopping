using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Realms;

namespace Project
{
    public class addprodfrag : Fragment
    {
        Realm livdata;
        ArrayAdapter myAdapter;
        Activity living_activity;
        string mycat;
        string[] category = { "Living Room", "Kitchen","Dinning", "Bedroom", "Outdoor Furniture" };
        public addprodfrag(Activity livact)
        {
            living_activity = livact;
        }
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

             base.OnCreateView(inflater, container, savedInstanceState);
            var productview = inflater.Inflate(Resource.Layout.addcat, container, false);
            Spinner livspinner = productview.FindViewById<Spinner>(Resource.Id.spinner1);
            EditText livid = productview.FindViewById<EditText>(Resource.Id.addproid);
            EditText livname = productview.FindViewById<EditText>(Resource.Id.addproname);
            EditText livprice = productview.FindViewById<EditText>(Resource.Id.addprice);
            EditText livquant = productview.FindViewById<EditText>(Resource.Id.addquant);
            Button livbtn = productview.FindViewById<Button>(Resource.Id.addcatbtn);
            myAdapter = new ArrayAdapter(living_activity, Android.Resource.Layout.SimpleListItem1, category);

            livspinner.Adapter = myAdapter;
            livspinner.ItemSelected+= spinnerClicked;

            livbtn.Click += delegate
            {
                if (mycat == "Living Room")
                {


                    livdata = Realm.GetInstance();
                    var living = new livingroom();
                    living.iddata = livid.Text;
                    living.namedata = livname.Text;
                    living.pricedata = livprice.Text;
                    living.quandata = livquant.Text;
                    livdata.Write(() =>
                    {
                        livdata.Add(living);
                    });
                    //System.Console.WriteLine(living.iddata);

                    var listOfprod = livdata.All<livingroom>();
                    foreach (var temp in listOfprod)
                    {
                        System.Console.WriteLine(temp.iddata);
                        System.Console.WriteLine(temp.namedata);
                        System.Console.WriteLine(temp.pricedata);
                        System.Console.WriteLine(temp.quandata);

                    }


                }
                if(mycat== "Kitchen")
                {
                    livdata = Realm.GetInstance();
                    var living = new kitchen();
                    living.iddata = livid.Text;
                    living.namedata = livname.Text;
                    living.pricedata = livprice.Text;
                    living.quandata = livquant.Text;
                    livdata.Write(() =>
                    {
                        livdata.Add(living);
                    });
                    //System.Console.WriteLine(living.iddata);

                    var listOfprod = livdata.All<kitchen>();
                    foreach (var temp in listOfprod)
                    {
                        System.Console.WriteLine(temp.iddata);
                        System.Console.WriteLine(temp.namedata);
                        System.Console.WriteLine(temp.pricedata);
                        System.Console.WriteLine(temp.quandata);

                    }

                }

                if (mycat == "Dinning")
                {
                    livdata = Realm.GetInstance();
                    var living = new dinning();
                    living.iddata = livid.Text;
                    living.namedata = livname.Text;
                    living.pricedata = livprice.Text;
                    living.quandata = livquant.Text;
                    livdata.Write(() =>
                    {
                        livdata.Add(living);
                    });
                    //System.Console.WriteLine(living.iddata);

                    var listOfprod = livdata.All<dinning>();
                    foreach (var temp in listOfprod)
                    {
                        System.Console.WriteLine(temp.iddata);
                        System.Console.WriteLine(temp.namedata);
                        System.Console.WriteLine(temp.pricedata);
                        System.Console.WriteLine(temp.quandata);

                    }

                }

                if (mycat == "Bedroom")
                {
                    livdata = Realm.GetInstance();
                    var living = new bedroom();
                    living.iddata = livid.Text;
                    living.namedata = livname.Text;
                    living.pricedata = livprice.Text;
                    living.quandata = livquant.Text;
                    livdata.Write(() =>
                    {
                        livdata.Add(living);
                    });
                    //System.Console.WriteLine(living.iddata);

                    var listOfprod = livdata.All<bedroom>();
                    foreach (var temp in listOfprod)
                    {
                        System.Console.WriteLine(temp.iddata);
                        System.Console.WriteLine(temp.namedata);
                        System.Console.WriteLine(temp.pricedata);
                        System.Console.WriteLine(temp.quandata);

                    }

                }

                if (mycat == "Outdoor Furniture")
                {
                    livdata = Realm.GetInstance();
                    var living = new outdoor();
                    living.iddata = livid.Text;
                    living.namedata = livname.Text;
                    living.pricedata = livprice.Text;
                    living.quandata = livquant.Text;
                    livdata.Write(() =>
                    {
                        livdata.Add(living);
                    });
                    //System.Console.WriteLine(living.iddata);

                    var listOfprod = livdata.All<outdoor>();
                    foreach (var temp in listOfprod)
                    {
                        System.Console.WriteLine(temp.iddata);
                        System.Console.WriteLine(temp.namedata);
                        System.Console.WriteLine(temp.pricedata);
                        System.Console.WriteLine(temp.quandata);

                    }

                }
                Toast.MakeText(living_activity, "product added successfully", ToastLength.Long).Show();

            };

            

            return productview;
        }
        public void spinnerClicked(object sender, AdapterView.ItemSelectedEventArgs e)
        {

            var indexClicked = e.Position;
            string myValue = category[indexClicked];
            System.Console.WriteLine("Position " + myValue);
            mycat = myValue;

        }
    }
}