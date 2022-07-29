namespace API_Core_BL.Options
{
    public class AuthOptions
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public string Key { get; set; }
        public int LifetimeDurationInSeconds { get; set; }
    }
}
