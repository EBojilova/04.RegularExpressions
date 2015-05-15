using System;
using System.Text.RegularExpressions;

class ReplaceAtag
{
    static void Main(string[] args)
    {
        string text = Console.ReadLine();
        string pattern = @"(<a href=)(.*(?=>))(>)(.*(?=<))(</a>)";
        string replace = @"[URL href=$2]$4[/URL]";
        var replaced = Regex.Replace(text, pattern, replace);
        Console.WriteLine(replaced);
    }
}
