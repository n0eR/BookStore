using AutoMapper;
using BookStore.Client.DTO;
using BookStore.Client.Requests.Create;
using BookStore.Client.Requests.Update;
using BookStore.Domain.Models;

namespace BookStore.WebAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<DataAccess.Entities.Book, Domain.Book>();
            CreateMap<DataAccess.Entities.Customer, Domain.Customer>();
            CreateMap<DataAccess.Entities.Order, Domain.Order>();

            CreateMap<Domain.Book, BookDTO>();
            CreateMap<Domain.Customer, CustomerDTO>()
                .ForMember(x => x.FullName, s => s.MapFrom(x => $"{x.FirstName} {x.LastName}"));
            CreateMap<Domain.Order, OrderDTO>();

            CreateMap<BookCreateDTO, BookUpdateModel>();
            CreateMap<BookUpdateDTO, BookUpdateModel>();
            CreateMap<BookUpdateModel, DataAccess.Entities.Book>();

            CreateMap<CustomerCreateDTO, CustomerUpdateModel>();
            CreateMap<CustomerUpdateDTO, CustomerUpdateModel>();
            CreateMap<CustomerUpdateModel, DataAccess.Entities.Customer>();

            CreateMap<OrderCreateDTO, OrderUpdateModel>();
            CreateMap<OrderUpdateDTO, OrderUpdateModel>();
            CreateMap<OrderUpdateModel, DataAccess.Entities.Order>();
        }
    }
}