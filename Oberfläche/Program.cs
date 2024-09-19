using Database;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Graph.Models;
using Microsoft.Graph.Models.Security;
using Oberfläche;
using Oberfläche.UI;
using System.Configuration;

public class Program
{
    public static void Main(string[] args)
    {
        var host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context, config) =>
            {
                config.SetBasePath(AppContext.BaseDirectory);  // Setzt das Basisverzeichnis
                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            })
            .ConfigureServices((context, services) =>
            {
                // Verwende den Connection String aus der Konfiguration
                var connectionString = context.Configuration.GetConnectionString("DefaultConnection");

                // Ausgabe des Connection Strings zur Überprüfung
                Console.WriteLine("ConnectionString: " + connectionString);

                if (string.IsNullOrWhiteSpace(connectionString))
                {
                    throw new Exception("Connection string is null or empty.");
                }

                // Füge den DbContext und den Service zur DI hinzu
                services.AddDbContext<MDbContext>(options =>
                    options.UseSqlServer(connectionString));

                services.AddTransient<Service>();
            })
            .Build();

        // Hole den Service aus der DI
        var service = host.Services.GetRequiredService<Service>();
        service.Add();
        service.Delete();

    }

}