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
using MvvmCross.Droid.FullFragging.Views;

namespace VTSClient.UI.DroidNative.Views
{
    [Activity(Label = "Login", MainLauncher = false)]
    public class VacationDetails : MvxActivity
    {
        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.VacationDetailsView);
            //SetContentView(Resource.Layout.VacationDetailsView);
            //SetContentView(Resource.Layout.CreatePageMain);

        }
    }
}