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
using MvvmCross.Platform;
using VTSClient.BusinessLogic.Services.Interfaces;
using VTSClient.BusinessLogic.Services.Instances;
using VTSClient.DataAccess.WebServices.Interfaces;
using VTSClient.DataAccess.WebServices.Services;
using VTSClient.DataAccess.Repositories;
using VTSClient.BusinessLogic.ViewModels;
using VTSClient.UI.DroidNative.Views;
using MvvmCross.Core.Views;
using VTSClient.BusinessLogic.ViewModels.CreateTabViewModel;
using VTSClient.UI.DroidNative.Tabs;

namespace VTSClient.UI.DroidNative
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext)
            : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            Mvx.RegisterType<IAccountService, AccountService>();

            Mvx.RegisterType<IWEB, LoginWebService>();
            //Mvx.RegisterType<IVacationsWebService, VacationsWebService>();

            Mvx.RegisterType<IRepository, PersonRepository>();
            Mvx.RegisterType<ISQLite, SQLite_Droid>();
            Mvx.RegisterType<IVacationsWebService, VacationsWebService>();
            Mvx.RegisterType<IVacationsService, VacationsService>();


            return new BusinessLogic.App();
        }

        protected override void InitializeViewLookup()
        {
            base.InitializeViewLookup();

            var dict = new Dictionary<Type, Type>();

            dict.Add(typeof(VacationsViewModel), typeof(VacationsView));
            dict.Add(typeof(CreateVacationViewModel), typeof(CreateVacationActivityTabsView));
            //dict.Add(typeof(SubViewModel), typeof(CreateVacationTabsView));
            //dict.Add(typeof(SelectedVacationViewModel), typeof(VacationDetails));

            dict.Add(typeof(CreateRegularVacationViewModel), typeof(CreateRegularVacationView));
            dict.Add(typeof(CreateSickLeaveViewModel), typeof(CreateSickLeaveView));


            var container = Mvx.Resolve<IMvxViewsContainer>();
            container.AddAll(dict);
        }
    }
}