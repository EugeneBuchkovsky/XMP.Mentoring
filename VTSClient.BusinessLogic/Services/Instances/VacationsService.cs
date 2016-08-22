using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VTSClient.BusinessLogic.Services.Interfaces;
//using VTSClient.DataAccess.MockModel;
using VtsMockClient.Domain.Models;
using VTSClient.DataAccess.WebServices.Interfaces;
using VTSClient.DataAccess.Repositories;


namespace VTSClient.BusinessLogic.Services.Instances
{
    public class VacationsService : IVacationsService
    {
        private List<ShortVacationInfo> vocationsList;

        private IVacationsWebService vacationsWebService;
        private IRepository vacationRepo;

        public VacationsService(IVacationsWebService _vacationsWebService, IRepository _vacationsrepo)
        {
            this.vacationRepo = _vacationsrepo;
            this.vacationsWebService = _vacationsWebService;
            //this.Init();
        }

        public IEnumerable<ShortVacationInfo> GetAllVocations()
        {
            return vacationsWebService.GetVacationsInfoList(vacationRepo.GetCurrentUser().Id);
            //return vocationsList;
        }

        public VacationInfo VacationDetails(int id)
        {
            return vacationsWebService.GetVacationInfo(id);
        }

        public int UpdateVacationInfo(VacationInfo vacation)
        {
            return vacationsWebService.UpdateVacationInfo(vacation);
        }

        private void Init()
        {
            vocationsList = new List<ShortVacationInfo>();

            var voc1 = new ShortVacationInfo
            {
                Id = 1,
                ApproverFullName = "Ivan Ivanuch"
            };

            var voc2 = new ShortVacationInfo
            {
                Id = 1,
                ApproverFullName = "Ivan Sergeich"
            };

            var voc3 = new ShortVacationInfo
            {
                Id = 1,
                ApproverFullName = "Ivan Ivanuch"
            };

            var voc4 = new ShortVacationInfo
            {
                Id = 1,
                ApproverFullName = "Ivan Ivanuch"
            };

            vocationsList.Add(voc1);
            vocationsList.Add(voc2);
            vocationsList.Add(voc3);
            vocationsList.Add(voc4);

        }
    }
}
