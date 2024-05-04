using MauiApp2.Components.Services;
using Microsoft.Extensions.Logging;

namespace MauiApp2
{
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
                });
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://zfnw9058-7025.asse.devtunnels.ms") }); //Working for Windows System only for now 

            //Trying this but have SSL issue 
            //builder.Services.AddScoped(sp =>
            //{
            //    var httpClient = new HttpClient();
            //    httpClient.BaseAddress = DeviceInfo.Platform == DevicePlatform.Android ?
            //        new Uri("https://l65nsmvx-5156.uks1.devtunnels.ms") :
            //        new Uri("https://localhost:5156");
            //    return httpClient;
            //});

            //HttpClientHandler clientHandler = new HttpClientHandler();
            //clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            //// Pass the handler to httpclient(from you are calling api)
            //HttpClient client = new HttpClient(clientHandler);


            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
