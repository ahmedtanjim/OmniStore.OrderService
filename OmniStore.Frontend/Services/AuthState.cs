namespace OmniStore.Frontend.Services
{
    public class AuthState
    {
        public static string Token { get; set; } = string.Empty;
        public static bool IsLoggedIn => !string.IsNullOrEmpty(Token);
    }
}
