namespace ProjectTrackingSpotify.Services
{
    public interface IPkceCode
    {
         string Challenge { get; set; }
         string Verifier { get; set; }
    }
}
