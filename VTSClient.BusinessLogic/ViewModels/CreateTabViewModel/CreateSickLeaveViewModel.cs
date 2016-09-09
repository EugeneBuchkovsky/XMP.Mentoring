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

        public CreateSickLeaveViewModel(IVacationsService vs, IRepository repo)
        {
            this.service = vs;
            this.repo = repo;



            ApproverList = service.GetApproversSync();
        }

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
                ShowViewModel<VacationsViewModel>();
            }
            else
                Message = "Invalid dates!";
            //Close(this);
        }
    }
}
