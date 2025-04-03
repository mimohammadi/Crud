using Grpc.Core;
using Grpc.Core.Interceptors;

namespace Crud.Grpc.Interceptors
{
    public class ExceptionInterceptor: Interceptor
    {

        public ExceptionInterceptor()
        {
        }

        public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(TRequest request, ServerCallContext context, UnaryServerMethod<TRequest, TResponse> continuation)
        {
            var response = await base.UnaryServerHandler(request, context, continuation);

            return response;
        }
    }
}
