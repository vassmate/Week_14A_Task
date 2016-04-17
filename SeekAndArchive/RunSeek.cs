using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace SeekAndArchive
{
    class RunSeek
    {
        private static List<FileInfo> foundFiles;
        private static List<FileSystemWatcher> watchers;
        private static List<DirectoryInfo> archiveDirs;

        static void Main(string[] args)
        {
            //Getting the filename and the directory from the console arguments
            string fileName = args[0];
            string directory = args[1];

            //Getting the directory path for later checking if it's exist or not
            DirectoryInfo dirInf = new DirectoryInfo(directory);

            //Lists for handling the data after the search
            foundFiles = new List<FileInfo>();
            watchers = new List<FileSystemWatcher>();
            archiveDirs = new List<DirectoryInfo>();

            //Write a blank line after the program starts
            Console.WriteLine();

            //Check if the directory is exist or not
            if (!dirInf.Exists)
            {
                Console.WriteLine(">The directory does not exist.");
                Console.ReadKey();
                return;
            }

            //Search for files
            RecursiveSearch(foundFiles, fileName, dirInf);

            //Write out the number of files and their name
            Console.WriteLine(">Found files: {0}", foundFiles.Count);
            foreach (FileInfo file in foundFiles)
            {
                Console.WriteLine(">{0}", file.FullName);
            }

            //Set up watchers for each file in the list
            foreach (FileInfo file in foundFiles)
            {
                FileSystemWatcher newWatcher = new FileSystemWatcher(file.DirectoryName, file.Name);
                newWatcher.Changed += new FileSystemEventHandler(FileWatcherChanged);

                newWatcher.EnableRaisingEvents = true;
                watchers.Add(newWatcher);
            }

            //Creating directories for archiving file(s)
            for (int n = 0; n < foundFiles.Count; n++)
            {
                archiveDirs.Add(Directory.CreateDirectory("archive" + n));
            }

            //Exit the application
            Console.WriteLine(">Press any key to exit...");
            Console.ReadKey();
        }

        //Search in the given directory and its sub-directories
        static void RecursiveSearch(List<FileInfo> foFiles, string fileName, DirectoryInfo currentDirectory)
        {
            foreach (FileInfo file in currentDirectory.GetFiles())
            {
                if (file.Name == fileName)
                {
                    foFiles.Add(file);
                }
            }

            foreach (DirectoryInfo dir in currentDirectory.GetDirectories())
            {
                RecursiveSearch(foFiles, fileName, dir);
            }
        }

        //Handles the change events
        static void FileWatcherChanged(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType == WatcherChangeTypes.Changed)
            {
                Console.WriteLine(">{0} has been changed!", e.FullPath);
            }

            FileSystemWatcher senderWatcher = (FileSystemWatcher)sender;
            int index = watchers.IndexOf(senderWatcher, 0);

            ArchiveFile(archiveDirs[index], foundFiles[index]);
        }

        //Compressing the file into another directory
        static void ArchiveFile(DirectoryInfo archiveDir, FileInfo fileToArchive)
        {
            FileStream input = fileToArchive.OpenRead();
            FileStream output = File.Create(archiveDir.FullName + @"\" + fileToArchive.Name + ".gz");
            GZipStream compressor = new GZipStream(output, CompressionMode.Compress);

            int b = input.ReadByte();
            while (b != -1)
            {
                compressor.WriteByte((byte) b);
                b = input.ReadByte();
            }

            compressor.Close();
            input.Close();
            output.Close();
        }
    }
}
