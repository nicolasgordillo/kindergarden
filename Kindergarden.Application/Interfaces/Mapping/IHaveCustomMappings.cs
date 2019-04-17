using AutoMapper;

namespace Kindergarden.Application.Interfaces.Mapping
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(Profile configuration);
    }
}
