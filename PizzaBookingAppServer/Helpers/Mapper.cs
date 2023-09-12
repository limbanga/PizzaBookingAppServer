using AutoMapper;
using PizzaBookingAppServer.Entities;
using PizzaBookingViewModel;

namespace PizzaBookingAppServer.Helpers
{
	public class Mapper : Profile
	{
        public Mapper()
        {
            CreateMap<Employee, SignUpViewModel>().ReverseMap();
        }
    }
}
