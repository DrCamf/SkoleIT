using SkoleIT.Services;
using SkoleIT.ViewModels;
using SkoleIT.ViewModels.Dashboard;
using SkoleIT.ViewModels.Startup;
using SkoleIT.Views.Dashboard;
using SkoleIT.Views.Startup;

namespace SkoleIT;

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
       

        builder.Services.AddSingleton<ILoginService, LoginService>();
        builder.Services.AddSingleton<StudentCardService>();

        //Views
        builder.Services.AddSingleton<LoginPage>();
        builder.Services.AddSingleton<DashboardPage>();
        builder.Services.AddSingleton<LoadingPage>();
        builder.Services.AddSingleton<StudentDashboardPage>();


        //View Models
        builder.Services.AddSingleton<LoginPageViewModel>();
        builder.Services.AddSingleton<DashboardPageViewModel>();
        builder.Services.AddSingleton<LoadingPageViewModel>();
        builder.Services.AddSingleton<StudentDashboardPageViewModel>();




        return builder.Build();
	}
}
