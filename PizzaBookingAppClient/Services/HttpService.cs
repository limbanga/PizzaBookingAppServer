using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using PizzaBookingAppClient.Exceptions;
using PizzaBookingShared.Entities;
using PizzaBookingShared.ViewModel;
using System;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Reflection;
using static System.Net.WebRequestMethods;

namespace PizzaBookingAppClient.Services
{
    public interface IHttpService
    {
        Task<T1?> PostAsync<T1, T2>(string uri, T2 model);
        Task PostAsync<T>(string uri, T model);
        Task<T> Create<T>(string uri, T model);
        Task<T> Update<T>(string uri, T model);
        Task<T> Get<T>(string uri, int id);
        Task<List<T>> GetAll<T>(string uri);
        Task<List<T>> GetAllBy<T>(string uri, string id);

		Task<Int32> Count(string uri);
        Task<string> PostFile(IBrowserFile file);
    }

    public class HttpService : IHttpService
    {
        private readonly HttpClient _client;
        public HttpService(HttpClient client)
        {
            this._client = client;
        }

        public async Task PostAsync<T>(string uri, T model)
        {
            var respone = await _client.PostAsJsonAsync<T>(uri, model);
            CheckRespone(respone);
        }

        public async Task<T1?> PostAsync<T1, T2>(string uri, T2 model)
        {
            var respone = await _client.PostAsJsonAsync<T2>(uri, model);

            CheckRespone(respone);

            T1? result = await respone.Content.ReadFromJsonAsync<T1>();
            return result;
        }

        private void CheckRespone(HttpResponseMessage? respone)
        {
            if (respone is null)
            {
                throw new Exception("PostAsync: Respone is null");
            }

            if (respone.StatusCode.Equals(HttpStatusCode.BadRequest))
            {
                throw new BadRequestException($"BadRequest: {respone.Content}");
            }

            if (respone.StatusCode.Equals(HttpStatusCode.Unauthorized))
            {
                throw new UnAthorizeException($"Unauthorized: {respone.Content}");
            }

            if (!respone.IsSuccessStatusCode)
            {
                throw new AppException($"Failed to call api: {respone.StatusCode}");
            }
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

		public async Task<T> Get<T>(string uri, string id)
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

		public async Task<List<T>> GetAllBy<T>(string uri, string id)
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
