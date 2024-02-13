using AutoMapper;
using Client.Interfaces.Entity;
using Client.Models;
using ServerApi.Managers.Profile;
using ServerApi.Models.Profile;

namespace Client.Services.Entity
{
    internal class UserService : IUserService
    {
        private readonly IMapper _mapper;

        private readonly IProfileManager _profileManager;

        public UserService(IProfileManager profileManager, IMapper mapper) 
        {
            _profileManager = profileManager;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<UserVM> GetPofile()
        {
            var profile = await _profileManager.GetProfile();
            var mappedProfile = _mapper.Map<UserProfileSM, UserVM>(profile);

            return mappedProfile;
        }
    }
}
