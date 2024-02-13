using Client.Models;

namespace Client.Interfaces.Entity
{
    public interface ITokenService : IService
    {
        /// <summary>
        /// Сохраняет токен
        /// </summary>
        /// <param name="token">Токен</param>
        Task SetToken(TokenVM token);

        /// <summary>
        /// Получает токен
        /// </summary>
        /// <returns>Токен</returns>
        Task<TokenVM> GetToken();

        /// <summary>
        /// Очищает токен
        /// </summary>
        void ResetToken();
    }
}
