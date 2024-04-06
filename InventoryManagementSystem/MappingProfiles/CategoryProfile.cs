using AutoMapper;
using InventoryManagementSystem.Db.Models;
using InventoryManagementSystem.Dtos;

namespace InventoryManagementSystem.MappingProfiles;
public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<Category, CategoryDto>().ReverseMap();
    }
}
