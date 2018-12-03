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
    [Activity(Label = "registration")]
    public class registration : Activity
    {
        TextView name;
        TextView username;
        EditText email;
        EditText password;
        EditText phone;
        EditText bdate;
        Button register;
        Realm realmObj;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.registration);

            // Create your application here
            name = FindViewById<TextView>(Resource.Id.rname);
            username = FindViewById<TextView>(Resource.Id.runame);
            email = FindViewById<EditText>(Resource.Id.remail);
            password = FindViewById<EditText>(Resource.Id.rpass);
            phone = FindViewById<EditText>(Resource.Id.rphone);
            bdate = FindViewById<EditText>(Resource.Id.rdate);
            register = FindViewById<Button>(Resource.Id.rbtn);


            register.Click += delegate
            {
                realmObj = Realm.GetInstance();
                var user1 = new Users();
                user1.name = name.Text;
                user1.unamedata = username.Text;
                user1.emaildata = email.Text;
                user1.passdata = password.Text;
                user1.phndata = phone.Text;
                user1.bdatedata = bdate.Text;

                realmObj.Write(() =>
                {
                    realmObj.Add(user1);
                });

                var listOfUrs = realmObj.All<Users>();
                foreach (var temp in listOfUrs)
                {
                    System.Console.WriteLine(temp.name);
                    System.Console.WriteLine(temp.unamedata);
                    System.Console.WriteLine(temp.emaildata);
                    System.Console.WriteLine(temp.passdata);
                    System.Console.WriteLine(temp.phndata);
                    System.Console.WriteLine(temp.bdatedata);
                }

                Intent newScreen = new Intent(this, typeof(MainActivity));
                StartActivity(newScreen);

            };



        }
    }
}