// See https://aka.ms/new-console-template for more information
namespace VSTA.Console;
using System;
using VSTA.Core;
public class Program
{
    public static void Main(string[] args)
    {
        var draculaStats = new FileTextStatistics("Sampledata/dracula.txt");
        draculaStats.analyse();
        var frequentWords = draculaStats.topWords(20);
        var longestWords = draculaStats.longestWords(10);
        Console.WriteLine($"Number of lines in dracula {draculaStats.numberOfLines()}");
        Console.WriteLine($"Number of words in dracula {draculaStats.numberOfWords()}");
        Console.Write("\n");

        var ohaganStats = new FileTextStatistics("Sampledata/ohagan.txt");
        ohaganStats.analyse();
        frequentWords = ohaganStats.topWords(20);
        longestWords = ohaganStats.longestWords(10);
        Console.WriteLine($"Number of lines in ohagan {ohaganStats.numberOfLines()}");
        Console.WriteLine($"Number of words in ohagan {ohaganStats.numberOfWords()}");
    }
}
