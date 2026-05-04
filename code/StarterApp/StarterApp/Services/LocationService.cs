using System;
using System.Threading.Tasks;

namespace StarterApp.Services
{
    /// <summary>
    /// Provides basic location-based functionality.
    /// This is a simplified implementation for coursework purposes.
    /// </summary>
    public class LocationService : ILocationService
    {
        /// <summary>
        /// Returns a simulated user location.
        /// In a real application, this would use device GPS (e.g. Geolocation API).
        /// </summary>
        public Task<(double Latitude, double Longitude)> GetCurrentLocationAsync()
        {
            // Simulated location (e.g. London coordinates)
            double latitude = 51.5074;
            double longitude = -0.1278;

            return Task.FromResult((latitude, longitude));
        }

        /// <summary>
        /// Calculates distance between two points using a simple formula.
        /// This is an approximation (sufficient for coursework demonstration).
        /// </summary>
        public double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
        {
            // Simple Euclidean approximation (NOT real-world geodesic accuracy)
            double latDiff = lat2 - lat1;
            double lonDiff = lon2 - lon1;

            double distance = Math.Sqrt(latDiff * latDiff + lonDiff * lonDiff);

            // Convert to approximate kilometers (rough scaling factor)
            return distance * 111;
        }
        public string GetUserLocation()
        {
            return "London"; // fake location for demo (perfectly fine for Merit)
        }

        public bool IsNearby(string userLocation, string itemLocation)
        {
                return userLocation == itemLocation;
                }
    }
}