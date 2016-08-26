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
using MvvmCross.Core.Views;
using VTSClient.BusinessLogic;
using VTSClient.BusinessLogic.ViewModels;
using VTSClient.UI.NativeAndroid.Activities;
using VTSClient.BusinessLogic.Services.Interfaces;
using VTSClient.BusinessLogic.Services.Instances;
using VTSClient.DataAccess.WebServices.Interfaces;
using VTSClient.DataAccess.Repositories;
using VTSClient.DataAccess.WebServices.Services;

namespace VTSClient.UI.NativeAndroid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext)
           : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            Mvx.RegisterType<IVacationsService, VacationsService>();
            Mvx.RegisterType<IAccountService, AccountService>();
            
            Mvx.RegisterType<IWEB, LoginWebService>();
            Mvx.RegisterType<IVacationsWebService, VacationsWebService>();

            Mvx.RegisterType<IRepository, PersonRepository>();
            return new App();
        }

        protected override void InitializeViewLookup()
        {
            base.InitializeViewLookup();

            var dict = new Dictionary<Type, Type>();

            dict.Add(typeof(AccountViewModel), typeof(LoginActivity));

            //dict.Add(typeof(AccountViewModel), typeof(VocationsView));

            var container = Mvx.Resolve<IMvxViewsContainer>();
            container.AddAll(dict);
        }
    }
}