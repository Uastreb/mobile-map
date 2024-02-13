using ServerApi.Routes.Base;

namespace ServerApi.Routes
{
    public class ProfileRoutes : BaseRoute
    {
        private const string ControllerName = "ClientProfile";
        public const string ControllerRoute = $"{Api}/{ControllerName}";


        public const string GetProfile = $"GetProfile";
        public static string GetProfileRoute()
            => $"{ControllerRoute}/{GetProfile}";

        public const string Logout = $"Logout";
        public static string LogoutRoute()
            => $"{ControllerRoute}/{Logout}";
    }
}
