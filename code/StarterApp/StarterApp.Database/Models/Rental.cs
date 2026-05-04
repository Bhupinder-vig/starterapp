namespace StarterApp.Database.Models;

public class Rental
{
    public int Id { get; set; }

    public int ItemId { get; set; }

    public string UserName { get; set; } = string.Empty;

    public DateTime RequestDate { get; set; }

    public string Status { get; set; } = "Pending"; 
    // Pending / Approved / Rejected
}