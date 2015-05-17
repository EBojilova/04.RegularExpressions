using System;
using System.Text;
using System.Text.RegularExpressions;

class SemanticHTML
{
    static void Main(string[] args)
    {
        StringBuilder sb = new StringBuilder();
        string input;
        string patternOpen = @"(?:id|class)\s*=\s*""(?<result>[^\s]+)""";
        string patternClose = @"<\/div>\s*?<!--\s*?(\w{3,7})\s*?-->";
        string replaceClose = @"</$1>";
        while ((input = Console.ReadLine()) != "END")
        {
            if (input.Contains("/div"))
            {
                input=Regex.Replace(input, patternClose, replaceClose);
            }
            else if (input.Contains("div"))
            {
                string HTMLClass = Regex.Match(input, patternOpen).Groups["result"].Value;
                input = Regex.Replace(input, patternOpen, "");
                input = Regex.Replace(input, "div", HTMLClass);
                input = Regex.Replace(input, @"(?<=<.*)\s+", " ");
                input = Regex.Replace(input, @"\s+>", ">");
            }
            sb.Append(input);
            sb.Append("\n");
        }
        string text = sb.ToString();
        Console.WriteLine(text);
    }
}