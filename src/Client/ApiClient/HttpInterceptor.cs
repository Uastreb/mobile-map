using Client.Interfaces.Entity;
using System.Net.Http.Headers;

namespace Client.ApiClient
{
    public class HttpInterceptor : DelegatingHandler
    {
        private readonly ITokenService _tokenService;

        public HttpInterceptor(ITokenService tokenService) 
        {
            InnerHandler = new HttpClientHandler();

            _tokenService = tokenService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = await _tokenService.GetToken();
            if (token != default)
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);
            }

            var response = await base.SendAsync(request, cancellationToken);

            return response;
        }
    }
}
