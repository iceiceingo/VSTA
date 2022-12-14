using System.Collections.Generic;
namespace VSTA.Core.Interface;

/// <summary>
/// ITextStatistics repesents the contract for statistics of the text.
/// </summary>
public interface ITextStatistics
{
    /// <summary>
    /// The n most frequented words of the text.
    /// </summary>
    /// <param name="n">how many words</param>
    /// <returns>A list representing the top n frequented words of the text.</returns>
    List<WordFrequency> topWords(int n);
    /// <summary>
    /// The longest words of the text.
    /// </summary>
    /// <param name="n">how many words</param>
    /// <returns>A list of the longest words of the text</returns>
    List<string> longestWords(int n);
    /// <summary>
    /// The number of words of the text.
    /// </summary>
    /// <returns>The number of words as a long.</returns>
    long numberOfWords();
    /// <summary>
    /// The number of lines of the text.
    /// </summary>
    /// <returns>The number of lines as a long.</returns>         
    long numberOfLines();

}
