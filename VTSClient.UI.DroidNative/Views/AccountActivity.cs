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
using MvvmCross.Core.ViewModels;
using VTSClient.BusinessLogic.ViewModels;

namespace VTSClient.UI.DroidNative.Views
{
    [Activity(Label = "Login", MainLauncher =true)]
    [MvxViewFor(typeof(AccountViewModel))]
    public class AccountActivity : MvxActivity
    {
        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.AccountLayout);
        }
    }
}