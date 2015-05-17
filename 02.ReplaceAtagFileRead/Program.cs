using System;
using System.IO;
using System.Text.RegularExpressions;

class ReplaceAHrefTagFromFile //Katya Marincheva
{
    static void Main()
    {
        string html = File.ReadAllText(@"C:\Users\Elena\Documents\Visual Studio 2013\Projects\04.RegularExpressions\02.ReplaceAtagFileRead\HTML-AHref.txt"); // read file HTML-AHref.txt saved in same folder as the project .cs file
        string pattern = @"<a(.*href=(.|\n)*?(?=>))>((.|\n)*?(?=<))<\/a>";
        using (StreamWriter output = new StreamWriter(@"..\..\HTML-URL.txt"))  // create new file
        {
            output.WriteLine(Regex.Replace(html, pattern, @"[URL$1]$3[/URL]")); // write on the new file, the URL-replaced string
        }
        string fileContents = File.ReadAllText(@"..\..\HTML-URL.txt"); // print output file to the console
        Console.WriteLine(fileContents);
    }
}