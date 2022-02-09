using Spectre.Console;

string userDecInput;
string userBaseInput = null;
int dec;
int baseNum = 0;
bool invalidInput;

do
{
    invalidInput = false;
    Console.Write("Inserisci il numero decimale da convertire: ");
    userDecInput = Console.ReadLine();

    if (!int.TryParse(userDecInput, out dec))
    {
        invalidInput = true;
        
        AnsiConsole.Markup("[red]ERRORE[/]: input non valido");

        Thread.Sleep(1000);

        Console.Clear();

        AnsiConsole.Markup("[green]Riprovare[/]\n");
    }
    else
    {
        Console.Write("Inserisci la base (da 2 a 36): ");
        userBaseInput = Console.ReadLine();

        if (!int.TryParse(userBaseInput, out baseNum) || baseNum > 36 || baseNum < 2)
        {
            invalidInput = true;
            
            AnsiConsole.Markup("[red]ERRORE[/]: input non valido");

            Thread.Sleep(1000);

            Console.Clear();

            AnsiConsole.Markup("[green]Riprovare[/]\n");
        }
    }
} while (invalidInput);

Console.Write($"\n{userDecInput} in base {userBaseInput} è {ConvertDecToBase(baseNum, dec)}");


static string ConvertDecToBase(int baseNum, int dec)
{
    string tmp = "";
    
    while (dec > 0)
    {
        Console.WriteLine(tmp);
        tmp += CalcChar(dec % baseNum);
        Console.WriteLine(dec);
        dec /= baseNum;
    }
    char[] res = tmp.ToCharArray();
 
    Array.Reverse(res);
    return new String(res);
}

//calcola il carattere corrispondente al numero passato
static char CalcChar(int num)
{
    if (num >= 0 && num <= 9) return (char)(num + 48);
    return (char)(num - 10 + 65);
}