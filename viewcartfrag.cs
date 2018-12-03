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
    public class viewcartfrag : Fragment
    {
        ListView myListView;
        
        Realm realmviewOjb;
        ArrayAdapter myArrayAdapter;
        SearchView mySearchBar;
        Activity living_activity;
        List<UserModel> listOfObjects = new List<UserModel>();
        List<UserModel> tempList = new List<UserModel>();
        public viewcartfrag(Activity livact)
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
            
            var cartview = inflater.Inflate(Resource.Layout.viewprod, container, false);
            myListView = cartview.FindViewById<ListView>(Resource.Id.prodlist);
            mySearchBar = cartview.FindViewById<SearchView>(Resource.Id.searchId);


            realmviewOjb = Realm.GetInstance();
          //  var myAdapter = new cartAdapter(living_activity, listOfObjects);
            var allprod = realmviewOjb.All<AddcartDB>();
            listOfObjects.Clear();
            mySearchBar.QueryTextChange += searchBarText;
            foreach (var list in allprod)
            {
                
                var obj = new UserModel(list.Id_cart, list.namedata_cart, list.pricedata_cart,list.quantity_cart,Resource.Drawable.living);
                listOfObjects.Add(obj);
                var myAdapter1 = new cartAdapter(living_activity, listOfObjects);
                myListView.SetAdapter(myAdapter1);
                System.Console.WriteLine(list.C_Name.ToString(), list.Id_cart.ToString(), list.namedata_cart.ToString(), list.pricedata_cart.ToString());
            }

            return cartview;
        }
        public void searchBarText(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            var myFiltereList = filterMyModel(e.NewText);

            myListView.SetAdapter(new MyCustomAdapter(living_activity, myFiltereList));
        }

        private List<UserModel> filterMyModel(string text)
        {

            List<UserModel> mySearchList = new List<UserModel>();

            foreach (var modelValue in listOfObjects)
            {
                if (modelValue.name.ToLower().Contains(text.ToLower()))
                {
                    mySearchList.Add(modelValue);

                }
            }

            return mySearchList;
        }
    }
}