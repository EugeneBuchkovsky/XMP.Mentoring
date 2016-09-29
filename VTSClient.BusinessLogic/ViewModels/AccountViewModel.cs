using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VTSClient.BusinessLogic.Services.Interfaces;
using VtsMockClient.Domain.Models;

namespace VTSClient.BusinessLogic.ViewModels
{
    public class AccountViewModel : MvxViewModel
    {

        private readonly IAccountService accountService;
        public AccountViewModel(IAccountService _accountService)
        {
            this.accountService = _accountService;

            //var source = "http://localhost:63375/api/Vacations/3";
            //using (HttpClient hc = new HttpClient())
            //{
            //    var result = hc.GetAsync(source);
            //}
        }
        
        private string login;
        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                RaisePropertyChanged(() => Login);
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                RaisePropertyChanged(() => Password);
            }
        }

        private string errorMessage;
        public string ErrorMessage
        {
            get { return errorMessage; }
            private set
            {
                errorMessage = value;
                RaisePropertyChanged(() => ErrorMessage);
            }
        }

        public ICommand Logon
        {
            get
            {
                //return new MvxCommand(() => ShowViewModel<VocationsListViewModel>());
                //return new MvxCommand(() => Close(this));
                return new MvxCommand(Authentication);
            }
        }

        private async void Authentication()
        {
            //var task = new Task<Person>(() => accountService.Authentication(Login, Password).Result);
            //var task2 = new Task(() => ShowViewModel<LoadingViewModel>());
            //task.Start();
            //task2.Start();


            ////ShowViewModel<LoadingViewModel>();

            //task.Wait();
            //Close(this);


            var user = await accountService.Authentication(Login, Password);

            if (String.IsNullOrEmpty(user.FullName))
                //return new MvxCommand(() => ShowViewModel<VocationsListViewModel>());
                ErrorMessage = "Wrong login or password";
            else
            {
                ErrorMessage = "OK";

                //ShowViewModel<CreateVacationViewModel>();
                Close(this);
                //ShowViewModel<SubViewModel>();
                ShowViewModel<VacationsViewModel>();
                ErrorMessage = "";
                Login = null;
                Password = null;
            }

        }
    }
}
