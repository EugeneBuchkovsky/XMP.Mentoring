using MvvmCross.Core.ViewModels;
using MvvmCross.Forms.Presenter.Core;
using MvvmCross.Forms.Presenter.iOS;
using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Views.Presenters;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;
using Xamarin.Forms;

using VTSClient.BusinessLogic.ViewModels;
using VTSClient.UI.Pages;
using MvvmCross.Platform;
using MvvmCross.Core.Views;
using VTSClient.DataAccess.Repositories;

namespace VTSClient.UI.iOS
{
    public class Setup : MvxIosSetup
    {
        public Setup(MvxApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
        {

        }

        protected override IMvxApplication CreateApp()
        {
            Mvx.RegisterType<ISQLite, SQLite_iOS>();
            return new App();
        }


        protected override IMvxIosViewPresenter CreatePresenter()
        {
            Forms.Init();

            var xamarinFormsApp = new MvxFormsApp();

            return new MvxFormsIosPagePresenter(Window, xamarinFormsApp);
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
