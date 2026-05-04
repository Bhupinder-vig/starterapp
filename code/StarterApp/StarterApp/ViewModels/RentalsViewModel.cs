using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StarterApp.Database.Models;
using StarterApp.Services;

namespace StarterApp.ViewModels;

public partial class RentalsViewModel : ObservableObject
{
    private readonly RentalService _rentalService;

    public ObservableCollection<Rental> Rentals { get; set; } = new();

    public RentalsViewModel(RentalService rentalService)
    {
        _rentalService = rentalService;
        LoadRentals();
    }

    [RelayCommand]
    public void LoadRentals()
    {
        Rentals.Clear();

        foreach (var rental in _rentalService.GetRentals())
        {
            Rentals.Add(rental);
        }
    }

    [RelayCommand]
    public void Approve(Rental rental)
    {
        _rentalService.ApproveRental(rental.Id);
        LoadRentals();
    }

    [RelayCommand]
    public void Reject(Rental rental)
    {
        _rentalService.RejectRental(rental.Id);
        LoadRentals();
    }
}