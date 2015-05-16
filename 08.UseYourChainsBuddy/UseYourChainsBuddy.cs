using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

class UseYourChainsBuddy
{
    static void Main(string[] args)
    {
        Console.SetIn(new StreamReader(Console.OpenStandardInput(8192)));
        string text = Console.ReadLine();
        string pattern = @"<p>(.*?(?=<))</p>";
        string patternRepl = @"[^a-z0-9]+";
        string patternSpace = @"\s{2,}";
        StringBuilder sb = new StringBuilder();
        Regex regex = new Regex(pattern);
        Regex regexRepl = new Regex(patternRepl);
        Regex regexSpace = new Regex(patternRepl);
        MatchCollection matches = regex.Matches(text);
        foreach (Match match in matches)
        {
            string tag = match.Groups[1].ToString();
            tag = regexRepl.Replace(tag, " ");
            char[] tagChars = tag.ToCharArray();
            for (int i = 0; i < tagChars.Length; i++)
            {
                if (tagChars[i] >= 'a' && tagChars[i] <= 'm')
                {
                    tagChars[i] = (char)(tagChars[i] + 13);
                }
                else if (tagChars[i] >= 'n' && tagChars[i] <= 'z')
                {
                    tagChars[i] = (char)(tagChars[i] - 13);
                }
            }
            sb.Append(new string(tagChars));
        }
        text = sb.ToString();
        text = regexSpace.Replace(text, " ");
        Console.WriteLine(text);
    }
}
