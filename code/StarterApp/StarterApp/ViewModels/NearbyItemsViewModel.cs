using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StarterApp.Database.Models;
using StarterApp.Services;

namespace StarterApp.ViewModels;

public partial class NearbyItemsViewModel : ObservableObject
{
    private readonly ItemService _itemService;
    private readonly LocationService _locationService;

    public ObservableCollection<Item> NearbyItems { get; set; } = new();

    public NearbyItemsViewModel(ItemService itemService, LocationService locationService)
    {
        _itemService = itemService;
        _locationService = locationService;

        LoadNearbyItems();
    }

    [RelayCommand]
    public void LoadNearbyItems()
    {
        NearbyItems.Clear();

        var userLocation = _locationService.GetUserLocation();

        foreach (var item in _itemService.GetItems())
        {
            // SIMPLE MERIT LOGIC:
            // If same location → consider "nearby"
            if (_locationService.IsNearby(userLocation, item.Location))
            {
                NearbyItems.Add(item);
            }
        }
    }
}