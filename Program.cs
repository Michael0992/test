using System.Linq;



string hello = "Hello world!"; // [Ojektyp|Länge|...|Daten H e l l o    w o r l d]
//[]-Operator : Index Operator
char zeichen1 = hello[0]; //Index 0 ist das erste Zeichen in dieser Zeichenkette -> H
char zeichen2 = hello[1]; // Hier ist der Wert einfach e weil es das zweite Zeichen der Zeichenkette ist
char zeichen3 = hello[5]; //' ' das leerzeichen

int laenge = hello.Length;
char letztesZeichen = hello[laenge-1]; // hello[hello.Length-1];
//.Length gibt uns die tatsächliche Anzahl an Zeichen in der Zeichenkette an.
//Da unser Index 0 basiert ist, ist der höchste Index der Zeichenkette länge - 1. (Offset der  Pointer Arithmetik)
System.Console.WriteLine(letztesZeichen);


//Aufgabe:
//Ein User soll eine Postleitzahl eingeben können.
//Es wird geprüft, ob die PLZ fünf Stellen hat. 
//Ist dies nicht der Fall, soll "Ungültige PLZ" in der Konsole ausgegeben werden. 
//Ist die PLZ korrekt, soll die zugehörige Region ermittel und in der Konsole ausgegeben werden. 
//Postleitzahlregionen:     Mit 0 oder 1 beginnend  => Ostdeutschland
//                          Mit 2 beginnend         => Norddeutschland
//                          Mit 3 beginnend         => Mitteldeutschland
//                          Mit 4 oder 5 beginnend  => Westdeutschland
//                          Mit 6,7,8 oder 9 beginnend => Süddeutschland


System.Console.WriteLine("Hallo User! Gib bitte deine Postleitzahl an!");
string? plz = Console.ReadLine();
bool plzOk = plz?.Length == 5;
string region = "";

if(!plzOk) System.Console.WriteLine("Ungültige Postleitzahl! Sie hat 5 Stellen!");
else if(plzOk){
    switch(plz?[0]){
        case '0' or '1':
            region = "Ostdeutschland";
            break;
        case '2':
            region = "Norddeutschland";
            break;
        case '3':
            region = "Mitteldeutschland";
            break;
        case '4' or '5':
            region = "Westdeutschland";
            break;
        case '6' or '7' or '8' or '9':
            region = "Süddeutschland";
            break;
        default:
            System.Console.WriteLine("Ungültige Eingabe! Eine Postleitzahl muss mit einer Zahl beginnen.");
            plzOk = false;
            break;
    }
}
else{
    System.Console.WriteLine("Da ist aber was schiefgelaufen");
}

if(plzOk){
    //Es gibt drei verschieden Möglichkeiten Variablen in einem String einzubinden.
    //Konkatination:
    string ausgabe = "Du hast folgende Postleitzahl eingegeben: " + plz + "Du kommst aus " + region;

    //Interpolation:
    ausgabe = $"Du hast folgende Postleitzah eingegeben {plz}. Du kommst aus {region}";

    //Komposition
    ausgabe = String.Format("Du hast folgende Posleitzahl eingegeben: {0}. Du kommst aus {1}",plz, region);

    System.Console.WriteLine(ausgabe);
    Console.ReadKey();    
}

//Alternative Lösung
//⚠️(Vertiefungs Inhalte)


Console.Clear();
System.Console.WriteLine("Bitte gib deine Postleitzahl ein:");

string plz2 = Console.ReadLine()?? "";
if(plz2.Length == 0) plz2 = "XXXXX";


string? region2 = 
    plz2?.Length != 5 && !plz2.All(char.IsDigit)? null:
    plz2[0] == '0' || plz2[0] == '1' ? "Ostdeutschland":
    plz2[0] == '2' ? "Norddeutschland":
    plz2[0] == '3' ? "Mitteldeutschland":
    plz2[0] == '4' || plz2[0] == '5' ? "Westdeutschland":
    plz2[0] == '6' || plz2[0] == '7' || plz2[0] == '8' || plz2[0] == '9' ? "Süddeutschland": null; 
    
if(region2 != null)System.Console.WriteLine($"deine Postleitzahl ist {plz2} und deine Region ist {region2}");
else System.Console.WriteLine("Ungültige Postleitzahl");


