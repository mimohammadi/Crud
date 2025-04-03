
using Crud.Application.Dtos;

namespace Crud.Application.Interfaces
{
    public interface IPersonalInfoService
    {
        Task<IEnumerable<PersonalInfoDto>> GetPersonalInfos();
        Task<PersonalInfoDto> Get(long id);
        Task AddPersonalInfo(PersonalInfoCreateDto dto);
        Task DeletePersonalInfo(long id);
        Task UpdatePersonalInfo(PersonalInfoDto dto);
    }
}
