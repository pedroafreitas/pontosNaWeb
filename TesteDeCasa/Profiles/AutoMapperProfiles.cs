using AutoMapper;
using TesteDeCasa.Dtos;
using TesteDeCasa.Models;

namespace TesteDeCasa.Profiles
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<RegisterNewAccountDto, Account>();

            CreateMap<UpdateAccountDto, Account>();

            CreateMap<Account, GetAccountDto>();
        }
    }
}