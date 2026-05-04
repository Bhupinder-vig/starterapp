using StarterApp.ViewModels;

namespace StarterApp.Views;

public partial class ItemsPage : ContentPage
{
    public ItemsPage(ItemsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}