using AutoMapper;

namespace EmploymentSystem.Application.Common.Mappers
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
