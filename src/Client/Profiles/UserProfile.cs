using AutoMapper;
using Client.Models;
using ServerApi.Models.Profile;

namespace Client.Profiles
{
    internal class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserProfileSM, UserVM>();

        }
    }
}
