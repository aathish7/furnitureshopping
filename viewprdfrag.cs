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
    public class viewprdfrag : Fragment
    {
        ListView myListView;
        Spinner prodspinner;
        Realm realmviewOjb;
        ArrayAdapter myArrayAdapter;
        Activity living_activity;
        string mycat;
        string cuname;
        SearchView mySearchBar;


        List<UserModel> listOfObjects = new List<UserModel>();
        List<UserModel> tempList = new List<UserModel>();
        string[] category = { "Living Room", "Kitchen", "Dinning", "Bedroom", "Outdoor Furniture" };
        public viewprdfrag(Activity livact)
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
            var productview = inflater.Inflate(Resource.Layout.viewprod, container, false);
            myListView = productview.FindViewById<ListView>(Resource.Id.prodlist);
            prodspinner = productview.FindViewById<Spinner>(Resource.Id.spinner2);
            mySearchBar = productview.FindViewById<SearchView>(Resource.Id.searchId);
            String View_prod_Cname = living_activity.Intent.GetStringExtra("UsrNameDisplay");
            cuname = View_prod_Cname;
            realmviewOjb = Realm.GetInstance();
            listOfObjects.Clear();

            var myAdapter = new MyCustomAdapter(living_activity, listOfObjects);
            myArrayAdapter = new ArrayAdapter(living_activity, Android.Resource.Layout.SimpleListItem1, category);
           

            prodspinner.Adapter = myArrayAdapter;
            listOfObjects.Clear();

            prodspinner.ItemSelected += spinnerClicked;
            myListView.ItemClick += listviewClick;
           mySearchBar.QueryTextChange += searchBarText;


            //Adapter ??

            myListView.SetAdapter(myAdapter);

            return productview;
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
        public void spinnerClicked(object sender, AdapterView.ItemSelectedEventArgs e)
        {

            var indexClicked = e.Position;
            string myValue = category[indexClicked];
            System.Console.WriteLine("Position " + myValue);
            mycat = myValue;
            listOfObjects.Clear();
            if (myValue == "Living Room")
            {
                var allprod = realmviewOjb.All<livingroom>();
                foreach (var list in allprod)
                {
                    
                    var obj = new UserModel(list.iddata, list.namedata, list.pricedata, list.quandata,Resource.Drawable.living);
                    listOfObjects.Add(obj);
                    var myAdapter1 = new MyCustomAdapter(living_activity,listOfObjects);
                    myListView.SetAdapter(myAdapter1);
                }


            }
            if (myValue == "Kitchen")
            {
                
                var allprod = realmviewOjb.All<kitchen>();
                foreach (var list in allprod)
                {
                    var obj = new UserModel(list.iddata, list.namedata, list.pricedata, list.quandata, Resource.Drawable.kitchen);
                    listOfObjects.Add(obj);
                    var myAdapter1 = new MyCustomAdapter(living_activity, listOfObjects);
                    myListView.SetAdapter(myAdapter1);
                }


            }
            if (myValue == "Dinning")
            {
                
                var allprod = realmviewOjb.All<dinning>();
                foreach (var list in allprod)
                {
                    var obj = new UserModel(list.iddata, list.namedata, list.pricedata, list.quandata, Resource.Drawable.dinning);
                    listOfObjects.Add(obj);
                    var myAdapter1 = new MyCustomAdapter(living_activity, listOfObjects);
                    myListView.SetAdapter(myAdapter1);
                }


            }

            if (myValue == "Bedroom")
            {
                
                var allprod = realmviewOjb.All<bedroom>();
                foreach (var list in allprod)
                {
                    var obj = new UserModel(list.iddata, list.namedata, list.pricedata, list.quandata, Resource.Drawable.bedroom);
                    listOfObjects.Add(obj);
                    var myAdapter1 = new MyCustomAdapter(living_activity, listOfObjects);
                    myListView.SetAdapter(myAdapter1);
                }


            }
            if (myValue == "Outdoor Furniture")
            {
               
                var allprod = realmviewOjb.All<outdoor>();
                foreach (var list in allprod)
                {
                    var obj = new UserModel(list.iddata, list.namedata, list.pricedata, list.quandata, Resource.Drawable.outdoor);
                    listOfObjects.Add(obj);
                    var myAdapter1 = new MyCustomAdapter(living_activity, listOfObjects);
                    myListView.SetAdapter(myAdapter1);
                }


            }
        }
        public void listviewClick(Object sender, AdapterView.ItemClickEventArgs e)
        {
            var itemposition = listOfObjects[e.Position];
            Console.WriteLine("***********" + itemposition.id);
            Intent start_intent_viewpro = new Intent(living_activity,typeof(View_product_item));
            start_intent_viewpro.PutExtra("Product_Id_view", itemposition.id.ToString());
            start_intent_viewpro.PutExtra("Cust_name", cuname);

            // start_intent_viewpro.PutExtra("Cust_name", cname);
            StartActivity(start_intent_viewpro);
        }
    }
}