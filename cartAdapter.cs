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
    class cartAdapter : BaseAdapter<UserModel>
    {

        List<UserModel> myUserListArray;
        Activity context;
        Realm deleeObjreal;

        public cartAdapter(Activity context, List<UserModel> modelList)
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
                view = context.LayoutInflater.Inflate(Resource.Layout.deletecart, null);
            }

            TextView idcart = view.FindViewById<TextView>(Resource.Id.prdid);
            idcart.Text = myUserModel.id; //.Text = myUserModel.id;
            string del = idcart.Text.ToString();
            view.FindViewById<TextView>(Resource.Id.prodname).Text = myUserModel.name;
            view.FindViewById<TextView>(Resource.Id.prodprice).Text = myUserModel.price;
            view.FindViewById<TextView>(Resource.Id.prodquant).Text = myUserModel.quantity;
            view.FindViewById<ImageView>(Resource.Id.imageId).SetImageResource(myUserModel.imageId);
            string incQuan = myUserModel.quantity.ToString();
            Button deleteCart =  view.FindViewById<Button>(Resource.Id.Delebtn);
            deleeObjreal = Realm.GetInstance();
            
            deleteCart.Click += delegate {
                
                var deletecart = new AddcartDB();
                  deletecart.C_Name = myUserModel.name.ToString();

                if (myUserModel.name.ToString() == deletecart.C_Name)
                {
                   var delecmd = deleeObjreal.All<AddcartDB>().First(b => b.Id_cart == myUserModel.id.ToString());
                    using (var temp = deleeObjreal.BeginWrite())
                    {
                        deleeObjreal.Remove(delecmd);
                        temp.Commit();
                    }
                    System.Console.WriteLine(deletecart.Id_cart+"333333333333");
                }
                var living1 = new livingroom();
                living1.quandata = incQuan;
                if (living1.quandata == incQuan)
                {
                    
                    int Inquan = Convert.ToInt16(incQuan) + 1;
                    living1.iddata = myUserModel.id.ToString();
                    living1.namedata = myUserModel.name.ToString();
                    living1.pricedata = myUserModel.price.ToString();
                    living1.quandata = Inquan.ToString();
                    deleeObjreal.Write(() => {

                        deleeObjreal.Add(living1, update: true);
                    });
                    
                    System.Console.WriteLine("********" + living1.quandata);
                }

                var KitchenObj = new kitchen();
                KitchenObj.quandata = incQuan;
                if (KitchenObj.quandata == incQuan)
                {
                     
                    int Inquan = Convert.ToInt16(incQuan) + 1;
                    KitchenObj.iddata = myUserModel.name.ToString();
                    KitchenObj.namedata = myUserModel.id.ToString();
                    KitchenObj.pricedata = myUserModel.price.ToString();
                    KitchenObj.quandata = Inquan.ToString();
                    deleeObjreal.Write(() => {

                        deleeObjreal.Add(KitchenObj, update: true);
                    });
                    
                    System.Console.WriteLine("********" + KitchenObj.quandata);
                }

                var bedroomObj = new bedroom();
                bedroomObj.quandata = incQuan;
                if (bedroomObj.quandata == incQuan)
                {

                    int Inquan = Convert.ToInt16(incQuan) + 1;
                    bedroomObj.iddata = myUserModel.name.ToString();
                    bedroomObj.namedata = myUserModel.id.ToString();
                    bedroomObj.pricedata = myUserModel.price.ToString();
                    bedroomObj.quandata = Inquan.ToString();
                    deleeObjreal.Write(() => {

                        deleeObjreal.Add(bedroomObj, update: true);
                    });

                    System.Console.WriteLine("********" + bedroomObj.quandata);
                }
                var dinningObj = new dinning();
                dinningObj.quandata = incQuan;
                if (dinningObj.quandata == incQuan)
                {

                    int Inquan = Convert.ToInt16(incQuan) + 1;
                    dinningObj.iddata = myUserModel.name.ToString();
                    dinningObj.namedata = myUserModel.id.ToString();
                    dinningObj.pricedata = myUserModel.price.ToString();
                    dinningObj.quandata = Inquan.ToString();
                    deleeObjreal.Write(() => {

                        deleeObjreal.Add(dinningObj, update: true);
                    });

                    System.Console.WriteLine("********" + dinningObj.quandata);
                }
                var outdoorObj = new outdoor();
                outdoorObj.quandata = incQuan;
                if (outdoorObj.quandata == incQuan)
                {

                    int Inquan = Convert.ToInt16(incQuan) + 1;
                    outdoorObj.iddata = myUserModel.name.ToString();
                    outdoorObj.namedata = myUserModel.id.ToString();
                    outdoorObj.pricedata = myUserModel.price.ToString();
                    outdoorObj.quandata = Inquan.ToString();
                    deleeObjreal.Write(() => {

                        deleeObjreal.Add(outdoorObj, update: true);
                    });

                    System.Console.WriteLine("********" + outdoorObj.quandata);
                }
                Toast.MakeText(context, "product deleted from cart successfully", ToastLength.Long).Show();
            };
        
            return view;
        }
    }
}