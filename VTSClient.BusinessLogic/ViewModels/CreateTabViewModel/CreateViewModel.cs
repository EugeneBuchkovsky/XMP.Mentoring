using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VtsMockClient.Domain.Enums;

namespace VTSClient.BusinessLogic.ViewModels.CreateTabViewModel
{
    public abstract class CreateViewModel : MvxViewModel
    {
        private string aprooverName;
        public string AprooverName
        {
            get { return aprooverName; }
            set
            {
                aprooverName = value;
                RaisePropertyChanged(() => AprooverName);
            }
        }

        private VacationStatus status;
        public VacationStatus Status
        {
            get { return status; }
            set
            {
                status = value;
                RaisePropertyChanged(() => Status);
            }
        }

        private object form;
        public object Form
        {
            get { return form; }
            set
            {
                form = value;
                RaisePropertyChanged(() => Form);
            }
        }

        private DateTime startDate;
        public DateTime StartDate
        {
            get { return startDate; }
            set
            {
                startDate = value;
                RaisePropertyChanged(() => StartDate);
            }
        }

        private DateTime endDate;
        public DateTime EndDate
        {
            get { return endDate; }
            set
            {
                endDate = value;
                RaisePropertyChanged(() => EndDate);
            }
        }

        private string comment;
        public string Comment
        {
            get { return comment; }
            set
            {
                comment = value;
                RaisePropertyChanged(() => Comment);
            }
        }

        private string type;
        public string Type
        {
            get { return type; }
            set
            {
                type = value;
                RaisePropertyChanged(() => Type);
            }
        }


        public ICommand Save
        {
            get
            {
                //return new MvxCommand(() => ShowViewModel<VocationsListViewModel>());
                return new MvxCommand(SaveChanges);
            }
        }

        private async void SaveChanges()
        {
            //model.Comment = Comment;
            ////TO DO: CHANGE MODEL
            //await vacationService.UpdateVacationInfo(model);
            //Close(this);
        }
    }
}
