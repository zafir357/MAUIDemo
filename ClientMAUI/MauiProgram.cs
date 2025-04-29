using ClientMAUI.Views.Pages;
using VM;
using Microsoft.Extensions.Logging;
using Model;
using StubLib;
using CommunityToolkit.Maui;

namespace ClientMAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .Services.AddSingleton<IDataManager, StubData>()
                .AddSingleton<DataManagerVM>()
                .AddSingleton<ChampionListPage>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}