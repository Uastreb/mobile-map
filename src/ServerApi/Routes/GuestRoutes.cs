using ServerApi.Routes.Base;

namespace ServerApi.Routes
{
    public class GuestRoutes : BaseRoute
    {
        private const string ControllerName = "ClientGuest";
        public const string ControllerRoute = $"{Api}/{ControllerName}";


        public const string SendConfirmationCode = $"SendConfirmationCode";
        public static string SendConfirmationCodeRoute()
            => $"{ControllerRoute}/{SendConfirmationCode}";

        public const string LoginPhone = $"LoginPhone";
        public static string LoginPhoneRoute()
            => $"{ControllerRoute}/{LoginPhone}";

        public const string UpdateAccessToken = $"UpdateAccessToken";
        public static string UpdateAccessTokenRoute(string refreshToken)
            => $"{ControllerRoute}/{UpdateAccessToken}?refreshToken={refreshToken}";
    }
}
