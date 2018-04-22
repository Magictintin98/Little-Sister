using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Helpers;
using System.Collections.Generic;

namespace LittleSister
{
    public static class Extensions
    {
        public static StringContent AsJson(this object o)
         => new StringContent(JsonConvert.SerializeObject(o), Encoding.UTF8, "application/json");
    }
    public static class FaceAPI
    {
        const string subscriptionKey = "833e45378bb14f87a44898058d0fd694";
        const string uriBase = "https://westcentralus.api.cognitive.microsoft.com/face/v1.0/detect";
        public static async void MakeAnalysisRequest(Image image)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);
            string requestParameters = "returnFaceId=true";
            string uri = uriBase + "?" + requestParameters;
            HttpResponseMessage response;
            byte[] byteData = ImageToByteArray(image);

            using (ByteArrayContent content = new ByteArrayContent(byteData))
            {
                // This example uses content type "application/octet-stream".
                // The other content types you can use are "application/json" and "multipart/form-data".
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

                // Execute the REST API call.
                response = await client.PostAsync(uri, content);

                // Get the JSON response.
                string contentString = await response.Content.ReadAsStringAsync();
                IEnumerable<FaceAPIJson> faceapijson = JsonConvert.DeserializeObject<IEnumerable<FaceAPIJson>>(contentString);
                IdentityCheck(faceapijson.ToList().First());
            }
        }
        public static async void IdentityCheck(FaceAPIJson faceapijson)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);
            string uri = "https://westcentralus.api.cognitive.microsoft.com/face/v1.0/identify" ;
            HttpResponseMessage response;
            JObject json = new JObject();
            json["PersonGroupId"] = 1;
            json["faceIds"] = JToken.FromObject(new List<string>() { faceapijson.faceId });
            json["maxNumOfCandidatesReturned"] = 1;
            json["confidenceThreshold"] = 0.5;
            
            //var data = new { PersonGroupId= 1, faceIds=["c5c24a82-6845-4031-9d5d-978df9175426"],maxNumOfCandidatesReturned= 1, confidenceThreshold= 0.5};
            
            var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
            response = await client.PostAsync(uri, content);

            // Get the JSON response.
            string contentString = await response.Content.ReadAsStringAsync();
            Console.WriteLine(contentString);
        }
        public static byte[] ImageToByteArray(Image image)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }
    }
}
