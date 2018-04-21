using Emgu.CV;
using Emgu.CV.Structure;
using Newtonsoft.Json;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace LittleSister
{
    public static class VisionAPI
    {
        private const string apiKey = "f8a0f533f1ed4bc29831ecddf909ecdf";
        private const string uri = "https://westcentralus.api.cognitive.microsoft.com/vision/v1.0/analyze?visualFeatures=Categories&language=en";
        public static async void MakeAnalysisRequest(Image image)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key",apiKey);
            HttpResponseMessage response;
            byte[] byteData = ImageToByteArray(image);
            using (ByteArrayContent content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                response = await client.PostAsync(uri, content);
                string contentString = await response.Content.ReadAsStringAsync();
                if(IsTherePeople(contentString))
                {
                    FaceAPI.MakeAnalysisRequest(image);
                }
            }
        }
        public static byte[] ImageToByteArray(this System.Drawing.Image image)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }
        public static Boolean IsTherePeople(string json)
        {
            Boolean result=false;
            Vision dynamicObject = JsonConvert.DeserializeObject<Vision>(json);
            foreach (VisionCategorie cat in dynamicObject.Categories)
            {
                if (cat.name == "_people" || cat.name == "people_portrait")
                {
                    result = true;
                }
            }
            return result;
        }
    }
}
