using Client.Interfaces.Entity;
using Client.Interfaces.System;
using Client.Models;

namespace Client.Services.Entity
{
    internal class TokenService : ITokenService
    {
        private readonly ILocalStorageService _localStorageService;

        public TokenService(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        /// <inheritdoc/>
        public Task<TokenVM> GetToken()
        {
            var tokenTask = _localStorageService.GetValue<TokenVM>();

            return tokenTask;
        }

        /// <inheritdoc/>
        public Task SetToken(TokenVM token)
        {
            return _localStorageService.SetValue(token);
        }

        /// <inheritdoc/>
        public void ResetToken()
        {
            _localStorageService.ResetValue<TokenVM>();
        }
    }
}
