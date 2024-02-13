using ServerApi.Models.Profile;

namespace ServerApi.Managers.Profile
{
    public interface IProfileManager : IManager
    {
        /// <summary>
        /// Получает профиль пользователя
        /// </summary>
        /// <returns>Профиль пользователя</returns>
        Task<UserProfileSM> GetProfile();

        /// <summary>
        /// Выходит из аккаунта
        /// </summary>
        Task Logout();
    }
}
