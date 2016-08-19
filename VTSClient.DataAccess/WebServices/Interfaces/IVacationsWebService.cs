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
        IEnumerable<ShortVacationInfo> GetVacationsInfoList(int id);

        VacationInfo GetVacationInfo(int id);
    }
}
