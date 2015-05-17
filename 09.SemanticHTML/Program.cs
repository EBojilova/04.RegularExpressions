using System;
using System.Text;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        string inputLine;
        StringBuilder sb = new StringBuilder();
        while (!((inputLine = Console.ReadLine()) == "END"))
        {
            sb.Append(inputLine);
            sb.Append("\n");
        }
        string text = sb.ToString();
        string patternOpen = @"<div ([a-z]+\s*=\s*""[^""]+"")*\s*(?:class|id)\s*=\s*""(\w{3,7})""\s*([a-z]+=""[^""]+"")*\s*>";
        MatchCollection matches = Regex.Matches(text, patternOpen, RegexOptions.IgnoreCase);
        string replaceOpen = String.Empty;
        foreach (Match openTag in matches)
        {
            if (openTag.Groups[1].Length == 0 && openTag.Groups[3].Length > 0)
            {
                replaceOpen = @"<$2 $3>";
            }
            else if (openTag.Groups[3].Length == 0 && openTag.Groups[1].Length > 0)
            {
                replaceOpen = @"<$2 $1>";
            }
            else if (openTag.Groups[1].Length == 0 && openTag.Groups[3].Length==0)
            {
                replaceOpen = @"<$2>";
            }
            else
            {
                replaceOpen = @"<$2 $1 $3>";
            }
            text = Regex.Replace(text, patternOpen, replaceOpen);
        }
        string patternClose = @"<\/div>\s*?<!--\s*?(\w{3,7})\s*?-->";
        string replaceClose = @"</$1>";
        text = Regex.Replace(text, patternClose, replaceClose);
        Console.WriteLine(text);
    }
}
