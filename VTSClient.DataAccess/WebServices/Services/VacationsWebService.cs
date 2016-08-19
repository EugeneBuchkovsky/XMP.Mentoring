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
        public VacationInfo GetVacationInfo(int id)
        {
            var client = new RestClient("http://10.6.106.21/test/api");

            var request = new RestRequest("Vacation/Get/{id}", Method.GET);

            request.AddUrlSegment("id", id.ToString());

            var a = client.Execute<VacationInfo>(request);
            // TO DO:
            var ab = a.Data;

            return ab;
        }

        public IEnumerable<ShortVacationInfo> GetVacationsInfoList(int id)
        {
            var client = new RestClient("http://10.6.106.21/test/api");

            var request = new RestRequest("Vacation/List/{id}", Method.GET);
            //request.AddParameter("id", id);
            //request.RequestFormat = DataFormat.Json;
            request.AddUrlSegment("id", id.ToString());

            var a = client.Execute<List<ShortVacationInfo>>(request);

            //var ab = a.Content;
            // TO DO:
            var ab = a.Data;

            //return ab;

            return ab;
        }
    }
}
