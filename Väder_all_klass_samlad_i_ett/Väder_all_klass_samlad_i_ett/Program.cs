using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace VÄDERSTATION_INGLÄMING_4
{
    class Program
    {

        static void Main(string[] args)
        {


            List<Stad> myStäder = new List<Stad>();                                      //Deklaration av lista för städerna.
            bool MenyIsRunning = true;
            int n = myStäder.Count;




            Console.WriteLine("                                           ¤~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~¤");
            Console.WriteLine("                                        ~*||       AMO'S VÄDERSTATION     ||*~");
            Console.WriteLine("                                           ¤~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~¤");
            Console.WriteLine("\n");



            // Hälsning med instruktioner.
            Console.WriteLine("    *~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*");
            Console.WriteLine("    | Hejsan, välkommen till vår väderprogram   |");
            Console.WriteLine("    | Var vänligt och välj ett alternativ nedan!| ");
            Console.WriteLine("    *~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*\n");




            while (MenyIsRunning)                                                         // Loop för menyn alternativen.
            {


                Console.WriteLine("               ~~~~~VÄDERMENY~~~~~~\n");
                Console.WriteLine("\n");


                Console.WriteLine("¤ [1] Vill du ange 4 städer samt respektive temperatur?\n");
                Console.WriteLine("¤ [2] Vill du ta reda på en temperatur med linärsökning?\n");
                Console.WriteLine("¤ [3] Vill du sortera med bubblesort?\n");
                Console.WriteLine("¤ [4] Vill du göra en ny inmatning?\n");
                Console.WriteLine("¤ [5] Avsluta programmet?\n");




                string menyAlternativ = Console.ReadLine();
                Console.WriteLine("_");
                Console.WriteLine("\n");


                switch (menyAlternativ)                                                   // Swtich-loop respektive alternativ i menyn.
                {
                    case "1":
                        for (int i = 0; i < 4; i++)                                       // For-loop för att iterera och spara information om städerna och temperaturen. 
                        {
                            Stad myStad = new Stad();                                     //  Deklarear och definerar objektet.


                            Console.WriteLine(" __________________");
                            Console.WriteLine("|Ange namn på stad:| ");
                            Console.WriteLine(" ------------------");
                            Console.WriteLine("\n");


                            string stad = Console.ReadLine();                               // Deklarerar och definerar variabeln med användares input.
                            Console.WriteLine("______");

                            myStad.StadNamn = stad;                                         // Tilldelar inputen från användaren till egenskapen StadNamn.
                            myStäder.Add(myStad);                                           // "Add" lägger till inputen i listan "myStad"

                            bool IsRättTemp = false;
                            do                                                              // Loop för ifall det är fel input.
                            {

                                Console.WriteLine("\n");
                                Console.WriteLine(" _________________________");
                                Console.WriteLine("|Ange temperatur (heltal):| ");
                                Console.WriteLine(" -------------------------");
                                Console.WriteLine("\n");

                                try                                                         // Istället för att programmet avbryts abrupt när en input inte är i rätt format används då istället Try/Catch
                                {                                                           // Det är en sorts "felmeddelande"-funktion. Som låter oss meddela användaren om att det inputen var fel.  

                                    int temp = int.Parse(Console.ReadLine());               // Deklarerar och definerar variabeln med användares input.
                                    Console.WriteLine("__");

                                    if (temp >= -60 && temp <= 60)                          // Tillsätter ett intervall som inte får passeras.
                                    {
                                        myStad.StadTemp = temp;
                                        IsRättTemp = true;
                                    }
                                    else                                                    // Själva felmeddelandet.
                                    {
                                        Console.WriteLine("\n");
                                        Console.WriteLine(" _____________________________________________________");
                                        Console.WriteLine("|OBS: Du har anget en ogiltig temperatur, försök igen!|");
                                        Console.WriteLine(" -----------------------------------------------------");
                                        Console.WriteLine("\n");
                                    }

                                }
                                catch
                                {
                                    Console.WriteLine(" ----------------------------------");
                                    Console.WriteLine("| OBS: Du får bara använda siffor! |");
                                    Console.WriteLine(" ----------------------------------\n");
                                }
                            } while (!IsRättTemp);
                        }
                        break;


                    case "2":
                        Console.WriteLine(" ----------------------------------");
                        Console.WriteLine("|Ange temperaturen du vill du söka:|");
                        Console.WriteLine(" ----------------------------------\n");


                        int söktemp = int.Parse(Console.ReadLine());                            // Deklarerar och definerar "söktemp" variabel för sökning av en specifik temperatur.
                        Console.WriteLine("__");
                        Console.WriteLine("\n");


                        int index = Linsok(myStäder, n, söktemp);                                // Deklarerar och definerar "index" variabel för sökning av ett index
                        if (index == -1)                                                         // "-1" indikerar att sökningen ej hittades. Så den returerar då "-1" helt enkelt.
                        {                                                                        // Fel medd. anpassad till sökningen.  
                            Console.WriteLine("  _________________________________________________________");
                            Console.WriteLine($"|OBS: Temperaturen: " + söktemp + "°C  du angav fanns inte med på listan! |");
                            Console.WriteLine("  ---------------------------------------------------------\n");
                        }
                        else
                        {
                            Console.WriteLine("\n");
                            Console.WriteLine("___________________________________________");
                            Console.WriteLine($"Temperatur: " + söktemp + "°C  ||  Indexposition: " + index + "   ||");
                            Console.WriteLine("-------------------------------------------\n");


                            Console.WriteLine("--------------------------------");
                            Console.WriteLine($"Det är: " + myStäder[index].ToString() + " |");          // Anropar metod "ToString" som visar staden med temperaturen vi söker.      
                            Console.WriteLine("--------------------------------\n");
                        }
                        break;

                    case "3":
                        Console.WriteLine(" *-----------------------*");
                        Console.WriteLine(" |      BUBBLESORT       |");
                        Console.WriteLine(" *-----------------------*");
                        Console.WriteLine(" |   STAD  |  TEMPERATUR |");
                        Console.WriteLine(" *-----------------------*\n\t");

                        BubbleSort(myStäder, n);                                               // Anropar Bubblesorterings metoden samt SkrivUt metoden.
                        SkrivUt(myStäder);
                        Console.WriteLine("\n");
                        break;

                    case "4":
                        myStäder.Clear();                                                  // Rensar listan ifall användaren vill göra en ny inmatning. 

                        for (int i = 0; i < 4; i++)
                        {
                            Stad myStad = new Stad();                                       // Återigen denifition av object ifall det görs en ny inmatning


                            Console.WriteLine(" __________________");
                            Console.WriteLine("|Ange namn på stad:| ");
                            Console.WriteLine(" ------------------");
                            Console.WriteLine("\n");


                            string stad = Console.ReadLine();
                            Console.WriteLine("______");

                            myStad.StadNamn = stad;
                            myStäder.Add(myStad);

                            bool IsRättTemp = false;
                            do
                            {
                                Console.WriteLine("\n");
                                Console.WriteLine(" ________________________________");
                                Console.WriteLine("|Ange temperatur på stad (heltal):| ");
                                Console.WriteLine(" --------------------------------");
                                Console.WriteLine("\n");
                                int temp = int.Parse(Console.ReadLine() + "\t");
                                Console.WriteLine("__");

                                if (temp >= -60 && temp <= 60)
                                {
                                    myStad.StadTemp = temp;
                                    IsRättTemp = true;
                                }
                                else
                                {
                                    Console.WriteLine("\n");
                                    Console.WriteLine(" _____________________________________________________");
                                    Console.WriteLine("|OBS: Du har anget en ogiltig temperatur, försök igen!|");
                                    Console.WriteLine(" -----------------------------------------------------");
                                    Console.WriteLine("\n");
                                }
                            } while (!IsRättTemp);
                        }
                        break;


                    case "5":                                                                                                  // En avslut meddelande.
                        Console.WriteLine(" -----------------------------------------------------------------");
                        Console.WriteLine("| Tack för denna gång och glöm inte klä på dig rätt, ha det fint! |");
                        Console.WriteLine(" -----------------------------------------------------------------");
                        MenyIsRunning = false;
                        break;

                    default:
                        Console.WriteLine(" ---------------------------------------------");
                        Console.WriteLine("| OBS: Du måste välja ett giltigt alternativ! |");                                 // Ett fel medd. ifall användaren väljer något annat än alternativen.
                        Console.WriteLine(" ---------------------------------------------\n");
                        break;
                }

            }
            Console.ReadLine();
        }

        static void SkrivUt(List<Stad> myStäder)                                                   // Metod för utskrivning.
        {
            for (int i = 0; i < myStäder.Count; i++)                                               // For-loop för att skriva ut listan. "Count" motsvarar arrays length.(Viktigt att veta)
            {
                Console.WriteLine(myStäder[i] + "\t");                                             // Skriver ut det som finns på indexen.
            }
        }

        static void BubbleSort(List<Stad> myStäder, int n)                                         // Metod för Bubblesortering.
        {
            for (int i = 0; i < myStäder.Count - 1; i++)                                           // Yttre for-loop används för att loopa listan flera gånger tills den är sorterad. Men vi skriver in också -1 eftersom indexen är nollbaserad. 
            {                                                                                      // Så om vi har 4 element då skulle indexen för den första vara då 0 sedan har den andra elementet  index 1 etc...
                                                                                                   // Detta gör att elementet undviker att jämföra sista elementet med något som inte ligger listans gräns.
                                                                                                   // Efter första iterering kommer den första elementet vara i rätt position.

                for (int j = 0; j < myStäder.Count - i - 1; j++)                                   // Inre for-loop fortsätter med jämförelse av listan element för element. Men vi skriver in också -i och - 1.
                                                                                                   // Detta gör att den inre loppen unviker göra onödiga jämförelser med sig själv eller med andra redan sorterade element.  
                {
                    if (myStäder[j].StadTemp > myStäder[j + 1].StadTemp)                           // If-loopen hjälper oss att kontrollera ifall elementen i [J] är mindre än elemeten i [j+1] ("+1 innebär att den jämför med elemtet som är just brevid").
                    {
                        Stad TempStad = myStäder[j + 1];                                           // OM ja så byter de plats med hjälp av en temporär variabel(TempStad) och tilldelas värdet av den nästliggande element.
                        myStäder[j + 1] = myStäder[j];                                             // Här ändras och tilldelas värdet för [j+1] till den aktuella värdet av [j]
                        myStäder[j] = TempStad;                                                    // Här tilldelas värdet av myStäder[j] till TempStad. Alltså byter dem plats helt enkelt.
                    }
                }
            }
        }
        static int Linsok(List<Stad> myStäder, int n, int söktemp)                                  // Metod för Linksökning.
        {
            for (int i = 0; i < myStäder.Count; i++)                                               // For-loop för att ha tillgång till listan med info om stad/temperatur. 
            {
                if (myStäder[i].StadTemp == söktemp)                                               // If-loop för att kunna söka efter en specifikt angiven temperatur.  
                {
                    return i;                                                                      // Returerar det vi söker.
                }
            }
            return -1;                                                                             // Ifall det vi söker inte hittas, retureras då -1.                                        
        }
    }
}

// UTVÄRDERING:
// Detta var något som jag helt inte hade förväntat mig. Det kändes som att jag hade någurlunda koll i slutet av förra uppgiften men detta tycker jag var definitivt överväldigande.
// Jag börjar förstå boken bättre och tycker att det är lite roligt liknelser författaren använder. Det var till hjälp men såklart fick jag googla mig fram till det mesta, som är såklart länkad nedan.
// Klasser känns som att de har en VÄLDIGT brant inlärningskurva (särskilt för oss som aldrig hållit på med programmering innan). Jag känner mig lite osäker när man ska använda private/static/void för att nämna få.
// Någorlunda koll har jag men inte som mycket alls.                                                                                                                           (Kan ha fel men antar att man använder static void när man kodar i main-sidan)
// Det var väldigt mycket nytt som jag fick använda mig av för första gången såsom get/set, konstruktor, listor, try/catch, return, bubblesortering, linärsökning etc...
// Väldigt användbara hjälptmedel var det. Kan bara föreställa mig att när man väll använder både hjälpmedel och fördefinerade funktioner blir det säkert mycket lättare. 
// Känns jobbigt att man måste kunna allt utan till för provet. Men ifall man kan bör man då komma långt.
// Allt som allt tyckte jag stressen man fick av denna uppgift var lite kul men för det mesta jobbigt. Mycket att ta in särskilt det där med söknings algoritmer.

// Hade verkligen velat göra de extra uppgifterna vi fick som var frivilliga men hade tyvärr inte inte tillräcklig med tid pga jobb/vab/sjukdom/högtider. 
// Men hoppas mitt arbete visar hur långt jag har kommit.



// DOKUMENTATION: 
// Skrev detta som kommentarer vid sidan av dem olika funktionerna. 




// LÄNKAR SOM HJÄLPTE MIG PÅ TRAVEN:
// www.pluggakuten.se/trad/svart-med-klasser/ 
// www.youtube.com/watch?v=9V5B3dNoVIA&ab_channel=BroCode
// www.youtube.com/watch?v=heoTab1e41A&ab_channel=BroCode
// www.youtube.com/watch?v=aLhAmimoQj8&t=55s&ab_channel=BroCode
// www.youtube.com/watch?v=8FmE_-QXg3Y&ab_channel=BroCode
// www.youtube.com/watch?v=Z70AwnYYJOc&ab_channel=BroCode
// www.youtube.com/watch?v=52r9qUToOD8&list=PLLAZ4kZ9dFpNIBTYHNDrhfE9C-imUXCmk&ab_channel=GiraffeAcademy
// csharpskolan.se/borja-har/    (Scrollar man ner hittar avsnitt-viss olika delar av det vi gått igenom kursen )
// csharp.progdocs.se/grundlaeggande/listor-och-arrayer
// stackoverflow.com/questions/18200427/override-tostring-method-c-sharp
// learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/this
// learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/how-to-override-the-tostring-method
// learn.microsoft.com/en-us/dotnet/api/system.object?view=net-8.0&viewFallbackFrom=windowsdesktop-8.0
