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
using VTSClient.BusinessLogic.ViewModels;
using MvvmCross.Core.ViewModels;


namespace VTSClient.UI.DroidNative.Views
{
    [Activity(Label = "New vacation", MainLauncher = false)]
    [MvxViewFor(typeof(CreateVacationViewModel))]

    public class CreateVacationActivityTabsView : MvxTabActivity
    {
        protected CreateVacationViewModel CreateVacationViewModel
        {
            get { return base.ViewModel as CreateVacationViewModel; }
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.CreateVacationActivityView);

            TabHost.TabSpec spec;
            Intent intent;

            spec = TabHost.NewTabSpec("CreateRegularVacation");
            spec.SetIndicator("Regular");
            spec.SetContent(this.CreateIntentFor(CreateVacationViewModel.RegularVacation));
            TabHost.AddTab(spec);

            spec = TabHost.NewTabSpec("CreateSickLeave");
            spec.SetIndicator("Sick leave");
            spec.SetContent(this.CreateIntentFor(CreateVacationViewModel.SickLeave));
            TabHost.AddTab(spec);

            spec = TabHost.NewTabSpec("CreateOvertimeVacation");
            spec.SetIndicator("Overtime");
            spec.SetContent(this.CreateIntentFor(CreateVacationViewModel.Overtime));
            TabHost.AddTab(spec);
        }
    }
}