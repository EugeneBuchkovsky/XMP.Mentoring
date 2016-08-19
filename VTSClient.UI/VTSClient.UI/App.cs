using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VTSClient.BusinessLogic.Services.Instances;
using VTSClient.BusinessLogic.Services.Interfaces;
using VTSClient.BusinessLogic.ViewModels;

using VTSClient.DataAccess.WebServices.Interfaces;
using VTSClient.DataAccess.WebServices.Services;


namespace VTSClient.UI
{
    public class App : MvxApplication
    {
        public App()
        {
            //Mvx.RegisterType<IVocationsListService, VocationsListService>();
        }

        public override void Initialize()
        {
            //    base.Initialize();

            //    // The root page of your application
            //    RegisterAppStart<LoginViewModel>();
            //CreatableTypes()
            //        .EndingWith("Service")
            //        .AsInterfaces()
            //        .RegisterAsLazySingleton();

            Mvx.RegisterType<IVacationsService, VacationsService>();
            Mvx.RegisterType<IAccountService, AccountService>();

            //Mvx.RegisterType<ILoginWebService, LoginWebService>();
            Mvx.RegisterType<IWEB, LoginWebService>();

            Mvx.RegisterSingleton<IMvxAppStart>(new MvxAppStart<AccountViewModel>());
        }
    }
}
