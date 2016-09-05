using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using VtsMockClient.Domain.Models;
using VtsMockClient.Domain.Enums;
using VTSClient.BusinessLogic.Services.Interfaces;
using System.Windows.Input;


namespace VTSClient.BusinessLogic.ViewModels
{
    public class SelectedVacationViewModel : MvxViewModel
    {
        private int id;
        private string aName;
        private VacationInfo selectVacation;
        private IVacationsService vacationService;

        private VacationInfo model;

        public async void Init(int selectId, string aName)
        {
            this.aName = aName;
            this.id = selectId;
            model = await vacationService.VacationDetails(id);
            Name = aName;
            Status = model.Status;
            VacationForm = model.VacationForm;
            StartDate = model.StartDate;
            EndDate = model.EndDate;
            Comment = model.Comment;
        }

        public SelectedVacationViewModel(IVacationsService _vacationService)
        {
            this.vacationService = _vacationService;
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                RaisePropertyChanged(() => Name);
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

        private object vacationForm;
        public object VacationForm
        {
            get { return vacationForm; }
            set
            {
                vacationForm = value;
                RaisePropertyChanged(() => VacationForm);
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
            model.Comment = Comment;
            //TO DO: CHANGE MODEL
            await vacationService.UpdateVacationInfo(model);
            Close(this);
        }
    }
}
