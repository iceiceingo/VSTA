namespace VSTA.Test;

/// <summary>
/// Ensures that text stored in text files can be analysed.
/// </summary>
public class TestFileTextStatistics
{
    [Fact]
    public void TestEmptyFile()
    {
        // Perform analys on empty file.
        var stats = new FileTextStatistics("Testdata/empty.txt");
        stats.analyse();
        // Assert that file was analysed empty.
        Assert.Equal(0, stats.numberOfLines());
        Assert.Equal(0, stats.numberOfWords());
        Assert.Empty(stats.longestWords(1));
        Assert.Empty(stats.topWords(1));
    }

    [Fact]
    public void TestSmallFile()
    {
        // Words we exect to been analysed as words (and in correct order).
        var wordsByFreq = new List<string>{ "ingo", "daliga" , "hej", "meningar" };
        var wordsByLength = new List<string>{ "meningar", "daliga" , "ingo", "hej"};
        // Perform analys on empty file.
        var stats = new FileTextStatistics("Testdata/withdata.txt");
        stats.analyse();

        // Assert that file was analysed empty.
        Assert.Equal(1, stats.numberOfLines());
        Assert.Equal(4, stats.numberOfWords());

        var longestWords = stats.longestWords(4);
        var topWords = stats.topWords(4);
        for(int i = 0; i < 4; i++)
        {
            Assert.Equal(wordsByFreq[i], topWords[i].word);
            Assert.Equal(wordsByLength[i], longestWords[i]);
        }
    }

    [Fact]
    public void TestLargeFile()
    {
        
    }    
}