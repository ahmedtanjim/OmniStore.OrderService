using AutoMapper;
using OmniStore.OrderService.DTOs;
using OmniStore.OrderService.Models;

namespace OmniStore.OrderService.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<CreateOrderDto, Order>();
        }
    }
}