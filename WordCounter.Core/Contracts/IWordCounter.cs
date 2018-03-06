using System.Collections.Generic;

namespace WordCounter.Core.Contracts
{
    public interface IWordCounter
    {
        IDictionary<string, int> CountWords(string path);
    }
}
