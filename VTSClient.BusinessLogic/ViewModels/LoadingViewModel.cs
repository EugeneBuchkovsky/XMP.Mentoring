using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTSClient.BusinessLogic.ViewModels
{
    public class LoadingViewModel : MvxViewModel
    {
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
    }
}
