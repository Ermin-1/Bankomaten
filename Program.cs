namespace Bankomaten
{
    internal class Program
    {
        static string[] Användare = { "Ermin", "Christian", "Markus", "Shahram", "Fredrik" };
        static string[] PinKod = { "1111", "2222", "3333", "4444", "5555" };
        static string[] KontoÄgare = { "Ermin", "Christian", "Markus", "Shahram", "Fredrik" };

        static void Main(string[] args)
        {
            Console.WriteLine("----> Välkommen till bankomaten <----");

            bool Inloggad = false;
            int InloggningsFörsök = 0;

            while (!Inloggad) 
            {
                Console.WriteLine("Ange användarnamn:");
                string AnvändarNamn = Console.ReadLine();

                Console.WriteLine("Ange pinkod:");
                string AnvändarPin = Console.ReadLine();
                
            }
        }
    }
}