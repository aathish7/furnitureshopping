using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Content;
using Realms;

namespace Project
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        TextView errmsg1;
        TextView errmsg2;
        EditText username;
        EditText password;
        Button loginb;
        TextView register;


        Realm dataval;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            // Create your application here
            errmsg1 = FindViewById<TextView>(Resource.Id.erruname);
            errmsg2 = FindViewById<TextView>(Resource.Id.errpswd);
            username = FindViewById<EditText>(Resource.Id.uname);
            password = FindViewById<EditText>(Resource.Id.passwd);
            loginb = FindViewById<Button>(Resource.Id.loginbtn);
            register = FindViewById<TextView>(Resource.Id.textView2);

            register.Click += delegate {

                Intent intent_Register = new Intent(this, typeof(registration));
                StartActivity(intent_Register);

            };


            loginb.Click += delegate
            {

                if (username.Text == "" && password.Text == "")
                {

                    errmsg1.Text = "Please Enter username and Password";
                }
                else
                {
                    if (username.Text == "")
                    {
                        errmsg1.Text = "Please Enter username";
                    }
                    else
                    if (password.Text == "")
                    {
                        errmsg2.Text = "Please Enter password.";
                    }
                    else
                    if (username.Text == "admin" && password.Text == "admin")
                    {
                        Intent newScreen = new Intent(this, typeof(admincat));
                        StartActivity(newScreen);
                    }
                    else
                    {
                        dataval = Realm.GetInstance();
                        var data = new Users();
                        var list = dataval.All<Users>();
                        foreach (var temp in list)
                        {
                            if (username.Text == temp.unamedata && password.Text == temp.passdata)
                            {
                                Intent intent_one = new Intent(this, typeof(welcome));
                                intent_one.PutExtra("UsrNameDisplay", temp.unamedata.ToString());
                                StartActivity(intent_one);
                            }
                            else if (username.Text != temp.unamedata || password.Text != temp.passdata)
                            {
                                errmsg1.Text = "wrong username or password.";
                            }
                        }
                    }




                }


            };
        }
    }
}
