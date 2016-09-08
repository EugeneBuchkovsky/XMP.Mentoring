using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VtsMockClient.Domain.Enums;
using VtsMockClient.Domain.Models;

namespace VTSClient.BusinessLogic.ViewModels.CreateTabViewModel
{
    public abstract class CreateViewModel : MvxViewModel
    {
        public override void Start()
        {
            StartDate = DateTime.Now;
            EndDate = DateTime.Now.AddHours(8);
            base.Start();
        }


        private IEnumerable<Person> approverList;
        public IEnumerable<Person> ApproverList
        {
            get { return approverList; }
            set
            {
                approverList = value;
                RaisePropertyChanged(() => ApproverList);
            }
        }

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

        private string startD;
        public string StartD
        {
            get { return startD; }
            set
            {
                startD = value;
                RaisePropertyChanged(() => StartD);
            }
        }

        private string endD;
        public string EndD
        {
            get { return endD; }
            set
            {
                endD = value;
                RaisePropertyChanged(() => EndD);
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

        private VacationType type;
        public VacationType Type
        {
            get { return type; }
            set
            {
                type = value;
                RaisePropertyChanged(() => Type);
            }
        }

        private string message;
        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                RaisePropertyChanged(() => Message);
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

        public virtual async void SaveChanges()
        {
            //model.Comment = Comment;
            ////TO DO: CHANGE MODEL
            //await vacationService.UpdateVacationInfo(model);
            //Close(this);
        }

        protected bool DateCheck(DateTime start, DateTime end)
        {
            return start <= end && start >= DateTime.Now.Date;
        }
    }
}
