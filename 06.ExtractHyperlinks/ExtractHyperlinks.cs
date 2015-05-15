using System;
using System.Text;
using System.Text.RegularExpressions;

class ExtractHyperlinks
{
    static void Main(string[] args)
    {
        string inputLine;
        StringBuilder sb = new StringBuilder();
        while (!((inputLine = Console.ReadLine()) == "END"))
        {
            sb.Append(inputLine);
        }
        string text = sb.ToString();
        string pattern = @"<a\s+(?:[^>]+\s+)?href\s*=\s*(?:'([^']*)'|""([^""]*)""|([^\s>]+))[^>]*>";
        Regex users = new Regex(pattern);
        MatchCollection matches = users.Matches(text);
        //Console.WriteLine("Found {0} matches", matches.Count);
        foreach (Match hyperlink in matches)
        {
            for (int i = 1; i <= 3; i++)
            {
                if (hyperlink.Groups[i].Length>0)
                {
                    Console.WriteLine(hyperlink.Groups[i]);
                }
            } 
        }
    }
}
