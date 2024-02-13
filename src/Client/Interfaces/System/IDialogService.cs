namespace Client.Interfaces.System
{
    public interface IDialogService : IService
    {
        /// <summary>
        /// Отображает диалоговое окно с одной кнопкой
        /// </summary>
        /// <param name="title">Заголовок</param>
        /// <param name="text">Текст</param>
        /// <param name="buttonText">Текст кнопки</param>
        Task DisplayAlert(string title, string text, string buttonText);

        /// <summary>
        /// Отображает диалоговое окно с двумя кнопками
        /// </summary>
        /// <param name="title">Заголовок</param>
        /// <param name="text">Текст</param>
        /// <param name="okButtonText">Текст кнопки согласия</param>
        /// <param name="cancelButtonText">Текст кнопки отмены</param>
        /// <returns>Результат</returns>
        Task<bool> DisplayAlert(string title, string text, string okButtonText, string cancelButtonText);
    }
}
