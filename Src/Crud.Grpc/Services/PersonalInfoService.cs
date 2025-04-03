using Crud.Application.Interfaces;
using Crud.Grpc.Mappers;
using Grpc.Core;

namespace Crud.Grpc.Services
{
    public class PersonalInfoService : PersonalInfo.PersonalInfoBase
    {
        private readonly IPersonalInfoService _personalInfoService;

        public PersonalInfoService(IPersonalInfoService personalInfoService)
        {
            _personalInfoService = personalInfoService;
        }

        public override async Task<PersonalInfoCreateReply> Create(PersonalInfoCreateRequest request, ServerCallContext context)
        {
            await _personalInfoService.AddPersonalInfo(request.MapTo());
            return new PersonalInfoCreateReply
            {
                Message = "200"
            };
        }

        public override async Task<PersonalInfoUpdateReply> Update(PersonalInfoUpdateRequest request, ServerCallContext context)
        {
            await _personalInfoService.UpdatePersonalInfo(request.MapTo());
            return new PersonalInfoUpdateReply
            {
                Message = "200"
            };
        }

        public override async Task<PersonalInfoDeleteReply> Delete(PersonalInfoDeleteRequest request, ServerCallContext context)
        {
            await _personalInfoService.DeletePersonalInfo(request.Id);
            return new PersonalInfoDeleteReply
            {
                Message = "200"
            };
        }

        public override async Task<PersonalInfoGetReply> Get(PersonalInfoGetRequest request, ServerCallContext context)
        {
            var personalInfo = await _personalInfoService.Get(request.Id);
            return personalInfo.MapTo();
        }
    }
}
