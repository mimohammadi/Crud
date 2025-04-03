using Crud.Application.Dtos;
using Crud.Application.Interfaces;
using Crud.Application.Mappers;
using Crud.Domain;
using Crud.Domain.Models.PersonalInfo;

namespace Crud.Application.Services
{
    public class PersonalInfoService : IPersonalInfoService
    {
        private readonly IRepository<PersonalInfo> _repository;

        public PersonalInfoService(IRepository<PersonalInfo> repository)
        {
            _repository = repository;
        }

        public async Task AddPersonalInfo(PersonalInfoCreateDto dto)
        {
            await _repository.Insert(dto.MapTo());
        }

        public async Task DeletePersonalInfo(long id)
        {
            var personalInfo = await _repository.Get(id);
            await _repository.Delete(personalInfo);
        }

        public async Task<PersonalInfoDto> Get(long id)
        {
            var personalInfo = await _repository.Get(id);
            return personalInfo.MapTo();
        }

        public async Task<IEnumerable<PersonalInfoDto>> GetPersonalInfos()
        {
            var personalInfos = await _repository.GetAll();
            return personalInfos.MapTo();
        }

        public async Task UpdatePersonalInfo(PersonalInfoDto dto)
        {
            var personalInfo = await _repository.Get(dto.Id);
            if (personalInfo is not null)
            {
                personalInfo.Update(dto.Name, dto.LastName, dto.NationalId, dto.BirthDate);
                await _repository.Update(personalInfo);
            }
        }
    }
}
