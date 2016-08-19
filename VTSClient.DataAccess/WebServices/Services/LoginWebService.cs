using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VTSClient.DataAccess.WebServices.Interfaces;
//using VTSClient.DataAccess.MockModel;
using RestSharp;

using VtsMockClient.Domain.Models;

namespace VTSClient.DataAccess.WebServices.Services
{
    public class LoginWebService : IWEB
    {
        public Person Login(PersonCredentials model)
        {
            var client = new RestClient("http://10.6.106.21/test/api");

            var request = new RestRequest("Login/Post", Method.POST);
            request.RequestFormat = DataFormat.Json;

            request.AddBody(model);
            var  a = client.Execute<Person>(request);
            // TO DO:
            var ab = a.Data;
            
            return ab;
        }
    }
}
