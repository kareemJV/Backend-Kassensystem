using Database;

namespace Oberfläche.UI
{
    public class BenutzerOberFläche
    {
        public BenutzerOberFläche()
        { }

        public void UI()
        {
            Console.WriteLine("Bitte Wählen:");
            Console.WriteLine("1. Produkt Hinzufügen");
            Console.WriteLine("2. Produkt löschen");
            Console.WriteLine("3. Alle anzeigen");
            Console.WriteLine("0. Programm schließen");
        }
    }
}