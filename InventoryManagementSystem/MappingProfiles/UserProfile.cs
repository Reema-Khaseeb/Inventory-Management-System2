using AutoMapper;
using InventoryManagementSystem.Db.Models;
using InventoryManagementSystem.Dtos.User;

namespace InventoryManagementSystem.MappingProfiles;
public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserResponse, User>().ReverseMap();
        CreateMap<UserRequest, User>().ReverseMap();
    }
}
