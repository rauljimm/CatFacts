﻿using CatFacts.Services;
using CatFacts.ViewModels;
using CatFacts.Views;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace CatFacts;

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
            })
            .UseMauiCommunityToolkit();

        // Registro de servicios
        builder.Services.AddHttpClient();
        builder.Services.AddSingleton<ICatFactService, CatFactService>();
        builder.Services.AddSingleton<IBreedService, BreedService>();
        builder.Services.AddSingleton<INavigationService, NavigationService>();
        builder.Services.AddSingleton<IDatabaseService>(provider =>
            new DatabaseService(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "catfacts.db3")));

        // Registro de ViewModels
        builder.Services.AddSingleton<MainViewModel>();
        builder.Services.AddSingleton<CatFactViewModel>();
        builder.Services.AddSingleton<BreedViewModel>();

        // Registro de páginas
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<CatFactPage>();
        builder.Services.AddTransient<BreedPage>();

        // Hacer IServiceProvider disponible
        builder.Services.AddSingleton<IServiceProvider>(provider => provider);

        return builder.Build();
    }
}