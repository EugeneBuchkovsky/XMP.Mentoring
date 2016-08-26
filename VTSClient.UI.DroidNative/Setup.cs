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
    }
}