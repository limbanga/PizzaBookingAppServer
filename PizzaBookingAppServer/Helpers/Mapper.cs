using AutoMapper;
using PizzaBookingShared.Entities;
using PizzaBookingShared.ViewModel;

namespace PizzaBookingShared.Helpers
{
    public class Mapper : Profile
	{
        public Mapper()
        {
            CreateMap<Employee, SignUpViewModel>().ReverseMap();
        }
    }
}
