using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WordCounter.Core.Helpers
{
    public static class FileHelpers
    {
        public static void WriteDictionary<T1, T2>(IDictionary<T1, T2> data, string dest)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            if (string.IsNullOrWhiteSpace(dest))
                throw new ArgumentNullException(nameof(dest));

            var contents = data.Select(x => $"{x.Key}, {x.Value}");
            var encoding = Encoding.GetEncoding(Constants.Windows1251);
            File.WriteAllLines(dest, contents, encoding);
        }
    }
}
