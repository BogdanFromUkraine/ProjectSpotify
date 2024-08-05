namespace ProjectTrackingSpotify.Services
{
    public class PkceCode : IPkceCode
    {
        public string Challenge { get; set; }
        public string Verifier { get; set; }
    }
}
