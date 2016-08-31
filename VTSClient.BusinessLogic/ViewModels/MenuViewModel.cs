using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace VTSClient.BusinessLogic.ViewModels
{
    public class MenuViewModel : MvxViewModel
    {
        private ICommand selectedVocations;
        public ICommand SelectedVocations
        {
            get { return new MvxCommand(() => ShowViewModel<VacationsViewModel>()); }
        }

        private ICommand selectedCreate;
        public ICommand SelectedCreate
        {
            get { return new MvxCommand(() => ShowViewModel<CreateVacationViewModel>()); }
        }

        private ICommand selectedLogout;
        public ICommand SelectedLogout
        {
            get { return new MvxCommand(() => ShowViewModel<AccountViewModel>()); }
        }
    }
}
