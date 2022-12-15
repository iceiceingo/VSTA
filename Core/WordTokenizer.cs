using System.Text.RegularExpressions;
using System;
namespace VSTA.Core;

/// <summary>
/// WordTokenizer knows how to split a string into substrings and select only what we consider words (tokens). 
/// </summary>
public class WordTokenizer
{    
    /// <summary>
    /// Returns what we consider tokens.
    /// </summary>
    /// <param name="str">String to tokenize.</param>
    /// <returns>IEnumerable representing the tokens.</returns>
    public IEnumerable<string> tokenize(string str)
    {
        // THIS SHOULD CHANGED..
        var clean = str.Trim().ToLower();
        clean = Regex.Replace(clean, @"\s+", " ");
        return clean.Split(" ",  StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => this.removePunctuationTokens(x)).Where(x => x.All(Char.IsLetter));
                  
    }

    private string removePunctuationTokens(string str)
    {
        var lastChar = str.Last();
        if(lastChar == '.' || lastChar == ',' || lastChar == '!' || lastChar == '?')
            return str.Substring(0, str.Length - 1);
        return str;
    }
}
