namespace Bankomaten
{
    internal class Program
    {  // Skapat användare och pinkoder, variablerna skapas som static så hela kalssen kommer åt den. Jugged array används. 
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

        // tom placeholder så bankomaten vet vem som är inloggad. 
        static string inloggadSom = "";

        static void Main(string[] args)
        {
            Console.WriteLine("----> Välkommen till bankomaten <----");

            // bool satt till false för att se om personen fortfarande är inloggad. 
            // inloggnignsförsök satt till 0 för att räkna i nedan whileloop antal inloggningsförsök
            bool Inloggad = false;
            int InloggningsFörsök = 0;

            while (!Inloggad && InloggningsFörsök < 3)
            {
                Console.Write("Ange användarnamn:");
                string AnvändarNamn = Console.ReadLine();

                Console.Write("Ange pinkod:");
                string AnvändarPin = Console.ReadLine();

                // metod anropad för att kolla om användaren har rätt Namn och lösenord. 
                // om innlogning lyckas vänder boolen till true och går vidare ur loopen. Sparar också användaren i "inloggadSom" 
                if (InloggningsKoll(AnvändarNamn, AnvändarPin))
                {
                    Inloggad = true;
                    inloggadSom = AnvändarNamn;
                    Console.WriteLine("Du är nu inloggad som {0}", AnvändarNamn);
                }
                else if (InloggningsFörsök < 2)
                {
                    InloggningsFörsök++;
                    Console.WriteLine("");

                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("Inloggning misslyckades, din användare är låst. Kontakta banken");
                    System.Environment.Exit(1);
                }
            }
            Console.Clear();

            //enkelt menyprogram som körs sålänge inte användaren trycker på 4 i menyn och loggar ut. 
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
                            FöraÖverPengar();
                            break;
                        case "3":
                            TaUtPengar(); 
                            break;
                        case "4":
                            Utloggning();
                            System.Environment.Exit(1); // Utan EXIT så repterar programmet "Klicka på enter för att återgå till menyn" vid avslut
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
                Console.WriteLine($"{KontoNamn[AnvändarIndex][i]}: {KontoSaldo[AnvändarIndex][i]:C}"); // WTF?
            }
        }

        static void FöraÖverPengar()
        {
            int användarIndex = Array.IndexOf(Användare, inloggadSom);

            Console.WriteLine("Dina konton:");
            for (int i = 0; i < KontoNamn[användarIndex].Length; i++)
            {
                Console.WriteLine($"{i + 1}. {KontoNamn[användarIndex][i]}");
            }

            Console.Write("Välj konto att överföra pengar från (ange siffran): ");
            if (int.TryParse(Console.ReadLine(), out int frånKonto) && frånKonto >= 1 && frånKonto <= KontoNamn[användarIndex].Length)
            {
                int frånKontoIndex = frånKonto - 1;

                Console.Write("Välj konto att överföra pengar till (ange siffran): ");
                if (int.TryParse(Console.ReadLine(), out int tillKonto) && tillKonto >= 1 && tillKonto <= KontoNamn[användarIndex].Length)
                {
                    int tillKontoIndex = tillKonto - 1;

                    Console.Write("Ange belopp att överföra: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal överföringsBelopp) && överföringsBelopp > 0)
                    {
                        if (KontoSaldo[användarIndex][frånKontoIndex] >= överföringsBelopp)
                        {
                            KontoSaldo[användarIndex][frånKontoIndex] -= överföringsBelopp;
                            KontoSaldo[användarIndex][tillKontoIndex] += överföringsBelopp;
                            Console.WriteLine($"{överföringsBelopp:C} har överförts från {KontoNamn[användarIndex][frånKontoIndex]} till {KontoNamn[användarIndex][tillKontoIndex]}.");
                            Console.WriteLine($"Nytt saldo för {KontoNamn[användarIndex][frånKontoIndex]}: {KontoSaldo[användarIndex][frånKontoIndex]:C}");
                            Console.WriteLine($"Nytt saldo för {KontoNamn[användarIndex][tillKontoIndex]}: {KontoSaldo[användarIndex][tillKontoIndex]:C}");
                        }
                        else
                        {
                            Console.WriteLine("Otillräckligt saldo på det valda kontot för att genomföra överföringen.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ogiltigt belopp. Ange ett positivt decimaltal.");
                    }
                }
                else
                {
                    Console.WriteLine("Ogiltigt kontoval för mottagande konto. Ange en siffra som motsvarar ett av dina konton.");
                }
            }
            else
            {
                Console.WriteLine("Ogiltigt kontoval för avsändande konto. Ange en siffra som motsvarar ett av dina konton.");
            }
        }

        static void TaUtPengar()
        {
            int användarIndex = Array.IndexOf(Användare, inloggadSom);

            Console.WriteLine($"Dina tillgängliga konton:");
            for (int i = 0; i < KontoNamn[användarIndex].Length; i++)
            {
                Console.WriteLine($"{i + 1}. {KontoNamn[användarIndex][i]}");
            }

            Console.Write("Välj konto att ta ut pengar från (ange siffran): ");
            if (int.TryParse(Console.ReadLine(), out int valtKonto) && valtKonto >= 1 && valtKonto <= KontoNamn[användarIndex].Length)
            {
                int kontoIndex = valtKonto - 1;

                Console.Write("Ange belopp att ta ut: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal uttagsBelopp) && uttagsBelopp > 0)
                {
                    if (KontoSaldo[användarIndex][kontoIndex] >= uttagsBelopp)
                    {
                        KontoSaldo[användarIndex][kontoIndex] -= uttagsBelopp;
                        Console.WriteLine($"{uttagsBelopp:C} har tagits ut från {KontoNamn[användarIndex][kontoIndex]}.");
                        Console.WriteLine($"Nytt saldo för {KontoNamn[användarIndex][kontoIndex]}: {KontoSaldo[användarIndex][kontoIndex]:C}");
                    }
                    else
                    {
                        Console.WriteLine("Otillräckligt saldo för att ta ut det angivna beloppet.");
                    }
                }
                else
                {
                    Console.WriteLine("Ogiltigt belopp. Ange ett positivt decimaltal.");
                }
            }
            else
            {
                Console.WriteLine("Ogiltigt kontoval. Ange en siffra som motsvarar ett av dina konton.");
            }
        }


        static void Utloggning() 
        {
            inloggadSom = "";
            Console.WriteLine("Utloggad: Välkommen åter!");
            
        }
    }

}




