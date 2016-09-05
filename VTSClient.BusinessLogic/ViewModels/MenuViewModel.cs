using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VTSClient.BusinessLogic.Enums;

namespace VTSClient.BusinessLogic.ViewModels
{
    public class MenuViewModel : MvxViewModel
    {
        private MenuItems section;
        public MenuItems Section
        {
            get { return section; }
            set
            {
                section = value;
                RaisePropertyChanged(() => Section);
            }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                RaisePropertyChanged(() => Title);
            }
        }
    }
}
