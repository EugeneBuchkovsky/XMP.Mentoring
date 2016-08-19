using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VtsMockClient.Domain.Models;
using VTSClient.DataAccess.WebServices.Interfaces;

using RestSharp;

namespace VTSClient.DataAccess.WebServices.Services
{
    public class VacationsWebService : IVacationsWebService
    {
        public IEnumerable<ShortVacationInfo> GetVacationsInfoList(int id)
        {
            var client = new RestClient("http://10.6.106.21/test/api");

            var request = new RestRequest("Vacation/List", Method.GET);
            request.AddParameter("id", id);
            request.RequestFormat = DataFormat.Json;

            var a = client.Execute<List<ShortVacationInfo>>(request);
            // TO DO:
            var ab = a.Data;

            return ab;
        }
    }
}
