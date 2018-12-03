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
    [Activity(Label = "admincat")]
    public class admincat : Activity
    {
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RequestWindowFeature(WindowFeatures.ActionBar);

            //enable navigation mode to support tab layout
            this.ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
            AddTab("View Products", new viewprdfrag(this));
            AddTab("Add Products", new addprodfrag(this));
            AddTab("Delete Products", new delprodfrag(this));
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.admincat);


            // Get our button from the layout resource,
            // and attach an event to it

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
