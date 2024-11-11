using AluraSearcherRPA.Application.DTOs;
using AluraSearcherRPA.Domain.DTOs;
using AluraSearcherRPA.Domain.Entities;
using AutoMapper;

namespace AluraSearcherRPA.Application.Mappers
{
    public class CourseInfoProfile : Profile
    {
        public CourseInfoProfile()
        {
            CreateMap<SearchResult, CourseDataDTO>();
            CreateMap<SearchResult, HistoryResponseDTO>()
                .ForMember(dest => dest.SearchResponseData, opt => opt.MapFrom(src => new List<CourseDataDTO> { new CourseDataDTO
                {
                    Title = src.Title,
                    Instructor = src.Instructor,
                    Duration = src.Duration,
                    Description = src.Description
                }}));
        }
    }
}
