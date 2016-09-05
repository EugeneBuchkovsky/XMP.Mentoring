using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VTSClient.BusinessLogic.Services.Interfaces;
using VTSClient.BusinessLogic.ViewModels.CreateTabViewModel;
using VTSClient.DataAccess.Repositories;
using VtsMockClient.Domain.Enums;
using VtsMockClient.Domain.Models;

namespace VTSClient.BusinessLogic.ViewModels
{
    public class CreateVacationViewModel : MvxViewModel
    {
        //public async void Init(int selectId, string aName)
        //{
        //    this.aName = aName;
        //    this.id = selectId;
        //    model = await vacationService.VacationDetails(id);
        //    aprooverName = aName;
        //    Status = model.Status;
        //    Form = model.VacationForm;
        //    StartDate = model.StartDate;
        //    EndDate = model.EndDate;
        //    Comment = model.Comment;
        //}

        public CreateVacationViewModel(IVacationsService service, IRepository repo)
        {
            //this.vacationService = _vacationService;
            RegularVacation = new CreateRegularVacationViewModel(service, repo);
            SickLeave = new CreateSickLeaveViewModel();
        }

        private CreateRegularVacationViewModel regularVacation;
        public CreateRegularVacationViewModel RegularVacation
        {
            get { return regularVacation; }
            set
            {
                regularVacation = value;
                RaisePropertyChanged(() => RegularVacation);
            }
        }

        private CreateSickLeaveViewModel sickLeave;
        public CreateSickLeaveViewModel SickLeave
        {
            get { return sickLeave; }
            set
            {
                sickLeave = value;
                RaisePropertyChanged(() => SickLeave);
            }
        }
    }
}
