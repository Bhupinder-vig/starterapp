using System.Threading.Tasks;

namespace StarterApp.Services
{
    /// <summary>
    /// Defines location-based functionality for the application.
    /// Used to calculate distances and support "near me" search features.
    /// </summary>
    public interface ILocationService
    {
        /// <summary>
        /// Gets the user's current location.
        /// In a real app this would use GPS services.
        /// For coursework, this can be mocked or simulated.
        /// </summary>
        /// <returns>Latitude and Longitude as a tuple</returns>
        Task<(double Latitude, double Longitude)> GetCurrentLocationAsync();

        /// <summary>
        /// Calculates distance between two geographic points in kilometers.
        /// </summary>
        /// <param name="lat1">First latitude</param>
        /// <param name="lon1">First longitude</param>
        /// <param name="lat2">Second latitude</param>
        /// <param name="lon2">Second longitude</param>
        /// <returns>Distance in kilometers</returns>
        double CalculateDistance(double lat1, double lon1, double lat2, double lon2);
    }
}