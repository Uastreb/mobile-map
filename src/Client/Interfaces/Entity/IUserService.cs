using Client.Models;

namespace Client.Interfaces.Entity
{
    public interface IUserService : IService
    {
        /// <summary>
        /// Получает профиль пользователя
        /// </summary>
        /// <returns>Профиль пользователя</returns>
        public Task<UserVM> GetPofile();
    }
}
