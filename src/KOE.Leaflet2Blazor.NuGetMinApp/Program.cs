using KOE.Leaflet2Blazor.NuGetMinApp.Components;
using KOE.Leaflet2Blazor.DependencyInjection;

namespace KOE.Leaflet2Blazor.NuGetMinApp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();

        // NEED for Leaflet2Blazor
        builder.Services.AddBlazorLeafletMaps();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if(!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();
        app.UseAntiforgery();

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        app.Run();
    }
}

