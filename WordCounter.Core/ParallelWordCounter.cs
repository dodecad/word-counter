using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordCounter.Core.Contracts;

namespace WordCounter.Core
{
    public class ParallelWordCounter : IWordCounter
    {
        private readonly IFileSystem _fileSystem;
        private readonly char[] _delimiters = {' ', '\n'};

        public ParallelWordCounter() :
            this(fileSystem: new FileSystem())
        {
        }

        public ParallelWordCounter(IFileSystem fileSystem)
        {
            this._fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }
        
        public IDictionary<string, int> CountWords(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException(nameof(path));
            
            var comparer = StringComparer.OrdinalIgnoreCase;
            var encoding = Encoding.GetEncoding(Constants.Windows1251);
            var result = new ConcurrentDictionary<string, int>(comparer);

            Parallel.ForEach(this._fileSystem.File.ReadLines(path, encoding), line =>
            {
                var words = line.Split(_delimiters, StringSplitOptions.RemoveEmptyEntries);

                foreach (var word in words)
                    result.AddOrUpdate(word, 1, (_, x) => x + 1);
            });

            return result
                .OrderByDescending(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Value);
        }
    }
}
