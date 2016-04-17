using System.IO;
using System.IO.IsolatedStorage;
using System;

namespace IsolatedStorageDemo
{
    class RunIsolatedStorage
    {
        static void Main(string[] args)
        {
            string fileName = "UserSettings.set";

            IsolatedStorageFile userStore = IsolatedStorageFile.GetUserStoreForAssembly();
            IsolatedStorageFileStream userStream = new IsolatedStorageFileStream(fileName, FileMode.Create,
                userStore);

            StreamWriter userWriter = new StreamWriter(userStream);
            userWriter.WriteLine("User Prefs");
            userWriter.Close();

            string[] files = userStore.GetFileNames(fileName);

            if (files.Length == 0)
            {
                Console.WriteLine(">The file does not exist!");
                Console.WriteLine(">Press any key to exit...");
                Console.ReadKey();
                return;
            }

            try
            {
                userStream = new IsolatedStorageFileStream(fileName, FileMode.Open, FileAccess.Read, userStore);
                StreamReader userReader = new StreamReader(userStream);
                string contents = userReader.ReadToEnd();
                Console.WriteLine(">Contents of " + fileName + ": " + contents);
            }
            catch(Exception e)
            {
                Console.WriteLine(">Exception occured: " + e.Message);
            }

            Console.WriteLine(">Press any key to exit...");
            Console.ReadKey();
        }
    }
}
