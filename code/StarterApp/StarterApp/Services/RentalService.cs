using StarterApp.Database.Models;

namespace StarterApp.Services;

public class RentalService
{
    private readonly List<Rental> _rentals = new();

    public List<Rental> GetRentals()
    {
        return _rentals;
    }

    public void RequestRental(Item item, string userName)
    {
        var rental = new Rental
        {
            Id = _rentals.Count + 1,
            ItemId = item.Id,
            ItemName = item.Name,
            UserName = userName,
            Status = "Pending",
            RequestDate = DateTime.Now
        };

        _rentals.Add(rental);
    }

    public void ApproveRental(int rentalId)
    {
        var rental = _rentals.FirstOrDefault(r => r.Id == rentalId);
        if (rental != null)
        {
            rental.Status = "Approved";
        }
    }

    public void RejectRental(int rentalId)
    {
        var rental = _rentals.FirstOrDefault(r => r.Id == rentalId);
        if (rental != null)
        {
            rental.Status = "Rejected";
        }
    }
}