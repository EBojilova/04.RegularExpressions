using System;
using System.Text.RegularExpressions;

class SeriesOfLetters
{
    static void Main()
    {
        //  The regex will match any character (.) and \\1+ will match whatever was captured in the first group.
        var text = Console.ReadLine();
        var regex = new Regex(@"(.)\1+");
        Console.WriteLine(regex.Replace(text, "$1"));
    }
}