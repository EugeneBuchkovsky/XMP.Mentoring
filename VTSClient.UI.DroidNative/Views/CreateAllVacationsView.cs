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
using VTSClient.UI.DroidNative.Tabs;
using VTSClient.BusinessLogic.ViewModels;

using Android.Support.V4.App;
using MvvmCross.Core.ViewModels;

namespace VTSClient.UI.DroidNative.Views
{
    [Activity(Label = "Create", MainLauncher = false)]
    //[MvxViewFor(typeof(CreateVacationViewModel))]
    public class CreateAllVacationsView : MvxActivity 
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.CreatePageMain);

            var sub = (CreateVacationFragment)FragmentManager.FindFragmentById(Resource.Id.frag1);
            //sub.ViewModel = ((CreateVacationViewModel)ViewModel).Sub;
        }
    }
}