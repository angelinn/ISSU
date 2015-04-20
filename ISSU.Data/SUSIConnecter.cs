﻿using System.Configuration;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System;

using ISSU.Models;
using Newtonsoft.Json;

namespace ISSU.Data
{
    public class SUSIConnecter
    {
        public const string PROGRAMME = "ИС(рб)";

        public async Task<string> LoginAsync(string username, string password)
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

        public async Task<Student> GetStudentInfoAsync(string authKey)
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
            return JsonConvert.DeserializeObject<Student>(json);
        }

        public async Task DisposeKey(string authKey)
        {
            await CreateRequestAsync(API_URL + LOGIN, new { key = authKey });
        }
        
        public async Task<string> GetCoursesAsync(string authKey)
        {
            WebResponse response;
            try
            {
                response = await CreateRequestAsync(API_URL + COURSES, new { key = authKey });
            }
            catch (WebException)
            {
                // return (((HttpWebResponse)e.Response).StatusCode).ToString();
                return null;
            }
            return ReadResponse(response);
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

            return await request.GetResponseAsync();
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

        private string API_URL = ConfigurationManager.AppSettings["url"];
        private string LOGIN = ConfigurationManager.AppSettings["login"];
        private string STUDENT = ConfigurationManager.AppSettings["student"];
        private string COURSES = ConfigurationManager.AppSettings["courses"];
        private string ROLES = ConfigurationManager.AppSettings["roles"];
        private const string JSON_TYPE = "application/json";
        private const string POST_METHOD = "POST";
    }
}
