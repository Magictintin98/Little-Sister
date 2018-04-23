using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using System.IO;

namespace Little_Sister_Web.Models
{
    public class RequestApi
    {
        private string baseUrl = @"http://littlesister2.azurewebsites.net/api";
        public async Task<List<User>> GetAllUsers()
        {
            var jsonString = string.Empty;
            List<User> allUsers = null;
            try
            {
                string url = $"{baseUrl}/User/getall";
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";

                var response = (HttpWebResponse)await request.GetResponseAsync();
                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    jsonString = streamReader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                return null;
            }
            if (jsonString != string.Empty)
            {
                allUsers = JsonConvert.DeserializeObject<List<User>>(jsonString);
            }
            return allUsers;
        }

        public async Task<User> TrackUser(string id)
        {
            var jsonString = string.Empty;
            User user = null;
            try
            {
                string url = $"{baseUrl}/User/getbyid/{id}";
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";

                var response = (HttpWebResponse)await request.GetResponseAsync();
                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    jsonString = streamReader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                return null;
            }
            if (jsonString != string.Empty)
            {
                user = JsonConvert.DeserializeObject<User>(jsonString);
            }
            return user;
        }

        public async Task<IEnumerable<Position>> GetAllPositions()
        {
            var jsonString = string.Empty;
            IEnumerable<Position> allPositions = null;
            try
            {
                string url = $"{baseUrl}/User/getall";
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";

                var response = (HttpWebResponse)await request.GetResponseAsync();
                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    jsonString = streamReader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                return null;
            }
            if (jsonString != string.Empty)
            {
                allPositions = JsonConvert.DeserializeObject<IEnumerable<Position>>(jsonString);
            }
            return allPositions;
        }
    }
}