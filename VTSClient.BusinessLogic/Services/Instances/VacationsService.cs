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

        public async Task<IEnumerable<ShortVacationInfo>> GetAllVocations()
        {
            return await vacationsWebService.GetVacationsInfoList(vacationRepo.GetCurrentUser().Id);
            //return vocationsList;
        }

        public async Task<VacationInfo> VacationDetails(int id)
        {
            return await vacationsWebService.GetVacationInfo(id);
        }

        public async Task<int> UpdateVacationInfo(VacationInfo vacation)
        {
            return await vacationsWebService.UpdateVacationInfo(vacation);
        }

        public async Task<IEnumerable<Person>> GetApprovers()
        {
            return await vacationsWebService.GetApprovers(vacationRepo.GetCurrentUser().Id);
        }

        public IEnumerable<Person> GetApproversSync()
        {
            return vacationsWebService.GetApproversSync(vacationRepo.GetCurrentUser().Id);
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
