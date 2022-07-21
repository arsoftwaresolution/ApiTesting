namespace ApiTesting
{
    public class AuthCredential
    {
        public string Domain { get; set; }

        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string Audience { get; set; }
        public string GrantType { get; set; }
        public string Scope { get; set; }
    }
}
