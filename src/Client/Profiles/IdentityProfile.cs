using AutoMapper;
using Client.Models;
using ServerApi.Models.Guest;

namespace Client.Profiles
{
    internal class IdentityProfile : Profile
    {
        public IdentityProfile() 
        {
            CreateMap<LoginVM, LoginPhoneSM>()
                .ForMember(x => x.PhoneNumber, opt => opt.MapFrom(y => y.Phone))
                .ForMember(x => x.Code, opt => opt.MapFrom(y => y.ConfirmationCode));

            CreateMap<TokenSM, TokenVM>()
                .ForMember(x => x.RefreshToken, opt => opt.MapFrom(y => y.RefreshToken))
                .ForMember(x => x.AccessToken, opt => opt.MapFrom(y => y.AccessToken));

        }
    }
}
