using Client.Interfaces.System;
using System.Text.Json;

namespace Client.Services.System
{
    internal class LocalStorageService : ILocalStorageService
    {
        public LocalStorageService()
        {
        }

        /// <inheritdoc/>
        public async Task SetValue<TValue>(TValue value) where TValue : class
        {
            var jsonValue = JsonSerializer.Serialize<TValue>(value);

            await SecureStorage.Default.SetAsync(typeof(TValue).Name, jsonValue);
        }

        /// <inheritdoc/>
        public async Task<TValue> GetValue<TValue>() where TValue : class
        {
            var jsonValue = await SecureStorage.Default.GetAsync(typeof(TValue).Name);
            if (!string.IsNullOrEmpty(jsonValue))
            {
                var value = JsonSerializer.Deserialize<TValue>(jsonValue);

                return value;
            }
            return default(TValue);
        }

        /// <inheritdoc/>
        public void ResetValue<TValue>() where TValue : class
        {
            SecureStorage.Default.Remove(typeof(TValue).Name);
        }
    }
}
