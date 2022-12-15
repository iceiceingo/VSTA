namespace VSTA.Core;

/// <summary>
/// FileTextStatistics provides statistics for texts stored in local files.
/// </summary>
public class FileTextStatistics : BaseTextStatistics
{
    #region Private Memebers
    private string path;
    #endregion

    public FileTextStatistics(string path)
    {
        this.path = path;
    }

    public override IEnumerable<string> loadData()
    {
        // We return a lazy loaded IEnumerable<string>.
        return File.ReadLines(this.path);
    }
}
