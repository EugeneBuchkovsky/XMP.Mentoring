using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VTSClient.BusinessLogic.Services.Interfaces;
//using VTSClient.DataAccess.MockModel;
using VtsMockClient.Domain.Models;
using VTSClient.DataAccess.WebServices.Interfaces;


namespace VTSClient.BusinessLogic.Services.Instances
{
    public class VacationsService : IVacationsService
    {
        private List<ShortVacationInfo> vocationsList;

        private IVacationsWebService vacationsWebService;

        public VacationsService(IVacationsWebService _vacationsWebService)
        {
            this.vacationsWebService = _vacationsWebService;
            //this.Init();
        }

        public IEnumerable<ShortVacationInfo> GetAllVocations()
        {
            return vacationsWebService.GetVacationsInfoList(1);
            //return vocationsList;
        }

        public VacationInfo VacationDetails(int id)
        {
            return vacationsWebService.GetVacationInfo(id);
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
