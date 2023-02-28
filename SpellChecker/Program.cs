using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

namespace SpellChecker
{
    internal class Program
    {
        //Multi Threading Case Study: Spell Checker Requirements
        //What: 

        //Requirements: 
        
        //1. Should use multi-threading concept to improve the performance.
        //2. Must apply data synchronization where ever required.
        //3. Should have dictionary file which contains English words list for providing the suggestion
        //to wrong word. 
        //4. You can use the words list file from http://wordlist.sourceforge.net
        //5. Should use Levenshtein Distance Matrix formulae while providing the suggested word
        //list.
        //6. User can terminate the current ongoing spell checking process.If so, application should
        //terminate all the ongoing threads.

        //Technology Stack: 
        
        //1. .NET - C# 4.0 
        //2. OO Concepts
        //3. Abstract Classes & Interfaces 
        //4. Namespaces 
        //5. Exception Handling 
        //6. IO Stream 
        //7. Threads and TPL

        //Note: Things to be done 
        
        //1. High Level Design, coding and testing 
        //2. Coding guidelines(To be strictly followed and enforced)

        static void Main(string[] args)
        {
            //We need to build an Application which should suggest a correct word for
            //misspelled/incomplete word.


            //Output: an ASCII text file should contains misspelled word with 10 nearest suggestions. 

            //We need to use Levenshtein Distance Matrix formulae to provide the suggested word list.

            //We need to use multi-threading concept to improve the performance.

            //We need to apply data synchronization where ever required.

            //Input: an ASCII text file contains a paragraph of words.Some words with incorrect spelling.

            //Read input file 
            Console.WriteLine("Reading Input File and Checking for spelling mistakes");
            string[] lines = File.ReadAllLines("input.txt");
            List<string> words = new List<string>();

            foreach (string line in lines)
            {
                string[] split = line.Split(' ');
                foreach (string word in split)
                {
                    string w = word.ToLower();
                    w = new string(w.Where(c => Char.IsLetter(c)).ToArray());

                    if (w.Length > 0)
                    {
                        words.Add(w);
                    }
                }
            }

            Dictionary<string, List<string>> suggestions = new Dictionary<string, List<string>>();
            SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);

            List<Task> tasks = new List<Task>();

            foreach (string word in words)
            {
                Task task = Task.Run(() =>
                {
                    List<string> nearestWords = GetNearestWords(word);

                    semaphore.Wait();

                    if (!suggestions.ContainsKey(word))
                    {
                        suggestions.Add(word, nearestWords);
                    }

                    semaphore.Release();
                });

                tasks.Add(task);
            }

            Task.WaitAll(tasks.ToArray());



        }



    }
}
