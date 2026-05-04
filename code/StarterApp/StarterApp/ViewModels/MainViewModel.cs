/// @file MainViewModel.cs
/// @brief Main dashboard view model for authenticated users
/// @author StarterApp Development Team
/// @date 2025

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StarterApp.Database.Models;
using StarterApp.Services;
using System.Collections.ObjectModel;

namespace StarterApp.ViewModels;

public partial class MainViewModel : BaseViewModel
{
    private readonly IAuthenticationService _authService;
    private readonly INavigationService _navigationService;

    // =========================
    // AUTH / DASHBOARD (EXISTING)
    // =========================

    [ObservableProperty]
    private User? currentUser;

    [ObservableProperty]
    private string welcomeMessage = string.Empty;

    [ObservableProperty]
    private bool isAdmin;

    // =========================
    // SIMPLE ITEMS FEATURE (NEW)
    // =========================

    [ObservableProperty]
    private string newItemTitle = string.Empty;

    [ObservableProperty]
    private string newItemDescription = string.Empty;

    [ObservableProperty]
    private ObservableCollection<string> items = new();

    // =========================
    // CONSTRUCTORS
    // =========================

    public MainViewModel()
    {
        Title = "Dashboard";
    }

    public MainViewModel(IAuthenticationService authService, INavigationService navigationService)
    {
        _authService = authService;
        _navigationService = navigationService;

        Title = "Dashboard";

        LoadUserData();
    }

    // =========================
    // USER DATA
    // =========================

    private void LoadUserData()
    {
        if (_authService == null) return;

        CurrentUser = _authService.CurrentUser;
        IsAdmin = _authService.HasRole("Admin");

        if (CurrentUser != null)
        {
            WelcomeMessage = $"Welcome, {CurrentUser.FullName}!";
        }
    }

    // =========================
    // ITEMS FEATURE COMMANDS
    // =========================

    [RelayCommand]
    private void AddItem()
    {
        if (string.IsNullOrWhiteSpace(NewItemTitle))
            return;

        Items.Add($"{NewItemTitle} - {NewItemDescription}");

        NewItemTitle = string.Empty;
        NewItemDescription = string.Empty;
    }

    // =========================
    // EXISTING COMMANDS (UNCHANGED)
    // =========================

    [RelayCommand]
    private async Task LogoutAsync()
    {
        if (_authService == null) return;

        var result = await Application.Current.MainPage.DisplayAlert(
            "Logout",
            "Are you sure you want to logout?",
            "Yes",
            "No");

        if (result)
        {
            await _authService.LogoutAsync();
            await _navigationService.NavigateToAsync("LoginPage");
        }
    }

    [RelayCommand]
    private async Task NavigateToProfileAsync()
    {
        await _navigationService.NavigateToAsync("TempPage");
    }

    [RelayCommand]
    private async Task NavigateToSettingsAsync()
    {
        await _navigationService.NavigateToAsync("TempPage");
    }

    [RelayCommand]
    private async Task NavigateToUserListAsync()
    {
        if (!IsAdmin)
        {
            await Application.Current.MainPage.DisplayAlert(
                "Access Denied",
                "You don't have permission to access admin features.",
                "OK");
            return;
        }

        await _navigationService.NavigateToAsync("UserListPage");
    }

    [RelayCommand]
    private async Task RefreshDataAsync()
    {
        try
        {
            IsBusy = true;
            LoadUserData();
            await Task.Delay(500);
        }
        catch (Exception ex)
        {
            SetError($"Failed to refresh data: {ex.Message}");
        }
        finally
        {
            IsBusy = false;
        }
    }
}