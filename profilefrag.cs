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
    public class profilefrag : Fragment
    {
        Realm profile;
        Activity viewprofile;
        public profilefrag(Activity viewprof)
        {
            viewprofile = viewprof;
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
            var userprofile = inflater.Inflate(Resource.Layout.myprofile, container, false);
            EditText uname = userprofile.FindViewById<EditText>(Resource.Id.ename);
            EditText username = userprofile.FindViewById<EditText>(Resource.Id.username);
            EditText email = userprofile.FindViewById<EditText>(Resource.Id.useremail);
            EditText password = userprofile.FindViewById<EditText>(Resource.Id.userpswd);
            EditText phone = userprofile.FindViewById<EditText>(Resource.Id.userphne);
            EditText dob = userprofile.FindViewById<EditText>(Resource.Id.userdob);
            //Button usbmit = userprofile.FindViewById<Button>(Resource.Id.rbtn);
            String usrnamedis = viewprofile.Intent.GetStringExtra("UsrNameDisplay");
            profile = Realm.GetInstance();
            var alluser = profile.All<Users>();
            
            foreach (var temp in alluser)
            {
                if (usrnamedis == temp.name)
                {
                    uname.Text= temp.name ;
                    username.Text=temp.unamedata;
                    email.Text=temp.emaildata ;
                    password.Text= temp.passdata  ;
                    phone.Text = temp.phndata  ;
                    dob.Text= temp.bdatedata  ;
                }
                    

            }
            
            /*usbmit.Click += delegate
            {
              //  var deletepro = new outdoor();
                alluser. = livid.Text;
                var delecmd = livdata.All<outdoor>().First(b => b.iddata == livid.Text);
                using (var temp = livdata.BeginWrite())
                {
                    livdata.Remove(delecmd);
                    temp.Commit();
                }
            
                Toast.MakeText(living_activity, "product is successfully deleted", ToastLength.Long).Show();

        };*/

            return userprofile;
        }
    }
}