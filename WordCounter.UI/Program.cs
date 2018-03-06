using System;
using WordCounter.Core;
using WordCounter.Core.Helpers;

namespace WordCounter.UI
{
    class Program
    {
        static int Main(string[] args)
        {
            const string commandNotFound = "Command not found";
            
            try
            {
                #region Check arguments

                if (args == null)
                    throw new Exception(commandNotFound);

                if (args.Length == 1)
                {
                    if (HelpRequired(args[0]))
                    {
                        DisplayHelp();
                        return 0;
                    }
                }
                
                if (args.Length < 2)
                    throw new Exception(commandNotFound);
                
                #endregion Check arguments
                
                var counter = new ParallelWordCounter();
                var result = counter.CountWords(args[0]);

                FileHelpers.WriteDictionary(result, args[1]);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error occured: {e.Message}\nSource: {e.Source}");
                return 1;
            }
            
            return 0;
        }
        
        static void DisplayHelp()
        {
            Console.WriteLine(@"
A program that counts occurrences of each word in a file;
Written by Alexander Ivanov, email: dodecad@outlook.com;
Command line parameters: source_text_file dest_text_file.");
        }

        static bool HelpRequired(string param)
        {
            return param == "-h" || param == "--help" || param == "/?";
        }
    }
}
