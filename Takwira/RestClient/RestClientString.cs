using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Takwira.RestClient
{
    class RestClientString<T>
    {
        private string WebServiceUrl { get; set; }
        public RestClientString(string path)
        {
            WebServiceUrl = path;

        }


        public async Task<List<T>> GetAsync()
        {
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(WebServiceUrl);

            var users = JsonConvert.DeserializeObject<List<T>>(json);

            return users;
        }

        public async Task<bool> PostAsync(T t)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(t);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PostAsync(WebServiceUrl, httpContent);

            return result.IsSuccessStatusCode;
        }

        public async Task<bool> PutAsync(string id, T t)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(t);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PutAsync(WebServiceUrl + "?Email=" + id, httpContent);

            return result.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var httpClient = new HttpClient();

            var response = await httpClient.DeleteAsync(WebServiceUrl + "?Email=" + id);

            return response.IsSuccessStatusCode;
        }

        public async Task<T> GetAsync(string id)
        {
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(WebServiceUrl + "/" + id);

            var user = JsonConvert.DeserializeObject<T>(json);

            return user;
        }
        public async Task<T> GetConnexionAsync(string email, string pass)
        {
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync("http://takwira.azurewebsites.net/api/Proprietaires/Connexion/"  + email + "/"+ pass);

            
            var user = JsonConvert.DeserializeObject<T>(json);
         
            return user;
        }
        public async Task<T> GetConnexionJoueurAsync(string email, string pass)
        {
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync("http://takwira.azurewebsites.net/api/Joueurs/Connexion/" + email + "/" + pass);


            var user = JsonConvert.DeserializeObject<T>(json);

            return user;
        }
        
    }
}
