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
    [Activity(Label = "welcome")]
    public class welcome : Activity
    {
       /* ListView myListView;
        List<UserModel> listOfObjects = new List<UserModel>();*/
        Realm realmObjW;
        TextView displayUser;
        string c_name;



        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // and attach an event to it
            RequestWindowFeature(WindowFeatures.ActionBar);

            //enable navigation mode to support tab layout
            this.ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
            AddTab("View Products", new viewprdfrag(this));
            AddTab("My Cart", new viewcartfrag(this));
            AddTab("My Profile", new profilefrag(this));

            SetContentView(Resource.Layout.welcome);
            displayUser = FindViewById<TextView>(Resource.Id.hello);
            // Create your application here
            realmObjW = Realm.GetInstance();
            var userW = new Users();
            String usrnamedis = Intent.GetStringExtra("UsrNameDisplay");
            c_name = usrnamedis;
            displayUser.Text = "Hello " + usrnamedis;



            // Get our button from the layout resource,
           

        }
        void AddTab(string tabText, Fragment fragment)
        {
            var tab = this.ActionBar.NewTab();

            //tab.SetText(Resource.String.audioId);

            tab.SetCustomView(Resource.Layout.tablayout);
            
            tab.CustomView.FindViewById<TextView>(Resource.Id.tabText).Text = tabText;


            // must set event handler for replacing tabs tab
            tab.TabSelected += delegate (object sender, ActionBar.TabEventArgs e) {

                e.FragmentTransaction.Replace(Resource.Id.fragmentContainer, fragment);
            };

            this.ActionBar.AddTab(tab);
        }
    }
}