using Crud.Application.Dtos;
using Crud.Domain.Models.PersonalInfo;

namespace Crud.Application.Mappers
{
    public static class PersonalInfoMapper
    {
        public static PersonalInfo MapTo(this PersonalInfoCreateDto dto)
        {
            return new PersonalInfo(dto.Name, dto.LastName, dto.NationalId, dto.BirthDate);
        } 
        
        public static PersonalInfoDto MapTo(this PersonalInfo model)
        {
            return new PersonalInfoDto
            {
                Id = model.Id,
                Name = model.Name,
                LastName = model.LastName,
                NationalId = model.NationalId,
                BirthDate = model.BirthDate,
            };
        }

        public static IEnumerable<PersonalInfoDto> MapTo(this IEnumerable<PersonalInfo> model)
        { 
            return model.Select(a=>a.MapTo()).ToList();
        }
    }
}
