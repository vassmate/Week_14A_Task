using System;
using System.Collections;

namespace DictionaryCollections
{
    class RunCollection
    {
        static void Main(string[] args)
        {
            Hashtable newHashTable = new Hashtable();
            newHashTable["0"] = "Zero";
            newHashTable["1"] = "One";
            newHashTable["2"] = "Two";
            newHashTable["3"] = "Three";
            newHashTable["4"] = "Four";
            newHashTable["5"] = "Five";
            newHashTable["6"] = "Six";
            newHashTable["7"] = "Seven";
            newHashTable["8"] = "Eight";
            newHashTable["9"] = "Nine";

            string numbers = "35988876";

            foreach (char number in numbers)
            {
                string currentNumber = number.ToString();
                if (newHashTable.ContainsKey(currentNumber))
                {
                    Console.Write("-" + newHashTable[currentNumber]);
                }
            }

            Console.ReadKey();
        }
    }
}
