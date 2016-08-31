using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTSClient.BusinessLogic.ViewModels
{
    public class SubViewModel : MvxViewModel
    {
        private string aprooverName = "pupkina";
        public string AprooverName
        {
            get { return aprooverName; }
            set
            {
                aprooverName = value;
                RaisePropertyChanged(() => AprooverName);
            }
        }

        private Tab1ViewModel tab1;
        public Tab1ViewModel Tab1
        {
            get { return new Tab1ViewModel(); }
        }

        private Tab2ViewModel tab2;
        public Tab2ViewModel Tab2
        {
            get { return new Tab2ViewModel(); }
        }
    }

    public class Tab1ViewModel : MvxViewModel
    {
        private string aprooverName = "pupkina";
        public string AprooverName
        {
            get { return aprooverName; }
            set
            {
                aprooverName = value;
                RaisePropertyChanged(() => AprooverName);
            }
        }
    }
    public class Tab2ViewModel : MvxViewModel
    {
        private string aprooverName = "pupkina";
        public string AprooverName
        {
            get { return aprooverName; }
            set
            {
                aprooverName = value;
                RaisePropertyChanged(() => AprooverName);
            }
        }
    }

}
