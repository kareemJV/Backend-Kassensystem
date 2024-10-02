using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
        int input;
        do
        {
            Console.WriteLine("Bitte Wählen:");
            Console.WriteLine("1. Produkt Hinzufügen");
            Console.WriteLine("2. Produkt löschen");
            Console.WriteLine("3. Alle anzeigen");
            Console.WriteLine("0. Programm schließen");

            input = int.Parse(Console.ReadLine());
            switch (input)
            {
                case 1:
                    service.Add();
                    break;

                case 2:
                    service.Delete();
                    break;

                case 3:

                case 0:
                    Console.WriteLine("Auf wieder sehen !");
                    break;
            }
        } while (input != 0);
    }
}