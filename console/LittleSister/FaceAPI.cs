using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Helpers;

namespace LittleSister
{
        public static class FaceAPI
        {
            const string subscriptionKey = "833e45378bb14f87a44898058d0fd694";
            const string uriBase = "https://westcentralus.api.cognitive.microsoft.com/face/v1.0/detect";
            public static async void MakeAnalysisRequest(Image image)
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);
                string requestParameters = "returnFaceId=true&returnFaceLandmarks=false&returnFaceAttributes=age,gender,headPose,smile,facialHair,glasses,emotion,hair,makeup,occlusion,accessories,blur,exposure,noise";
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

                    // Display the JSON response.
                    Console.WriteLine("\nResponse:\n");
                    Console.WriteLine(JsonPrettyPrint(contentString));
                    CreateNewFace(byteData);
                }
            }
            public static async void CreateNewFace(byte[] image2)
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);
                string uri = "https://westcentralus.api.cognitive.microsoft.com/face/v1.0/facelists/2/persistedFaces";
                HttpResponseMessage response;
                byte[] byteData = image2;

                using (ByteArrayContent content = new ByteArrayContent(byteData))
                {
                    // This example uses content type "application/octet-stream".
                    // The other content types you can use are "application/json" and "multipart/form-data".
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

                    // Execute the REST API call.
                    response = await client.PostAsync(uri, content);

                    // Get the JSON response.
                    string contentString = await response.Content.ReadAsStringAsync();

                    // Display the JSON response.
                    Console.WriteLine("\nResponse:\n");
                    Console.WriteLine(JsonPrettyPrint(contentString));
                }

        }
        public static byte[] ImageToByteArray(Image image)
            {
                using (var ms = new MemoryStream())
                {
                    image.Save(ms, image.RawFormat);
                    return ms.ToArray();
                }
            }
        static string JsonPrettyPrint(string json)
            {
                if (string.IsNullOrEmpty(json))
                    return string.Empty;

                json = json.Replace(Environment.NewLine, "").Replace("\t", "");

                StringBuilder sb = new StringBuilder();
                bool quote = false;
                bool ignore = false;
                int offset = 0;
                int indentLength = 3;

                foreach (char ch in json)
                {
                    switch (ch)
                    {
                        case '"':
                            if (!ignore) quote = !quote;
                            break;
                        case '\'':
                            if (quote) ignore = !ignore;
                            break;
                    }

                    if (quote)
                        sb.Append(ch);
                    else
                    {
                        switch (ch)
                        {
                            case '{':
                            case '[':
                                sb.Append(ch);
                                sb.Append(Environment.NewLine);
                                sb.Append(new string(' ', ++offset * indentLength));
                                break;
                            case '}':
                            case ']':
                                sb.Append(Environment.NewLine);
                                sb.Append(new string(' ', --offset * indentLength));
                                sb.Append(ch);
                                break;
                            case ',':
                                sb.Append(ch);
                                sb.Append(Environment.NewLine);
                                sb.Append(new string(' ', offset * indentLength));
                                break;
                            case ':':
                                sb.Append(ch);
                                sb.Append(' ');
                                break;
                            default:
                                if (ch != ' ') sb.Append(ch);
                                break;
                        }
                    }
                }

                return sb.ToString().Trim();
            }
        }
    }
