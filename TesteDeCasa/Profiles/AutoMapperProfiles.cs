using AutoMapper;
using TesteDeCasa.Dtos;
using TesteDeCasa.Models;
using TestesDeCasa.Dtos;

namespace TesteDeCasa.Profiles
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<RegisterNewAccountDto, Account>();

            CreateMap<UpdateAccountDto, Account>();

            CreateMap<Account, GetAccountDto>();

            CreateMap<TransactionRequestDto, Transaction>();
        }
    }
}