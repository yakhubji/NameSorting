using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NameSort
{
    public class NameSorter
    {
        public static void Main(string[] args)
        {

            var NameSort = new NameSorter();
            

        }
        public NameSorter()
        {

            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sFile = System.IO.Path.Combine(sCurrentDirectory, @"..\..\..\UnSortedNames.txt");
            string sFilePath = Path.GetFullPath(sFile);
            string[] unsortedNames = File.ReadAllLines(sFilePath);
            var sortedNames = SortNames(unsortedNames);
            PrintNames(sortedNames);
            WriteNamesToFile(sortedNames);
        }
        public List<string> SortNames(string[] unsortedNames)
        {
            return unsortedNames
                .OrderBy(name => name.Split(' ').Last())
                .ThenBy(name => name)
                .ToList();
        }
        
        public void PrintNames(List<string> names)
        {
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }

        public  static void WriteNamesToFile(List<string> names)
        {
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sFile = System.IO.Path.Combine(sCurrentDirectory, @"..\..\..\sorted-names-list.txt");
            string sFilePath1 = Path.GetFullPath(sFile);
            // Write the sorted names to the file
            File.WriteAllLines(sFilePath1, names);

            // Alternatively, you can use StreamWriter to achieve the same result
            using (StreamWriter outputFile = new StreamWriter(sFilePath1))
            {
                foreach (var name in names)
                {
                    outputFile.WriteLine(name);
                }
            }
        }

    }
}




