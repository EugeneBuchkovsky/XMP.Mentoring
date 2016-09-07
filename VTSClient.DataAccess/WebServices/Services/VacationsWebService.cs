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

        public async Task<IEnumerable<Person>> GetApprovers(int id)
        {
            var client = new RestClient("http://10.6.106.21/test/api");

            var request = new RestRequest("Vacation/Approvers/{id}", Method.GET);

            request.AddUrlSegment("id", id.ToString());

            var r = await client.ExecuteTaskAsync<List<Person>>(request);

            return r.Data;
        }

        public IEnumerable<Person> GetApproversSync(int id)
        {
            var client = new RestClient("http://10.6.106.21/test/api");

            var request = new RestRequest("Vacation/Approvers/{id}", Method.GET);

            request.AddUrlSegment("id", id.ToString());

            var r = client.Execute<List<Person>>(request);

            return r.Data;
        }
        public async Task<VacationInfo> GetVacationInfo(int id)
        {
            var client = new RestClient("http://10.6.106.21/test/api");

            var request = new RestRequest("Vacation/Get/{id}", Method.GET);

            request.AddUrlSegment("id", id.ToString());

            //var a = client.Execute<VacationInfo>(request);

            var result = await client.ExecuteTaskAsync<VacationInfo>(request);

            // TO DO:
            //var ab = a.Data;

            return result.Data;
        }

        public async Task<IEnumerable<ShortVacationInfo>> GetVacationsInfoList(int id)
        {
            IEnumerable<ShortVacationInfo> ab = null;
            var client = new RestClient("http://10.6.106.21/test/api");

            var request = new RestRequest("Vacation/List/{id}", Method.GET);
            //request.AddParameter("id", id);
            //request.RequestFormat = DataFormat.Json;
            request.AddUrlSegment("id", id.ToString());

            //var result = client.ExecuteAsync<List<ShortVacationInfo>>(request, response =>
            //{
            //    if(response.ResponseStatus == ResponseStatus.Completed)
            //        ab = response.Data;
            //});

            //var res = client.Execute<List<ShortVacationInfo>>(request).Data;
            var r = await client.ExecuteTaskAsync<List<ShortVacationInfo>>(request);
            //var ab = a.Content;
            // TO DO:
            //var ab = a.Data;

            //return ab;
            //Task.Delay(10000);

            //var res = r.Data;


            //var a = ab;

            return r.Data;
        }

        public async Task<int> UpdateVacationInfo(VacationInfo model)
        {

            var client = new RestClient("http://10.6.106.21/test/api");

            var request = new RestRequest("Vacation/Update", Method.POST);
            request.RequestFormat = DataFormat.Json;

            request.AddBody(model);
            //var a = client.Execute<int>(request);
            var r = await client.ExecuteTaskAsync<int>(request);

            // TO DO:
            //var ab = a.Data;

            return r.Data;
        }
    }
}
