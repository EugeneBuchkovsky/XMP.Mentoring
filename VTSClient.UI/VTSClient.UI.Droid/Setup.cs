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
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Views;
using VTSClient.BusinessLogic.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.Platform;
using VTSClient.UI.Pages;
using MvvmCross.Forms.Presenter.Droid;

namespace VTSClient.UI.Droid
{
    class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext)
            : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new VTSClient.UI.App();
        }

        protected override IMvxAndroidViewPresenter CreateViewPresenter()
        {
            var presenter = new MvxFormsDroidPagePresenter();
            Mvx.RegisterSingleton<IMvxViewPresenter>(presenter);

            return presenter;
        }

        protected override void InitializeViewLookup()
        {
            base.InitializeViewLookup();

            var dict = new Dictionary<Type, Type>();
            dict.Add(typeof(AccountViewModel), typeof(LoginPage));

            dict.Add(typeof(VacationsViewModel), typeof(VacationsPage));

            dict.Add(typeof(SelectedVacationViewModel), typeof(VacationDetailsPage));

            var container = Mvx.Resolve<IMvxViewsContainer>();
            container.AddAll(dict);
        }
    }
}