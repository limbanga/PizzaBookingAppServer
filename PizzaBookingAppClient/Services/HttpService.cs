using Microsoft.AspNetCore.Components.Forms;
using PizzaBookingShared.Entities;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace PizzaBookingAppClient.Services
{
    public class HttpService
    {
        HttpClient _client;
        public HttpService(HttpClient client)
        {
            this._client = client;
        }

        public async Task<T> Create<T>(string uri,T model)
        {
            var respone = await _client.PostAsJsonAsync<T>(uri, model);

            if (respone == null)
            {
                throw new Exception("respone is null");
            }

            if (!respone.IsSuccessStatusCode)
            {
                throw new Exception(respone.StatusCode.ToString());
            }

            return model;
        }
        public async Task<T> Update<T>(string uri, T model)
        {
            var respone = await _client.PutAsJsonAsync<T>(uri, model);

            if (respone == null)
            {
                throw new Exception("respone is null");
            }

            if (!respone.IsSuccessStatusCode)
            {
                throw new Exception(respone.StatusCode.ToString());
            }

            return model;
        }

        public async Task<T> Get<T>(string uri, int id)
        {
            var respone = await _client.GetAsync($"{uri}/{id}");

            if (respone == null)
            {
                throw new Exception("respone is null");
            }

            if (!respone.IsSuccessStatusCode)
            {
                throw new Exception(respone.StatusCode.ToString());
            }

            T? model = await respone.Content.ReadFromJsonAsync<T>();
            return model!;
        }

        public async Task<List<T>> GetAll<T>(string uri)
        {
            var respone = await _client.GetAsync(uri);

            if (respone == null)
            {
                throw new Exception("respone is null");
            }

            if (!respone.IsSuccessStatusCode)
            {
                throw new Exception(respone.StatusCode.ToString());
            }

            List<T>? list = await respone.Content.ReadFromJsonAsync<List<T>>();
            return list!;
        }

        public async Task<Int32> Count(string uri)
        {
            var respone = await _client.GetAsync(uri);

            if (respone == null)
            {
                throw new Exception("respone is null");
            }

            if (!respone.IsSuccessStatusCode)
            {
                throw new Exception(respone.StatusCode.ToString());
            }

            int count = await respone.Content.ReadFromJsonAsync<Int32>();
            return count!;
        }

        public async Task<string> PostFile(IBrowserFile file)
        {

            var content = new MultipartFormDataContent();
            content.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data");

            content.Add(new StreamContent(file.OpenReadStream()), "file", file.Name);

            var response = await _client.PostAsync("/upload", content);

            if (response == null)
            {
                throw new Exception("respone is null");
            }

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.StatusCode.ToString());
            }

            string newFileName = await response.Content.ReadAsStringAsync();
            return newFileName;
        }   
    }
}
