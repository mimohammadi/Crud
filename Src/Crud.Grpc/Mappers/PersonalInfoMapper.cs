using Crud.Application.Dtos;

namespace Crud.Grpc.Mappers
{
    public static class PersonalInfoMapper
    {
        public static PersonalInfoCreateDto MapTo(this PersonalInfoCreateRequest request)
        {
            return new PersonalInfoCreateDto
            {
                Name = request.Name,
                LastName = request.LastName,
                NationalId = request.NationalId,
                BirthDate = DateTime.TryParse(request.BirthDate, out DateTime result) ? result : DateTime.MinValue,
            };
        }

        public static PersonalInfoDto MapTo(this PersonalInfoUpdateRequest request)
        {
            return new PersonalInfoDto
            {
                Id = request.Id,
                Name = request.Name,
                LastName = request.LastName,
                NationalId = request.NationalId,
                BirthDate = DateTime.TryParse(request.BirthDate, out DateTime result) ? result : DateTime.MinValue,
            };
        }
        
        public static PersonalInfoGetReply MapTo(this PersonalInfoDto dto)
        {
            if (dto is null) return default;
            return new PersonalInfoGetReply
            {
                Id = dto.Id,
                Name = dto.Name,
                LastName = dto.LastName,
                NationalId = dto.NationalId,
                BirthDate = dto.BirthDate.ToString(),
            };
        }
    }
}
