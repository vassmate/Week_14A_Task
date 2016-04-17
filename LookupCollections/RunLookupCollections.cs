using System;
using System.Collections;
using System.Collections.Specialized;
using System.Globalization;


namespace LookupCollections
{
    class RunLookupCollections
    {
        static void Main(string[] args)
        {
            ListDictionary newDictionary = new ListDictionary(new CaseInsensitiveComparer(CultureInfo.InvariantCulture));
            newDictionary["Estados Unidos"] = "United States";
            newDictionary["Canadá"] = "Canada";
            newDictionary["Espana"] = "Spain";

            Console.WriteLine(newDictionary["Canadá"]);
            Console.WriteLine(newDictionary["ESPANA"]);
            Console.ReadKey();
        }
    }
}
