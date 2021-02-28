namespace MoneyTracking.Options
{
    public static class AuthOptions
    {
        public static string SecretKey = "dk5f515q94t4zp3f";
        public static int TokenLifetimeInMinutes = 60*24;
        public static string Issuer = "MoneyTracking.Identity";
        public static string Audience = "MoneyTracking.ClientApp";
    }
}