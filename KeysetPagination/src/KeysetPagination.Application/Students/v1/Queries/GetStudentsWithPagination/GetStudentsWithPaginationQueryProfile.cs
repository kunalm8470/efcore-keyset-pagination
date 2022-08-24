using AutoMapper;
using KeysetPagination.Domain.Models;
using System.Globalization;

namespace KeysetPagination.Application.Students.v1.Queries.GetStudentsWithPagination;

public class GetStudentsWithPaginationQueryProfile : Profile
{
	public GetStudentsWithPaginationQueryProfile()
	{
        CreateMap<Student, StudentDto>()
        .ForMember(s => s.DateOfBirth, opt => opt.MapFrom(y => y.DateOfBirth.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture)))
        .ForMember(s => s.Gender, opt => opt.MapFrom(src => src.Gender.ToString()))
        .ForMember(s => s.CreatedAt, opt => opt.MapFrom(y => y.CreatedUtcTicks))
        .ForMember(s => s.UpdatedAt, opt => opt.MapFrom(y => y.UpdatedUtcTicks))
        .ForMember(s => s.DeletedAt, opt => opt.MapFrom(y => y.DeletedUtcTicks));
    }
}
