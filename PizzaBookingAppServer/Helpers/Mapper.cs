using AutoMapper;
using PizzaBookingShared.Entities;
using PizzaBookingShared.ViewModel;

namespace PizzaBookingShared.Helpers
{
    public class Mapper : Profile
	{
        public Mapper()
        {
            CreateMap<RegisterViewModel, User>().
                ForMember(dest => dest.HashedPassword, opt => opt.MapFrom(src => src.Password));
        }
    }
}
