using Crud.Application.Interfaces;
using Crud.Grpc.Mappers;
using Grpc.Core;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Runtime.CompilerServices;
using Google.Rpc;
using Google.Protobuf.WellKnownTypes;

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
            ArgumentNotNullOrEmpty(request.Name);
            
            await _personalInfoService.AddPersonalInfo(request.MapTo());
            return new PersonalInfoCreateReply
            {
                Message = "ثبت شد"
            };
        }

        public override async Task<PersonalInfoUpdateReply> Update(PersonalInfoUpdateRequest request, ServerCallContext context)
        {
            await _personalInfoService.UpdatePersonalInfo(request.MapTo());
            return new PersonalInfoUpdateReply
            {
                Message = "ویرایش شد"
            };
        }

        public override async Task<PersonalInfoDeleteReply> Delete(PersonalInfoDeleteRequest request, ServerCallContext context)
        {
            await _personalInfoService.DeletePersonalInfo(request.Id);
            return new PersonalInfoDeleteReply
            {
                Message = "حذف شد"
            };
        }

        public override async Task<PersonalInfoGetReply> Get(PersonalInfoGetRequest request, ServerCallContext context)
        {
            var personalInfo = await _personalInfoService.Get(request.Id);
            return personalInfo.MapTo();
        }

        /// <summary>
        /// one way to handle error
        /// </summary>
        /// <param name="value"></param>
        /// <param name="paramName"></param>
        public static void ArgumentNotNullOrEmpty(string value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (string.IsNullOrEmpty(value))
            {
                var status = new Google.Rpc.Status
                {
                    Code = (int)Code.InvalidArgument,
                    Message = "Bad request",
                    Details =
                {
                    Any.Pack(new Google.Rpc.BadRequest
                    {
                        FieldViolations =
                        {
                            new Google.Rpc.BadRequest.Types.FieldViolation { Field = paramName, Description = "Value is null or empty" }
                        }
                    })
                }
                };
                throw status.ToRpcException();
            }
        }
    }
}
