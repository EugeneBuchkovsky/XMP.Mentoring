using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VTSClient.BusinessLogic.Services.Interfaces;
using VTSClient.DataAccess.Repositories;
using VtsMockClient.Domain.Enums;
using VtsMockClient.Domain.Models;

namespace VTSClient.BusinessLogic.ViewModels.CreateTabViewModel
{
    public class CreateRegularVacationViewModel : CreateViewModel
    {
        private IVacationsService service;
        private IRepository repo;

        public CreateRegularVacationViewModel(IVacationsService vs, IRepository repo)
        {
            this.service = vs;
            this.repo = repo;

            StartDate = DateTime.Now;
            EndDate = DateTime.Now.AddHours(8);

            ApproverList = service.GetApproversSync();
        }

        //public override void Start()
        //{
        //    //ApproverList = await service.GetApprovers();
        //    base.Start();
        //}

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

        //public IMvxCommand ShowSelectedApproverCommand()
        //{
        //    return new MvxCommand(() => );
        //}

        public override void SaveChanges()
        {
            var model = new VacationInfo
            {
                //ApproverId = SelectedApprover.Id,
                EmployeeId = repo.GetCurrentUser().Id,
                Comment = this.Comment,
                StartDate = this.StartDate,
                EndDate = this.EndDate,
                Status = VacationStatus.WaitingForApproval,
                Type = VacationType.Regular
            };

            service.UpdateVacationInfo(model);
            ShowViewModel<VacationsViewModel>();
        }
    }
}
