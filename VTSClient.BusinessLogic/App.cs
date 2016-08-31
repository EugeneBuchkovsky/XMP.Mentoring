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
using VTSClient.DataAccess.Repositories;
using VTSClient.DataAccess.WebServices.Interfaces;
using VTSClient.DataAccess.WebServices.Services;

namespace VTSClient.BusinessLogic
{
    public class App : MvxApplication
    {
        public App()
        {
            //Mvx.RegisterType<IVacationsService, VacationsService>();
            Mvx.RegisterType<IAccountService, AccountService>();

            Mvx.RegisterType<IWEB, LoginWebService>();
            //Mvx.RegisterType<IVacationsWebService, VacationsWebService>();

            Mvx.RegisterType<IRepository, PersonRepository>();

            Mvx.RegisterSingleton<IMvxAppStart>(new MvxAppStart<AccountViewModel>());
            //Mvx.RegisterSingleton<IMvxAppStart>(new MvxAppStart<CreateVacationViewModel>());
        }
    }
}
