using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using VTSClient.DataAccess.MockModel;
using VtsMockClient.Domain.Models;

namespace VTSClient.BusinessLogic.Services.Interfaces
{
    public interface IVacationsService
    {
        IEnumerable<ShortVacationInfo> GetAllVocations();

        VacationInfo VacationDetails(int id);

        int UpdateVacationInfo(VacationInfo vacation);
    }
}
