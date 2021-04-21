using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using YamlConfigCreator.Entities;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace YamlConfigCreator
{
    class Program
    {
        static void Main(string[] args)
        {

            uint count = 0;
            if (args.Length == 0)
            {
                Console.WriteLine("Please provide command line arguments");
                return;
            }
             


            var valid = Configuration.LoadArgs(args);

            if (!valid)
            {
                Console.WriteLine("Configuration is not valid!");
                return;
            }


            if (!File.Exists(Configuration.File))
            {
                Console.WriteLine($"File {Configuration.File} does not exits");
                return;
            }
            
            List<string> markers = FileLoader.LoadFile(Configuration.File);
            Creator.CreateYaml(markers);

        }
    }
}