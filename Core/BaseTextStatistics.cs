using System.Collections.Concurrent;
using VSTA.Core.Interface;
namespace VSTA.Core
{
    /// <summary>
    /// BaseTextStatistics is a base class for all ITextStatistics implementations providing
    /// analyical and statistical logic so that the derived classes can be thought of as data providers.
    /// </summary>
    public abstract class BaseTextStatistics : ITextStatistics
    {
        #region ITextStatistics - Statistical logic based on the text.
        public long numberOfLines()
        {
            return this.lineCount;
        }
        public long numberOfWords()
        {
            return this.wordMap.Count;
        }
        public List<WordFrequency> topWords(int n)
        {
            // We sort by frequency decending and then by word acending.
            return this.wordMap.OrderByDescending(x => x.Value).ThenBy(y => y.Key).Take(n).Select(y => new WordFrequency{
                word = y.Key,
                frequency = y.Value
            }).ToList();
        }
        public List<string> longestWords(int n)
        {
            // We sort by the length of the word decending.
            return this.wordMap.OrderByDescending(x => x.Key.Length).Take(n).Select(x => x.Key).ToList();
        }
        #endregion

        #region BaseTextStatistics - Abstaction
        /// <summary>
        /// Derived classes implement this function act as data providers.
        /// </summary>
        /// <returns>The data as a IEnumerable</returns>
        public abstract IEnumerable<string> loadData();
        #endregion

        #region BaseTextStatistics - Analyical logic.
        /// <summary>
        /// The maximum number of threads to use for statistic processing.
        /// </summary>
        protected int threadCount = 10;
        // Maps a word to its frequency in a text.
        private ConcurrentDictionary<string, long> wordMap = new ConcurrentDictionary<string, long>();
        // Number of lines in text, shared by all threads.
        private long lineCount = 0;
        // Lock to use when incrementing lineCount
        private readonly object lineCountLock = new object();
        /// <summary>
        /// Performs analysis on data provided by derived classes.
        /// </summary>
        public void analyse()
        {
            this.analyse(this.loadData());
        }
        /// <summary>
        /// Provides multithreaded analytical logic on a IEnumerable<string>
        /// </summary>
        /// <param name="text">The text to analyse</param>
        private void analyse(IEnumerable<string> text)
        {
            var sanitizer = new WordTokenizer();
            int bucketSize = (int)Math.Ceiling((double)text.Count() / (double)this.threadCount);
            Parallel.For(0, this.threadCount, i => {
                var bucket = text.Skip((int)i * bucketSize).Take(bucketSize);
                var lc = 0;
                var tokenizer = new WordTokenizer();
                foreach (var line in bucket)
                {
                    // Split text by space and remove common end of sentence.
                    var words = tokenizer.tokenize(line);                    
                    foreach(var word in words)
                    {
                        wordMap.AddOrUpdate(word, 1, (k, v) => v+=1);
                    }
                    lc++;
                }
                // Lock since object is shared outside blockscope.
                lock(lineCountLock)
                {
                    this.lineCount += lc;
                }
            });
        }
        #endregion
    }
}