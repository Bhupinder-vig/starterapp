using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StarterApp.Database.Models;
using StarterApp.Services;

namespace StarterApp.ViewModels;

public partial class ItemsViewModel : ObservableObject
{
    private readonly ItemService _itemService;

    public ObservableCollection<Item> Items { get; set; } = new();

    public ItemsViewModel(ItemService itemService)
    {
        _itemService = itemService;
        LoadItems();
    }

    private void LoadItems()
    {
        Items.Clear();

        foreach (var item in _itemService.GetItems())
        {
            Items.Add(item);
        }
    }

    [RelayCommand]
    public void Refresh()
    {
        LoadItems();
    }
}