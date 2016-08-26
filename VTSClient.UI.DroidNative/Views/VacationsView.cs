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
    [Activity(Label = "Vacations", MainLauncher = false)]
    [MvxViewFor(typeof(VacationsViewModel))]
    public class VacationsView : MvxActivity
    {
        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.VacationsLayout);
        }
    }
}