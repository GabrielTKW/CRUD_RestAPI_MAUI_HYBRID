using Shared.Models;


namespace MauiApp2.Components.Services
{
    internal interface IUserService
    {
        Task<IEnumerable<Users>> GetUsers();
        Task<Users> GetUser(string id);
        Task<bool> PutUser(string id, Users user);
        Task<Users> PostUser(Users user);
        Task<bool> DeleteUser(string id);
    }
}
