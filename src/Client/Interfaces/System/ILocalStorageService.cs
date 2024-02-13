namespace Client.Interfaces.System
{
    public interface ILocalStorageService : IService
    {
        /// <summary>
        /// Получает значение из хранилища
        /// </summary>
        /// <typeparam name="TValue">Тип значения</typeparam>
        /// <returns>Значение</returns>
        Task<TValue> GetValue<TValue>() where TValue : class;

        /// <summary>
        /// Записывает значение в хранилище
        /// </summary>
        /// <typeparam name="TValue">Тип значения</typeparam>
        /// <param name="value">Значение</param>
        Task SetValue<TValue>(TValue value) where TValue : class;

        /// <summary>
        /// Очищает значение
        /// </summary>
        /// <typeparam name="TValue">Тип значения</typeparam>
        void ResetValue<TValue>() where TValue : class;
    }
}
