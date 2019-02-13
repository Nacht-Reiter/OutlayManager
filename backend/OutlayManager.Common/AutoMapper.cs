using AutoMapper;
using System.Linq;
using System;
using OutlayManager.Common.DTOs;
using OutlayManager.DataAccess.Models;

namespace OutlayManager.Common
{
    public class AutoMapper
    {
        public static IMapper GetDefaultMapper()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CurrencyDTO, Currency>();
                cfg.CreateMap<Currency, CurrencyDTO>();

                cfg.CreateMap<UserDTO, User>()
                    .ForMember(u => u.Account, opt => opt.MapFrom(udto => udto.Account));
                cfg.CreateMap<User, UserDTO>()
                    .ForMember(udto => udto.Account, opt => opt.MapFrom(u => u.Account));

                cfg.CreateMap<AccountDTO, Account>()
                    .ForMember(a => a.Categories, opt => opt.MapFrom(adto => adto.Categories))
                    .ForMember(a => a.User, opt => opt.MapFrom(adto => adto.User))
                    .ForMember(a => a.Currency, opt => opt.MapFrom(adto => adto.Currency))
                    .ForMember(a => a.Transactions, opt => opt.MapFrom(adto => adto.Transactions));
                cfg.CreateMap<Account, AccountDTO>()
                    .ForMember(adto => adto.Categories, opt => opt.MapFrom(a => a.Categories))
                    .ForMember(adto => adto.User, opt => opt.MapFrom(a => a.User))
                    .ForMember(adto => adto.Currency, opt => opt.MapFrom(a => a.Currency))
                    .ForMember(adto => adto.Transactions, opt => opt.MapFrom(a => a.Transactions));

                cfg.CreateMap<CategoryDTO, Category>()
                    .ForMember(c => c.Account, opt => opt.MapFrom(cdto => cdto.Account))
                    .ForMember(c => c.Transactions, opt => opt.MapFrom(cdto => cdto.Transactions));
                cfg.CreateMap<Category, CategoryDTO>()
                    .ForMember(cdto => cdto.Account, opt => opt.MapFrom(c => c.Account))
                    .ForMember(cdto => cdto.Transactions, opt => opt.MapFrom(c => c.Transactions));

                cfg.CreateMap<TransactionDTO, Transaction>()
                    .ForMember(t => t.Account, opt => opt.MapFrom(tdto => tdto.Account))
                    .ForMember(t => t.Category, opt => opt.MapFrom(tdto => tdto.Category));
                cfg.CreateMap<Transaction, TransactionDTO>()
                    .ForMember(tdto => tdto.Account, opt => opt.MapFrom(t => t.Account))
                    .ForMember(tdto => tdto.Category, opt => opt.MapFrom(t => t.Category));


            }).CreateMapper();
        }
    }
}
