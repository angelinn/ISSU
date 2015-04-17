using ISSU.Models;
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
    public static class SUSIConnecter
    {
        private const string API_URL = @"http://susi.apphb.com/api";
        private const string LOGIN = @"/login";
        private const string STUDENT = @"/student";
        private const string COURSES = @"/courses?coursesType=0";
        private const string ROLES = @"/roles";
        private const string JSON_TYPE = "application/json";
        private const string POST_METHOD = "POST";

        public const string PROGRAMME = "ИС(рб)";

        public static async Task<string> LoginAsync(string username, string password)
        {
            WebResponse response;
            try
            {
                response = await CreateRequestAsync(API_URL + LOGIN, new { username = username, password = password });
            }
            catch(WebException)
            {
                // return (((HttpWebResponse)e.Response).StatusCode).ToString();
                return null;
            }

            return ReadResponse(response);
        }

        public static async Task<Student> GetStudentInfoAsync(string authKey)
        {
            WebResponse response;

            try
            {
                response = await CreateRequestAsync(API_URL + STUDENT, new { key = authKey });
            }
            catch (WebException)
            {
                // return (((HttpWebResponse)e.Response).StatusCode).ToString();
                return null;
            }

            string json = ReadResponse(response);
            return (Student)JsonConvert.DeserializeObject(json, typeof(Student));
        }

        private static async Task<WebResponse> CreateRequestAsync(string address, object data)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(address);
            request.ContentType = JSON_TYPE;
            request.Method = POST_METHOD;

            using (Stream requestStream = request.GetRequestStream())
            using (StreamWriter writer = new StreamWriter(requestStream))
            {
                writer.Write(JsonConvert.SerializeObject(data));
            }

            return await request.GetResponseAsync();
        }

        private static string ReadResponse(WebResponse response)
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
