using Microsoft.AspNetCore.Components.WebView.Maui;
using MudBlazor.Services;
using Pokedex.Data;

namespace Pokedex;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.RegisterBlazorMauiWebView()
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddData();

		builder.Services.AddBlazorWebView();
		builder.Services.AddMudServices();

		return builder.Build();
	}
}
