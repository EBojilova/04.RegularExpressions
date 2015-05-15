using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

class SeriesOfLetters
{
    static void Main(string[] args)
    {
        string text = Console.ReadLine();
        string pattern;
        string replace;
        Regex regexRepl;
        for (int i = 0; i < text.Length; i++)
        {
            pattern = string.Format(@"{0}+",text[i]);
            replace = string.Format(@"{0}", text[i]);
            regexRepl = new Regex(pattern);
            text = regexRepl.Replace(text, replace);
        }
        Console.WriteLine(text);
    }
}
