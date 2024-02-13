namespace Client.Interfaces.Entity
{
    public interface IIdentityService : IService
    {
        /// <summary>
        /// Отправляет запрос на отправку проверочного кода на номер телефона
        /// </summary>
        /// <param name="phoneNumber">Номер телефона</param>
        Task SendConfirmationCode(string phoneNumber);

        /// <summary>
        /// Выполняет авторизацию
        /// </summary>
        /// <param name="phoneNumber">Номер телефона</param>
        /// <param name="confirmationCode">Проверочный код</param>
        Task Login(string phoneNumber, string confirmationCode);

        /// <summary>
        /// Обновляет токен
        /// </summary>
        Task RefreshToken();

        /// <summary>
        /// Выполняет выход из приложения
        /// </summary>
        Task Logout();
    }
}
