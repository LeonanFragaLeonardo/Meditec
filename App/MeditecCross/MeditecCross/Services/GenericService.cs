using MeditecCross.Helpers;
using MeditecCross.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MeditecCross.Services
{
    public class GenericService<T> : IGenericAPI<T>
    {
        private HttpClient httpClient;
        private List<T> listData;

        public GenericService()
        {
            string authDatax = string.Format("{0} {1}", "Bearer", "token");
            string authData = string.Format("{0}:{1}", "username", "1234");
            var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));
            httpClient = new HttpClient();
            httpClient.MaxResponseContentBufferSize = 256000;
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authHeaderValue);
            //httpClient.BaseAddress = new Uri(Constants.CONN.COMPLETEADDRESS);
        }



        public async Task<List<T>> GetDataListAsync(string resource)
        {
            listData = new List<T>();

            string httpErrorCode = "";
            try
            {
                HttpClient clientAux = new HttpClient();
                clientAux.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                clientAux.BaseAddress = new Uri(Constants.CONN.COMPLETEADDRESS);
                var response = await clientAux.GetAsync(resource); //threshold, sensor, cargo....
                httpErrorCode = response.StatusCode.ToString();
                if (response.IsSuccessStatusCode)
                {
                    var resJson = response.Content.ReadAsStringAsync().Result;
                    listData = JsonConvert.DeserializeObject<List<T>>(resJson);
                    return listData;
                }
                else
                {
                    return new List<T>();
                }
            }
            catch (HttpRequestException e)
            {
                return null;
            }
        }

        public async Task<HttpResponseMessage> SaveAsync(T generic, bool isNew, string resource)
        {
            //string httpErrorCode = "";
            HttpClient clientAux = new HttpClient();
            clientAux.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            clientAux.BaseAddress = new Uri(Constants.CONN.COMPLETEADDRESS);

            var json = JsonConvert.SerializeObject(generic);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            //HttpResponseMessage response = null;
            return isNew ? await clientAux.PostAsync(resource, content) : await clientAux.PutAsync(resource, content);
            // response = isNew ? await clientAux.PostAsync(resource, content) : await clientAux.PutAsync(resource, content);
            //httpErrorCode = response.StatusCode.ToString();
            //return response.IsSuccessStatusCode;
            /*
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return (T)Activator.CreateInstance(typeof(T));
            }*/
        }
        public async Task<T> GetById(dynamic id, string resource)
        {
            string httpErrorCode = "";
            HttpClient clientAux = new HttpClient();
            clientAux.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            clientAux.BaseAddress = new Uri(Constants.CONN.COMPLETEADDRESS);
            var response = await clientAux.GetAsync(resource); //threshold, sensor, cargo....
            httpErrorCode = response.StatusCode.ToString();
            if (response.IsSuccessStatusCode)
            {
                var resJson = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<T>(resJson);
            }
            else
            {
                return (T)Activator.CreateInstance(typeof(T));
            }
        }
        public async Task<T> GetWithPostById(dynamic id, string resource)
        {
            HttpClient clientAux = new HttpClient();
            clientAux.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            clientAux.BaseAddress = new Uri(Constants.CONN.COMPLETEADDRESS);

            try
            {
                var json = JsonConvert.SerializeObject(id);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;

                //response = await client.PutAsync(uri, content);
                var url = Constants.CONN.COMPLETEADDRESS + resource;
                response = await clientAux.PostAsync(Constants.CONN.COMPLETEADDRESS + resource, content);
                //var reply = await client.PostAsync(uri, content);
                //if (response is null)
                //    throw new HttpRequestException();
                var resultString = await response.Content.ReadAsStringAsync();
                var type = (T)Activator.CreateInstance(typeof(T));
                var p = JsonConvert.DeserializeAnonymousType(resultString, type);
                var x = JsonConvert.DeserializeObject<T>(resultString);
                return x;
                //var code = JsonConvert.DeserializeObject<Code>(x.Content.ReadAsStringAsync());
                //return resultString;
            }
            catch (Exception ex)
            {
                //TODO ta dando Date Exception.
                //Device.BeginInvokeOnMainThread(async () =>
                //{
                if (ex is HttpRequestException)
                    Debug.WriteLine($"The server is inaccessible, so we can not authenticate it now. Sorry for the inconvenience and try again later.");
                //await App.Current.MainPage.DisplayAlert("Server Error!", $"The server is inaccessible, so we can not authenticate it now. Sorry for the inconvenience and try again later.", "Ok");
                if (ex is TimeoutException)
                    Debug.WriteLine($"The server is inaccessible, so we can not authenticate it now. Sorry for the inconvenience and try again later.");
                //await App.Current.MainPage.DisplayAlert("Timeout!", $"The server is inaccessible, so we can not authenticate it now. Sorry for the inconvenience and try again later.", "Ok");
                if (ex is ArgumentNullException)
                    Debug.WriteLine($"The server is inaccessible, so we can not authenticate it now. Sorry for the inconvenience and try again later.");
                //await App.Current.MainPage.DisplayAlert("Not found!", $"We didn't found this information. Please, authenticate again.", "Ok");
                //});
                return (T)Activator.CreateInstance(typeof(T));
            }


            /*
            string httpErrorCode = "";
            var response = await clientAux.PostAsync(resource, uri); //threshold, sensor, cargo....
            httpErrorCode = response.StatusCode.ToString();
            if (response.IsSuccessStatusCode)
            {
                var resJson = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<T>(resJson);
            }
            else
            {
                return (T)Activator.CreateInstance(typeof(T));
            }*/
        }
        public async Task<List<T>> GetListWithPostById(dynamic id, string resource)
        {
            HttpClient clientAux = new HttpClient();
            clientAux.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            clientAux.BaseAddress = new Uri(Constants.CONN.COMPLETEADDRESS);
            string authData = string.Format("{0}:{1}", "username", "1234");
            var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));
            clientAux.MaxResponseContentBufferSize = 256000;
            clientAux.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authHeaderValue);
            try
            {
                var json = JsonConvert.SerializeObject(id);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;

                var url = Constants.CONN.COMPLETEADDRESS + resource;
                response = await httpClient.PostAsync(Constants.CONN.COMPLETEADDRESS + resource, content);
                if (response is null)
                    throw new HttpRequestException();
                var resultString = await response.Content.ReadAsStringAsync();
                var x = JsonConvert.DeserializeObject<List<T>>(resultString);
                return x;
            }
            catch (Exception ex)
            {
                if (ex is HttpRequestException)
                    await App.Current.MainPage.DisplayAlert("Server Error!", $"The server is inaccessible, so we can not authenticate it now. Sorry for the inconvenience and try again later.", "Ok");
                if (ex is TimeoutException)
                    await App.Current.MainPage.DisplayAlert("Timeout!", $"The server is inaccessible, so we can not authenticate it now. Sorry for the inconvenience and try again later.", "Ok");
                if (ex is ArgumentNullException)
                    await App.Current.MainPage.DisplayAlert("Not found!", $"We didn't found this information. Please, authenticate again.", "Ok");
                if (ex is JsonException)
                    await App.Current.MainPage.DisplayAlert("Json Error", $"Check this: {ex.Message} \n {ex.HelpLink}", "Ok");


                return (List<T>)Activator.CreateInstance(typeof(List<T>));
            }
        }

        public async Task<T> GetWithSecurityAsync(dynamic id, string resource, string authValue)
        {
            HttpClient clientAux = new HttpClient();
            //var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authValue));
            clientAux = new HttpClient();
            clientAux.MaxResponseContentBufferSize = 256000;
            clientAux.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Authorization", authValue);
            clientAux.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            clientAux.BaseAddress = new Uri(Constants.CONN.COMPLETEADDRESS);
            try
            {
                var json = JsonConvert.SerializeObject(id);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;
                var url = Constants.CONN.COMPLETEADDRESS + resource;
                response = await clientAux.PostAsync(Constants.CONN.COMPLETEADDRESS + resource, content);
                if (response is null)
                    throw new HttpRequestException();
                var resultString = await response.Content.ReadAsStringAsync();
                var x = JsonConvert.DeserializeObject<T>(resultString);
                return x;
            }
            catch (Exception ex)
            {
                if (ex is HttpRequestException)
                    await App.Current.MainPage.DisplayAlert("Server Error!", $"The server is inaccessible, so we can not authenticate it now. Sorry for the inconvenience and try again later.", "Ok");
                if (ex is TimeoutException)
                    await App.Current.MainPage.DisplayAlert("Timeout!", $"The server is inaccessible, so we can not authenticate it now. Sorry for the inconvenience and try again later.", "Ok");
                if (ex is ArgumentNullException)
                    await App.Current.MainPage.DisplayAlert("Not found!", $"We didn't found this information. Please, authenticate again.", "Ok");

                return (T)Activator.CreateInstance(typeof(T));
            }
            //return (List<T>)Activator.CreateInstance(typeof(List<T>));

        }
    }
}
