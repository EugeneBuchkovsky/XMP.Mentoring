﻿using System;
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
        Task<IEnumerable<ShortVacationInfo>> GetAllVocations();

        Task<VacationInfo> VacationDetails(int id);

        Task<int> UpdateVacationInfo(VacationInfo vacation);

        Task<IEnumerable<Person>> GetApprovers();

        IEnumerable<Person> GetApproversSync();

    }
}
