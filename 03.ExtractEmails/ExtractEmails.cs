﻿using System;
using System.Text.RegularExpressions;

class ExtractEmails
{
    static void Main(string[] args)
    {
        string text = Console.ReadLine();
        // Innos             @"(?<=\s|^)([^\W_][\w.-]*[^\W_]|[^\W_])@[^\W_](([a-zA-Z-]*[a-zA-Z]+|[a-zA-Z]*)\.([a-zA-Z]+[a-zA-Z-]*|[a-zA-Z]*))+[^\W_]\b";
        string patternMeil = @"(?<=\s|^)([a-z0-9]+(?:[_.-][a-z0-9]+)*@[a-z]+\-?[a-z]+(?:\.[a-z]+)+)\b";
        Regex regexMail = new Regex(patternMeil);
        MatchCollection matches = regexMail.Matches(text);
        Console.WriteLine("Found {0} matches", matches.Count);
        foreach (Match name in matches)
        {
            Console.WriteLine(name.Groups[0]);
        }
    }
}
