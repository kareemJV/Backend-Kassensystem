using Database;
using Microsoft.Graph.Models;

public class Service
{
    private readonly MDbContext _context;

    // Stellt sicher, dass der DbContext durch Dependency Injection übergeben wird
    public Service(MDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));  // Vermeidet null-Kontext
    }

    public void Add()
    {
        Produkt produkt = new Produkt();  // Stelle sicher, dass dies nicht null ist

        Console.WriteLine("Produkt Hinzufügen:");
        produkt.Name = Console.ReadLine();

        Console.WriteLine("Preis Hinzufügen:");
        if (decimal.TryParse(Console.ReadLine(), out decimal preis))
        {
            produkt.Preis = (int)preis;

            // Füge das Produkt dem DbContext hinzu
            _context.Add(produkt);
            _context.SaveChanges();  // Speichere die Änderungen

            Console.WriteLine("Das Produkt " + produkt.Name + " wurde erfolgreich hinzugefügt!");
        }
        else
        {
            Console.WriteLine("Ungültiger Preis. Bitte geben Sie einen gültigen Dezimalwert ein.");
        }

    }

    public void Delete()
    {
        Produkt produkt = new Produkt();  // Stelle sicher, dass dies nicht null ist

        Console.WriteLine("Produkt ID eingeben:");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            produkt.ID = id;
            _context.Remove(produkt.ID);
            _context.SaveChanges();


        }
        else
        {
            Console.WriteLine("Ungültige ID. Bitte geben Sie eine gültige Zahl ein.");
        }


    }

}