using MvvmCross.iOS.Platform;
using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross.Core.ViewModels;
using UIKit;
using VTSClient.BusinessLogic.ViewModels;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.Platform;
using VTSClient.BusinessLogic;
using VTSClient.DataAccess.Repositories;
using VTSClient.BusinessLogic.Services.Interfaces;
using VTSClient.BusinessLogic.Services.Instances;
using VTSClient.DataAccess.WebServices.Interfaces;
using VTSClient.DataAccess.WebServices.Services;
using VTSClient.UI.iOSNative.Views;
using MvvmCross.Core.Views;
using VtsMockClient.Domain.Models;
using VTSClient.BusinessLogic.ViewModels.CreateTabViewModel;
using VTSClient.UI.iOSNative.Views.Tabs;

namespace VTSClient.UI.iOSNative
{
    public class Setup : MvxIosSetup
    {
        public Setup(MvxApplicationDelegate applicationDelegate, IMvxIosViewPresenter presenter)
            : base(applicationDelegate, presenter)
        {

        }

        protected override IMvxApplication CreateApp()
        {
            Mvx.RegisterType<ISQLite, SQLite_iOS>();
            Mvx.RegisterType<IAccountService, AccountService>();
            Mvx.RegisterType<IWEB, LoginWebService>();
            Mvx.RegisterType<IVacationsService, VacationsService>();
            Mvx.RegisterType<IVacationsWebService, VacationsWebService>();
            return new App();
        }


        protected override void InitializeViewLookup()
        {
            base.InitializeViewLookup();

            var dict = new Dictionary<Type, Type>();
            //dict.Add(typeof(AccountViewModel), typeof(LoginPage));

            //dict.Add(typeof(VacationsViewModel), typeof(VacationsPage));

            dict.Add(typeof(SelectedVacationViewModel), typeof(VacationDetailsView));
            dict.Add(typeof(CreateVacationViewModel), typeof(CreateVacationTabsView));
            dict.Add(typeof(CreateRegularVacationViewModel), typeof(CreateRegularVacationView));
            dict.Add(typeof(CreateSickLeaveViewModel), typeof(CreateSickLeaveView));
            dict.Add(typeof(CreateOvertimeVacationViewModel), typeof(CreateOvertimeVacationView));
            //dict.Add(typeof(ShortVacationInfo), typeof(VacationItemView));

            var container = Mvx.Resolve<IMvxViewsContainer>();
            container.AddAll(dict);
        }
    }
}
