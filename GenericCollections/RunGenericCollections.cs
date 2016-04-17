using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCollections
{
    class RunGenericCollections
    {
        static void Main(string[] args)
        {
            Dictionary<int, String> countryDict = new Dictionary<int, String>();
            countryDict[44] = "United Kingdom";
            countryDict[33] = "France";
            countryDict[31] = "Netherlands";
            countryDict[55] = "Brazil";

            Console.WriteLine("Country at 55: {0}", countryDict[55]);
            Console.WriteLine();

            foreach (KeyValuePair<int, String> element in countryDict)
            {
                int countryNumber = element.Key;
                string country = element.Value;

                Console.WriteLine("Country at " + countryNumber + ": " + country);
            }

            Console.ReadKey();
        }
    }
}
