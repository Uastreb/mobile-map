using ServerApi.Exceptions;
using ServerApi.Models;
using System.Net;
using System.Net.Http.Json;

namespace ServerApi.Extensions
{
    public static class ResponseExtensions
    {
        public static async Task<T> GetResult<T>(this HttpResponseMessage response, CancellationToken ct = default)
        {
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    {
                        var value = await response.Content.ReadFromJsonAsync<T>(ct);

                        return value;
                    }
                case HttpStatusCode.NoContent:
                    {
                        return default(T);
                    }
                case HttpStatusCode.Unauthorized:
                    {
                        throw new UnauthorizedAccessException();
                    }
                case HttpStatusCode.BadRequest:
                    {
                        var error = await response.Content.ReadFromJsonAsync<ErrorModel>(ct);
                        var exception = new BadRequestException()
                        {
                            Code = error.Code,
                            Message = error.Message,
                        };
                        throw exception;
                    }
                default:
                    {
                        throw new NotImplementedException($"Не удалось обработать статус код \"{response.StatusCode}\". Реализация для его не предусмотрена.");
                    }
            }
        }
    }
}
