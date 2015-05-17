using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

class ExtractEmails //Katya Marincheva
{
    static void Main()
    {
        string text = Console.ReadLine();
        string pattern = @"(?<=\s|^)([a-z0-9]+(?:[_.-][a-z0-9]+)*@[a-z]+\-?[a-z]+(?:\.[a-z]+)+)\b";
        Regex rgx = new Regex(pattern);
        MatchCollection matches = rgx.Matches(text);
        using (StreamWriter output = new StreamWriter(@"..\..\emails.html")) // create new file
        {
            foreach (Match email in matches)
            {
                output.WriteLine(String.Format("<i>" + email.Groups[1] + "</i>"));
                output.WriteLine("<br>");
            }
        }
        Process.Start(@"..\..\emails.html");  // open html file with results
    }
}
