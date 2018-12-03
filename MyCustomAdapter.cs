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
    public class MyCustomAdapter : BaseAdapter<UserModel>
    {
        List<UserModel> myUserListArray;
        Activity context;

        public MyCustomAdapter(Activity context, List<UserModel> modelList)
            : base()
        {
            this.context = context;
            this.myUserListArray = modelList;
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override UserModel this[int position]
        {
            get { return myUserListArray[position]; }
        }
        public override int Count
        {
            get { return myUserListArray.Count; }
        }


        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            //Get the UserModel Object using position
            var myUserModel = myUserListArray[position];

            View view = convertView;
            if (view == null)
            { // no view to re-use, create new
                view = context.LayoutInflater.Inflate(Resource.Layout.proddetail, null);
            }

            view.FindViewById<TextView>(Resource.Id.prdid).Text = myUserModel.id;
            view.FindViewById<TextView>(Resource.Id.prodname).Text = myUserModel.name;
            view.FindViewById<TextView>(Resource.Id.prodprice).Text = myUserModel.price;
            view.FindViewById<TextView>(Resource.Id.prodquant).Text = myUserModel.quantity;
            view.FindViewById<ImageView>(Resource.Id.imageId).SetImageResource(myUserModel.imageId);



            return view;
        }
    }
}