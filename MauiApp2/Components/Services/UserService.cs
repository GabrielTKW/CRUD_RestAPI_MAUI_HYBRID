using Newtonsoft.Json;
using Shared.Models;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MauiApp2.Components.Services
{
    internal class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Users>> GetUsers()
        {


            try
            {
                var response = await _httpClient.GetAsync($"api/Users");

                // Check if the response is successful
                response.EnsureSuccessStatusCode();

                // Read the content as a string
                var content = await response.Content.ReadAsStringAsync();
                var users = JsonConvert.DeserializeObject<IEnumerable<Users>>(content);

                return users;

            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log or throw)
                string msg = ex.Message;
                return null;
            }
        }

        public async Task<Users> GetUser(string id)
        {
            var response = await _httpClient.GetAsync($"api/Users/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Users>();
        }

        public async Task<bool> PutUser(string id, Users user)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Users/{id}", user);
            return response.IsSuccessStatusCode;
        }

        public async Task<Users> PostUser(Users user)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Users", user);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Users>();
        }

        public async Task<bool> DeleteUser(string id)
        {
            var response = await _httpClient.DeleteAsync($"api/Users/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
