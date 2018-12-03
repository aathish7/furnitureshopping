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
    public class delprodfrag : Fragment
    {
        Realm livdata;
        ArrayAdapter myAdapter;
        Activity living_activity;
        string mycat;
        Spinner delspinner;
        string[] category = { "Living Room", "Kitchen", "Dinning", "Bedroom", "Outdoor Furniture" };
        public delprodfrag(Activity livact)
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
            var delproduct = inflater.Inflate(Resource.Layout.delprod, container, false);
            delspinner = delproduct.FindViewById<Spinner>(Resource.Id.spinner3);
            EditText livid = delproduct.FindViewById<EditText>(Resource.Id.delproid);

            Button livbtn = delproduct.FindViewById<Button>(Resource.Id.delprobtn);
            myAdapter = new ArrayAdapter(living_activity, Android.Resource.Layout.SimpleListItem1, category);

            delspinner.Adapter = myAdapter;
            delspinner.ItemSelected += spinnerClicked;
            livbtn.Click += delegate
            {
                if(mycat== "Living Room")
                {
                    livdata = Realm.GetInstance();
                    var deletepro = new livingroom();
                    deletepro.iddata = livid.Text;
                    var delecmd = livdata.All<livingroom>().First(b => b.iddata == livid.Text);
                    using (var temp = livdata.BeginWrite())
                    {
                        livdata.Remove(delecmd);
                        temp.Commit();
                    }
                }
                
                if (mycat == "Kitchen")
                {
                    livdata = Realm.GetInstance();
                    var deletepro = new kitchen();
                    deletepro.iddata = livid.Text;
                    var delecmd = livdata.All<kitchen>().First(b => b.iddata == livid.Text);
                    using (var temp = livdata.BeginWrite())
                    {
                        livdata.Remove(delecmd);
                        temp.Commit();
                    }
                }
                if (mycat == "Dinning")
                {
                    livdata = Realm.GetInstance();
                    var deletepro = new dinning();
                    deletepro.iddata = livid.Text;
                    var delecmd = livdata.All<dinning>().First(b => b.iddata == livid.Text);
                    using (var temp = livdata.BeginWrite())
                    {
                        livdata.Remove(delecmd);
                        temp.Commit();
                    }
                }
                if (mycat == "Bedroom")
                {
                    livdata = Realm.GetInstance();
                    var deletepro = new bedroom();
                    deletepro.iddata = livid.Text;
                    var delecmd = livdata.All<bedroom>().First(b => b.iddata == livid.Text);
                    using (var temp = livdata.BeginWrite())
                    {
                        livdata.Remove(delecmd);
                        temp.Commit();
                    }
                }
                if (mycat == "Outdoor Furniture")
                {
                    livdata = Realm.GetInstance();
                    var deletepro = new outdoor();
                    deletepro.iddata = livid.Text;
                    var delecmd = livdata.All<outdoor>().First(b => b.iddata == livid.Text);
                    using (var temp = livdata.BeginWrite())
                    {
                        livdata.Remove(delecmd);
                        temp.Commit();
                    }
                }
                Toast.MakeText(living_activity, "product is successfully deleted", ToastLength.Long).Show();

            };




            return delproduct;
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