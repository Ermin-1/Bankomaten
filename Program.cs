namespace Bankomaten
{
    internal class Program
    {  // Skapat användare och pinkoder, skapas som static annars kommer inte inloggningskollen åt den. Jugged array används. 
        static string[] Användare = { "Ermin", "Christian", "Markus", "Shahram", "Fredrik" };
        static string[] PinKod = { "1111", "2222", "3333", "4444", "5555" };
        static string[] KontoÄgare =   { "Ermin", "Christian", "Markus", "Shahram", "Fredrik" };
    static string[][] KontoNamn = {
        new string[] { "Lönekonto", "Sparkonto" },
        new string[] { "Lönekonto", "Sparkonto" },
        new string[] { "Lönekonto" },
        new string[] { "Lönekonto", "Sparkonto" },
        new string[] { "Lönekonto", "Sparkonto" }
    };
        static decimal[][] KontoSaldo = {
        new decimal[] { 1000.0m, 500.0m },
        new decimal[] { 800.0m, 300.0m },
        new decimal[] { 1200.0m },
        new decimal[] { 1500.0m, 100.0m },
        new decimal[] { 900.0m, 200.0m }
        };

        // tom placeholder så bankomaten kan använda en användare i taget. 
        static string inloggadSom = "";

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
                    inloggadSom = AnvändarNamn;
                    Console.WriteLine("Du är nu inloggad som {0}", AnvändarNamn);
                }
                else
                {
                    InloggningsFörsök++;
                    Console.WriteLine("Fel inloggningsuppgifter!");
                }
            }
            Console.Clear();

            Console.WriteLine("Välj vad du vill göra i menyn:");
            Console.WriteLine("");
            string val = "";

            while (val != "4")
            {
                Console.WriteLine("Meny:");
                Console.WriteLine("1. Se konton och saldon");
                Console.WriteLine("2. För över pengar mellan konton");
                Console.WriteLine("3. Uttag av pengar");
                Console.WriteLine("4. Logga ut");
            

                if (Inloggad)
                {

                    val = Console.ReadLine();
                    Console.Clear();

                    switch (val)
                    {
                        case "1":
                            VisaKontoSaldo();

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
                    Console.WriteLine("");
                    Console.WriteLine("Inloggning misslyckades, din användare är låst. Kontakta banken");
                }
                Console.WriteLine("Klicka Enter för att återgå till menyn.");
                Console.ReadLine();
                Console.Clear();
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
        static void VisaKontoSaldo()
        {
            
            int AnvändarIndex = Array.LastIndexOf(KontoÄgare, inloggadSom);
            
            Console.WriteLine($"Konton och saldo för {inloggadSom}:");
            Console.WriteLine("");
            for (int i = 0; i < KontoNamn[AnvändarIndex].Length; i++)
            {
                Console.WriteLine($"{KontoNamn[AnvändarIndex][i]}: {KontoSaldo[AnvändarIndex][i]:C}");
            }
        }
    }



}




