using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VTSClient.BusinessLogic.Services.Interfaces;
using VTSClient.DataAccess.MockModel;


namespace VTSClient.BusinessLogic.Services.Instances
{
    public class VacationsService : IVacationsService
    {
        private List<ShortVacationInfo> vocationsList;

        public VacationsService()
        {
            this.Init();
        }

        public List<ShortVacationInfo> GetAllVocations()
        {
            return vocationsList;
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
