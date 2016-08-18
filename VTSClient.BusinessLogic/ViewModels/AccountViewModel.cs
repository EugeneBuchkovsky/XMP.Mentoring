using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VTSClient.BusinessLogic.Services.Interfaces;
using VTSClient.DataAccess.MockModel;


namespace VTSClient.BusinessLogic.ViewModels
{
    public class AccountViewModel : MvxViewModel
    {

        private readonly IAccountService accountService;
        public AccountViewModel(IAccountService _accountService)
        {
            this.accountService = _accountService;
            Title = "hello";

            //var source = "http://localhost:63375/api/Vacations/3";
            //using (HttpClient hc = new HttpClient())
            //{
            //    var result = hc.GetAsync(source);
            //}
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                RaisePropertyChanged(() => Title);
            }
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
                return new MvxCommand(Authentication);
            }
        }

        private void Authentication()
        {
            if (accountService.Authentication(Login, Password) == null)
                //return new MvxCommand(() => ShowViewModel<VocationsListViewModel>());
                ErrorMessage = "Wrong login or password";
            else
            {
                ErrorMessage = "OK";
                ShowViewModel<VacationsViewModel>();
            }

        }
    }
}
