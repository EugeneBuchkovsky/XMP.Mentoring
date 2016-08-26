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
using MvvmCross.Droid.Views;

namespace VTSClient.UI.NativeAndroid
{
    [Activity(Label = "Login", MainLauncher = false)]
    public class MainActivity : MvxActivity
    {
        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.LoginScreen);
        }
    }
}