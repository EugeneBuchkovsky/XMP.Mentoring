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
using MvvmCross.Droid.FullFragging;
using VTSClient.UI.DroidNative.Tabs;

namespace VTSClient.UI.DroidNative.Views
{
    [Activity]
    [MvxViewFor(typeof(SubViewModel))]
    public class CreateVacationTabsView : MvxTabsFragmentActivity
    {
        public SubViewModel tabViewModel
        {
            get { return (SubViewModel)base.ViewModel; }
        }

        public CreateVacationTabsView() :
            base(Resource.Layout.CreateVacationTabView, Resource.Id.buttonLogon)
        { }

        protected override void AddTabs(Bundle args)
        {
            AddTab<CreateVacationFragment>("Tab1", "Tab1", args, tabViewModel.Tab1);
            AddTab<CreateVacationFragment>("Tab2", "Tab2", args, tabViewModel.Tab2);
        }
    }
}