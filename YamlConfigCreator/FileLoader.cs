using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace YamlConfigCreator
{
    public class FileLoader
    {
        public static List<string> LoadFile(string path)
        {
            return File.ReadLines("ludwig_data.csv").First().Split(',').ToList();
        }
    }
}