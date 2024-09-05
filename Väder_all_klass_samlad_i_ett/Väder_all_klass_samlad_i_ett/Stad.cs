using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace VÄDERSTATION_INGLÄMING_4
{
    class Stad                             // Klass deklaration.
    {
        // klass-medlemar (attributer)
        public string stadnamn;                                                // Deklarerar string-variabel för stadnamn.
        public int stadtemp;                                                   // Deklarerar int-variabel för stadtemperatur.

        public Stad(string stadNamn, int stadTemp)                             // Konstruktor är alltså det som initerar(startar) objektet. Den tilldelar värden till vår objekts attrubiter.(string, int)
        {
            this.stadnamn = stadNamn;                                          // "this" är en hjälpmedel för att kunna särskilja variablerna som använder samma namn.
            this.stadtemp = stadTemp;
        }
        public Stad()                                                          // Default konstruktor är användbart när vi inte har några värden att tilldela än.
        { }
        public string StadNamn
        {
            get { return stadnamn; }                                           // En egenskap med get/set låter oss hämta och ändra värdet av både StadNamn/StadTemp.                                                 
            set { stadnamn = value; }                                          // Return skickar tillbaka nya värdet dit den lagras.
        }                                                                      // Måste vara samma namn som klass-medlemen vi arbetar med.
        public int StadTemp
        {
            get { return stadtemp; }
            set { stadtemp = value; }
        }
        public override string ToString()                                       // Metod för ToString.
        {                                                                       // "Override" innebär att man anpassar en grund-klass och dess värde efter en ny sub-klass som har samma namn.
                                                                                // Den nya sub-klass och dess värde "tar över" namnet som båda klasser delar. 
            return "    " + stadnamn + "         " + stadtemp + "°C";           // Returerar en sträng som innehåller användares input för stadnamnen samt temperaturer.
        }
    }
}