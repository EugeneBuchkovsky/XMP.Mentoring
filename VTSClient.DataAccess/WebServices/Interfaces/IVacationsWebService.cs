using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VtsMockClient.Domain.Models;

namespace VTSClient.DataAccess.WebServices.Interfaces
{
    public interface IVacationsWebService
    {
        Task<IEnumerable<ShortVacationInfo>> GetVacationsInfoList(int id);

        Task<VacationInfo> GetVacationInfo(int id);

        Task<int> UpdateVacationInfo(VacationInfo model);
    }
}
