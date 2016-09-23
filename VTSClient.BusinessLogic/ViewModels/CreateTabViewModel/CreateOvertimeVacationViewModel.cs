using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VTSClient.BusinessLogic.Converters;
using VTSClient.BusinessLogic.Services.Interfaces;
using VTSClient.DataAccess.Repositories;
using VtsMockClient.Domain.Enums;
using VtsMockClient.Domain.Models;

namespace VTSClient.BusinessLogic.ViewModels.CreateTabViewModel
{
    public class CreateOvertimeVacationViewModel : CreateViewModel
    {
        private IVacationsService service;
        private IRepository repo;

        public CreateOvertimeVacationViewModel(IVacationsService vs, IRepository repo)
        {
            this.service = vs;
            this.repo = repo;

            

            ApproverList = service.GetApproversSync();
        }

        //public override void Start()
        //{
        //    //ApproverList = await service.GetApprovers();
        //    base.Start();
        //}


        private Person selectedApprover;
        public Person SelectedApprover
        {
            get { return selectedApprover; }
            set
            {
                selectedApprover = value;
                RaisePropertyChanged(() => SelectedApprover);
            }
        }

        public ICommand _someCommand;
        public ICommand SomeCommand
        {
            get
            {
                return _someCommand ?? new MvxCommand<Person>((value) =>
                {
                    selectedApprover = value;
                    //ShowSelectedVacation();
                });
            }
        }

        //public IMvxCommand ShowSelectedApproverCommand()
        //{
        //    return new MvxCommand(() => );
        //}

        public override void SaveChanges()
        {
            var start = MyStringToDateConverter.Convert(StartD);
            var end = MyStringToDateConverter.Convert(EndD);

            if (DateCheck(start, end))
            {
                var model = new VacationInfo
                {
                    ApproverId = SelectedApprover.Id,
                    EmployeeId = repo.GetCurrentUser().Id,
                    NoProjectManagerObjections = true,
                    Comment = this.Comment,
                    //StartDate = this.StartDate,
                    StartDate = start,
                    EndDate = end.AddHours(8),
                    Status = VacationStatus.Waiting,
                    Type = VacationType.Overtime
                };

                service.UpdateVacationInfo(model);
                ShowViewModel<VacationsViewModel>();
            }
            else
                Message = "Invalid dates!";
            //Close(this);
        }
    }
}
