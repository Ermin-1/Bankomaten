namespace Bankomaten
{
    internal class Program
    {  // Skapat användare och pinkoder, variablerna skapas som static så hela kalssen kommer åt den. Jugged array används. 
        static string[] Användare = { "Ermin", "Christian", "Markus", "Shahram", "Fredrik" };
        static string[] PinKod = { "1111", "2222", "3333", "4444", "5555" };
        static string[] KontoÄgare =   { "Ermin", "Christian", "Markus", "Shahram", "Fredrik" };
        static string[][] KontoNamn = {
        new string[] { "Lönekonto", "Sparkonto", "Privatkonto", "Huskonto", "Rainyday-fun" },
        new string[] { "Lönekonto", "Sparkonto", "Privatkonto", "Huskonto" },
        new string[] { "Lönekonto", "Sparkonto", "Privatkonto" },
        new string[] { "Lönekonto", "Sparkonto" },
        new string[] { "Lönekonto" }
    };
        static decimal[][] KontoSaldo = {
        new decimal[] { 27500.0m, 300000.0m, 50000.0m, 20000.0m, 100000.0m },
        new decimal[] { 42000.0m, 200000.0m, 150000.0m, 60000.0m },
        new decimal[] { 25000.0m, 46000.0m, 450000.0m },
        new decimal[] { 15000.0m, 10000.0m },
        new decimal[] { 90000.0m}
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
            

                if (Inloggad) // kör eftersom ovan inloggad blev true.
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
                            Main(args);
                            
                            break;
                        default:
                            Console.WriteLine("Ogiltigt val. Försök igen.");
                            break;
                    }
                }

                Console.WriteLine("");
                Console.WriteLine("Klicka Enter för att återgå till menyn.");
                Console.ReadLine();
                Console.Clear();
            }
        }

        static bool InloggningsKoll(string Användarnamn, string AnvändarPin)
        {
            // kör for loop för att gå igenom användare och pinkoder och hitta en matchning
            // Jämför i if-satsen om användarnamn och pin matchar. 
            for (int i = 0; i < Användare.Length && i < PinKod.Length; i++)
            {
                
                if (Användare[i] == Användarnamn && PinKod[i] == AnvändarPin)
                {
                 
                    return true;
                }
            }
            // Om inloggning misslyckas retunernar den false och man får försöka logga in igen. 
            return false;
        }

        static void VisaKontoSaldo()
        {
            // Hitta användarens index baserat på inloggadSom i arrayen KontoÄgare.
            int AnvändarIndex = Array.LastIndexOf(KontoÄgare, inloggadSom);

           
            Console.WriteLine($"Konton och saldo för {inloggadSom}:");
            Console.WriteLine("");

            // Loopar igenom användarens konton och skriver ut kontonamn och saldo.
            // :C tillagt för att skriva ut som valuta kr.
            for (int i = 0; i < KontoNamn[AnvändarIndex].Length; i++)
            {
            
                Console.WriteLine($"{KontoNamn[AnvändarIndex][i]}: {KontoSaldo[AnvändarIndex][i]:C}");
            }
        }


        static void FöraÖverPengar()
        {
            //Söker efter användaren "inloggad som" i Arrayen Användare. Sparas i ny variabel användarIndex
            int användarIndex = Array.IndexOf(Användare, inloggadSom);

            // går igenom arrayen KontoNamn med placering av användarIndex ( den inloggade ) och skrivs sedan ut. 
            // i + 1 används för att tilldela första kontot värdet 1 och inte 0. 
            Console.WriteLine("Dina konton:");
            for (int i = 0; i < KontoNamn[användarIndex].Length; i++)
            {
                Console.WriteLine($"{i + 1}. {KontoNamn[användarIndex][i]}");
            }

            Console.Write("Välj konto att överföra pengar från (ange siffran): ");
            int frånKonto = int.Parse(Console.ReadLine());

            // Om frånKonto är ett giltligt heltal och inom intervallet mellan 1 och antal konto i indexet forstter den in i if-satsen
            if ( frånKonto >= 1 && frånKonto <= KontoNamn[användarIndex].Length)
            {
                // nytt frånKontoIndex som tilldelas värdet frånkonto - 1
                int frånKontoIndex = frånKonto - 1;

                Console.Write("Välj konto att överföra pengar till (ange siffran): ");
                int tillKonto = int.Parse(Console.ReadLine());

                // Kontrollerar om tillKonto är ett giltigt heltal inom rätt intervall i indexet
                if ( tillKonto >= 1 && tillKonto <= KontoNamn[användarIndex].Length)
                {
                    // Beräknar indexet för det valda tillKonto
                    int tillKontoIndex = tillKonto - 1;

                    Console.Write("Ange belopp att överföra: ");
                    decimal överföringsBelopp = decimal.Parse(Console.ReadLine());
                    if (överföringsBelopp > 0)
                    {
                        // Kontrollerar om det finns tillräckligt med saldo på avsändande konto
                        if (KontoSaldo[användarIndex][frånKontoIndex] >= överföringsBelopp)
                        {
                            // Utför överföringen och uppdaterar saldon
                            KontoSaldo[användarIndex][frånKontoIndex] -= överföringsBelopp;
                            KontoSaldo[användarIndex][tillKontoIndex] += överföringsBelopp;
                            Console.WriteLine("");
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
            Console.WriteLine("");
        }

        static void TaUtPengar()
        {
            // Här söker vi efter användaren i arrayen Användare och får dess indexnummer
            int användarIndex = Array.IndexOf(Användare, inloggadSom);

           
            Console.WriteLine($"Dina tillgängliga konton:");
            for (int i = 0; i < KontoNamn[användarIndex].Length; i++)
            {
                Console.WriteLine($"{i + 1}. {KontoNamn[användarIndex][i]}");
            }

          
            Console.Write("Välj konto att ta ut pengar från (ange siffran): ");
            int valtKonto = int.Parse(Console.ReadLine());

            // Kolla om det valda kontot existerar
            if (valtKonto >= 1 && valtKonto <= KontoNamn[användarIndex].Length)
            {
                // Justerar indexet för att matcha arrayens index som börjar med 0.
                int kontoIndex = valtKonto - 1;

               
                Console.Write("Ange belopp att ta ut: ");
                decimal uttagsBelopp = decimal.Parse(Console.ReadLine());

                bool rättPin = false;
                int försök = 0;

                while (försök < 3)
                {
                    Console.Write("Ange pinkod: ");
                    string AnvändarPin = Console.ReadLine();

                    // Loopa igenom pinkoderna och kontrollera om det finns en matchning
                    for (int i = 0; i < PinKod.Length; i++)
                    {
                        if (PinKod[i] == AnvändarPin)
                        {
                            rättPin = true;
                            break; // Avsluta loopen om en matchning hittas
                        }
                    }

                    if (rättPin)
                    {
                        break; // Avsluta pinkodsluppen om rätt pinkod hittades
                    }
                    else
                    {
                        Console.WriteLine("Fel pinkod. Försök igen.");
                        försök++;
                    }
                }

                if (rättPin)
                {
                    // Pinkoden är korrekt, fortsätt med uttagsprocessen
                }
                else
                {
                    Console.WriteLine("För många felaktiga försök. Bankomaten utloggad.");
                    System.Environment.Exit(1);
                }


                if (uttagsBelopp > 0)
                {
                    // Kolla om det finns tillräckligt saldo på det valda kontot.
                    if (KontoSaldo[användarIndex][kontoIndex] >= uttagsBelopp)
                    {
                        
                        // Dra av uttagsbeloppet från kontosaldo och skriv ut bekräftelse.
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

    }

}




