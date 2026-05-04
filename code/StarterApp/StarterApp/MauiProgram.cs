using Microsoft.Extensions.Logging;
using StarterApp.ViewModels;
using StarterApp.Database.Data;
using StarterApp.Views;
using StarterApp.Services;

namespace StarterApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // =========================
        // DATABASE (if used)
        // =========================
        builder.Services.AddDbContext<AppDbContext>();

        // =========================
        // CORE SERVICES (Tier 1 base)
        // =========================
        builder.Services.AddSingleton<IAuthenticationService, AuthenticationService>();
        builder.Services.AddSingleton<INavigationService, NavigationService>();

        builder.Services.AddSingleton<ItemService>(); // Tier 1 + used in Tier 2

        // =========================
        // TIER 2 SERVICES
        // =========================
        builder.Services.AddSingleton<LocationService>();
        builder.Services.AddSingleton<RentalService>();

        // =========================
        // APP CORE
        // =========================
        builder.Services.AddSingleton<AppShellViewModel>();
        builder.Services.AddSingleton<AppShell>();
        builder.Services.AddSingleton<App>();

        // =========================
        // TIER 1 FEATURE (Items)
        // =========================
        builder.Services.AddTransient<MainViewModel>();
        builder.Services.AddTransient<MainPage>();

        builder.Services.AddTransient<ItemsViewModel>();
        builder.Services.AddTransient<ItemsPage>();

        // =========================
        // TIER 2 FEATURE (Location / Nearby Items)
        // =========================
        builder.Services.AddTransient<NearbyItemsViewModel>();
        builder.Services.AddTransient<NearbyItemsPage>();

        // =========================
        // TIER 2 FEATURE (Rentals system)
        // =========================
        builder.Services.AddTransient<RentalsViewModel>();
        builder.Services.AddTransient<RentalsPage>();

        // =========================
        // AUTH PAGES
        // =========================
        builder.Services.AddSingleton<LoginViewModel>();
        builder.Services.AddTransient<LoginPage>();

        builder.Services.AddSingleton<RegisterViewModel>();
        builder.Services.AddTransient<RegisterPage>();

        // =========================
        // USERS (already in your project)
        // =========================
        builder.Services.AddTransient<UserListViewModel>();
        builder.Services.AddTransient<UserListPage>();

        builder.Services.AddTransient<UserDetailPage>();
        builder.Services.AddTransient<UserDetailViewModel>();

        // =========================
        // TEMP (testing)
        // =========================
        builder.Services.AddSingleton<TempViewModel>();
        builder.Services.AddTransient<TempPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}