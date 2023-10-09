namespace Bankomaten
{
    internal class Program
    {  // Skapat användare och pinkoder
        static string[] Användare = { "Ermin", "Christian", "Markus", "Shahram", "Fredrik" };
        static string[] PinKod = { "1111", "2222", "3333", "4444", "5555" };
        static string[] KontoÄgare = { "Ermin", "Christian", "Markus", "Shahram", "Fredrik" };


        static void Main(string[] args)
        {
            Console.WriteLine("----> Välkommen till bankomaten <----");

            bool Inloggad = false;
            int InloggningsFörsök = 0;

            while (!Inloggad && InloggningsFörsök < 3)
            {
                Console.WriteLine("Ange användarnamn:");
                string AnvändarNamn = Console.ReadLine();

                Console.WriteLine("Ange pinkod:");
                string AnvändarPin = Console.ReadLine();

                if (InloggningsKoll(AnvändarNamn, AnvändarPin))
                {
                    Inloggad = true;
                }
                else
                {
                    InloggningsFörsök++;
                    Console.WriteLine("Fel inloggningsuppgifter, maximalt tre försök!");
                }
            }

            if (Inloggad)
            {
                Console.WriteLine("Välj vad du vill göra i menyn:");
                Console.WriteLine("1. Se konton och saldon");
                Console.WriteLine("2. För över pengar mellan konton");
                Console.WriteLine("3. Uttag av pengar");
                Console.WriteLine("4. Logga ut");
                string val = Console.ReadLine();

                switch (val)
                {
                    case "1":

                        break;
                    case "2":

                        break;
                    case "3":

                        break;
                    case "4":

                        break;
                    default:
                        Console.WriteLine("Ogiltigt val. Försök igen.");
                        break;
                }
            }

            else
            {
                Console.WriteLine("Inloggning misslyckades. Din användar har låsts.");
            }
        }

        static bool InloggningsKoll(string Användarnamn, string AnvändarPin)
        {
            for (int i = 0; i < Användare.Length && i < PinKod.Length; i++)
            {
                if (Användare[i] == Användarnamn && PinKod[i] == AnvändarPin)
                {
                    return true;
                }
            }
            return false;
        }

    }


}




