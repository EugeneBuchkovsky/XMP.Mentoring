using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VTSClient.DataAccess.MockModel;

namespace VTSClient.BusinessLogic.Services.Interfaces
{
    public interface IVacationsService
    {
        List<ShortVacationInfo> GetAllVocations();
    }
}
