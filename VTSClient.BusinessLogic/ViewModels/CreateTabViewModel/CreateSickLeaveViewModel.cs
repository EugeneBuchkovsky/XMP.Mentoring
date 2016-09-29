using MvvmCross.Plugins.PictureChooser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VTSClient.BusinessLogic.Converters;
using VTSClient.BusinessLogic.Services.Interfaces;
using VTSClient.DataAccess.Repositories;
using VtsMockClient.Domain.Enums;
using VtsMockClient.Domain.Models;

namespace VTSClient.BusinessLogic.ViewModels.CreateTabViewModel
{
    public class CreateSickLeaveViewModel : CreateViewModel
    {
        private IVacationsService service;
        private IRepository repo;

        public CreateSickLeaveViewModel(IVacationsService vs, IRepository repo, IMvxPictureChooserTask chooser)
        {
            this.service = vs;
            this.repo = repo;
            this.PictureChooser = chooser;

            ApproverList = service.GetApproversSync();
        }

        //public event Action Close;

        public override void SaveChanges()
        {
            var start = MyStringToDateConverter.Convert(StartD);
            var end = MyStringToDateConverter.Convert(EndD);

            if (DateCheck(start, end))
            {
                var model = new VacationInfo
                {
                    ApproverId = ApproverList.First().Id,
                    EmployeeId = repo.GetCurrentUser().Id,
                    NoProjectManagerObjections = true,
                    Comment = this.Comment,
                    //StartDate = this.StartDate,
                    StartDate = start,
                    EndDate = end.AddHours(8),
                    Status = VacationStatus.Approved,
                    Type = VacationType.Sick
                };
                
                service.UpdateVacationInfo(model);
                OnClose();
                //ShowViewModel<VacationsViewModel>();
            }
            else
                Message = "Invalid dates!";
            //Close(this);
        }
    }
}
