using AutoMapper;
using Client.Interfaces.Entity;
using Client.Models;
using ServerApi.Managers.Guest;
using ServerApi.Managers.Profile;
using ServerApi.Models.Guest;

namespace Client.Services.Entity
{
    internal class IdentityService : IIdentityService
    {
        private readonly IGuestManager _guestManager;
        private readonly ITokenService _tokenService;
        private readonly IProfileManager _profileManager;
        IMapper _mapper;

        public IdentityService(IGuestManager guestManager, ITokenService tokenService, IMapper mapper, IProfileManager profileManager)
        {
            _guestManager = guestManager;
            _mapper = mapper;
            _tokenService = tokenService;
            _profileManager = profileManager;
        }

        /// <inheritdoc/>
        public async Task SendConfirmationCode(string phoneNumber)
        {
            await _guestManager.SendConfirmationCode(new ConfirmationCodeSM { PhoneNumber = phoneNumber });
        }

        /// <inheritdoc/>
        public async Task Login(string phoneNumber, string confirmationCode)
        {
            var token = await _guestManager.LoginPhone(new LoginPhoneSM()
            {
                PhoneNumber = phoneNumber,
                Code = confirmationCode,
            });

            var mappedToken = _mapper.Map<TokenSM, TokenVM>(token);
            await _tokenService.SetToken(mappedToken);
        }

        /// <inheritdoc/>
        public async Task RefreshToken()
        {
            var token = await _tokenService.GetToken();
            if (token != default)
            {
                var updatedToken = await _guestManager.UpdateAccessToken(token.RefreshToken);
                var mappedUpdatedToken = _mapper.Map<TokenSM, TokenVM>(updatedToken);
                await _tokenService.SetToken(mappedUpdatedToken);
            }
        }

        /// <inheritdoc/>
        public async Task Logout()
        {
            await _profileManager.Logout();
            _tokenService.ResetToken();
        }
    }
}
