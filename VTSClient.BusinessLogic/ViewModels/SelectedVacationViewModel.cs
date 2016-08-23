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

        public void Init(int selectId, string aName)
        {
            this.aName = aName;
            this.id = selectId;
            model = vacationService.VacationDetails(id);
            Name = aName;
            Name1 = model.Status;
            Name2 = model.VacationForm;
            Name3 = model.StartDate;
            Name4 = model.EndDate;
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

        private VacationStatus name1;
        public VacationStatus Name1
        {
            get { return name1; }
            set
            {
                name1 = value;
                RaisePropertyChanged(() => Name1);
            }
        }

        private object name2;
        public object Name2
        {
            get { return name2; }
            set
            {
                name2 = value;
                RaisePropertyChanged(() => Name2);
            }
        }

        private DateTime name3;
        public DateTime Name3
        {
            get { return name3; }
            set
            {
                name3 = value;
                RaisePropertyChanged(() => Name3);
            }
        }

        private DateTime name4;
        public DateTime Name4
        {
            get { return name4; }
            set
            {
                name4 = value;
                RaisePropertyChanged(() => Name4);
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

        private void SaveChanges()
        {
            model.Comment = Comment;
            //TO DO: CHANGE MODEL
            vacationService.UpdateVacationInfo(model);
            ShowViewModel<VacationsViewModel>();
        }
    }
}
