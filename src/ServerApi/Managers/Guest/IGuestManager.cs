using ServerApi.Models.Guest;

namespace ServerApi.Managers.Guest
{
    public interface IGuestManager : IManager
    {
        /// <summary>
        /// Выполняет отправку проверочного кода на номер телефона
        /// </summary>
        /// <param name="code">Модель телефона</param>
        Task SendConfirmationCode(ConfirmationCodeSM code);

        /// <summary>
        /// Выполняет авторизацию по телефону
        /// </summary>
        /// <param name="phone">Телефон с кодом</param>
        /// <returns>Токены</returns>
        Task<TokenSM> LoginPhone(LoginPhoneSM phone);

        /// <summary>
        /// Отправляет запрос на обновление токена
        /// </summary>
        /// <param name="refreshToken">Токен обновления</param>
        /// <returns>Токены</returns>
        Task<TokenSM> UpdateAccessToken(string refreshToken);
    }
}
