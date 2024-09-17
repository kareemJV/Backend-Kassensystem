using Database;

namespace Oberfläche.UI
{
    public class BenutzerOberFläche
    {
        Produkt produkt = new Produkt();
        public void Add()
        {
            Console.WriteLine("Produkt Hinzufügen:");
            produkt.Name = Console.ReadLine();
            Console.WriteLine("Preis Hinzufügen:");
            produkt.Preis = Console.ReadLine();


            Console.WriteLine("Das Produkt " + produkt.Name + " wurde erfolgreich hinzugefügt!");


        }




    }
}