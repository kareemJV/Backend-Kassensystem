namespace Database
{
    public class Produkt
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Preis { get; set; }

        public override string ToString()
        {
            return $"Produkt ID: {ID}, Name: {Name}, Preis: {Preis:C}";
        }
    }
}