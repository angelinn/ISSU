using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ISSU.Data
{
    public class SUSIConnecter
    {
        private const string API_URL = @"http://susi.apphb.com/api";
        private const string LOGIN = @"/login";
        private const string STUDENT = @"/student";
        private const string COURSES = @"/courses?coursesType=0";
        private const string ROLES = @"/roles";
        private const string JSON_TYPE = "application/json";
        private const string POST_METHOD = "POST";

        public string Login(string username, string password)
        {
            Task<WebResponse> response = CreateRequestAsync(API_URL + LOGIN, new { username = username, password = password });
            return ReadResponse(response.Result);
        }

        private async Task<WebResponse> CreateRequestAsync(string address, object data)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(address);
            request.ContentType = JSON_TYPE;
            request.Method = POST_METHOD;

            using (Stream requestStream = request.GetRequestStream())
            using (StreamWriter writer = new StreamWriter(requestStream))
            {
                writer.Write(JsonConvert.SerializeObject(data));
            }
            return (await request.GetResponseAsync());
        }

        private string ReadResponse(WebResponse response)
        {
            string result = String.Empty;

            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }
    }
}
