namespace Oberfläche.UI
{
    public class BenutzerOberFläche
    {
        string produkt;
        public void Add()
        {
            Console.WriteLine("Produkt Hinzufügen:");
            produkt = Console.ReadLine();

            Console.WriteLine("Das Produkt " + produkt + " wurde erfolgreich hinzugefügt!");


        }




    }
}