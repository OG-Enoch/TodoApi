using AutoMapper;
using TodoApi.DTOs;
using TodoApi.Models;
using TodoApi.RequestPayLoad;

namespace TodoApi.profile
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<ToDoItem, ToDoItemDto>().ReverseMap();
            CreateMap<ToDoItem, ToDoItemRequest>().ReverseMap();
        }

    }
}
