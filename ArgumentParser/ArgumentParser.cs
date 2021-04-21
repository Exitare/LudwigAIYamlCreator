using System;
using System.Collections.Generic;
using System.Linq;

namespace ArgumentParser
{
    public class ArgumentParser
    {
        private List<Argument> _arguments = new List<Argument>();

        public ArgumentParser()
        {

        }

        public void AddArgument<T>(string longCommand, string shortCommand)
        {
            _arguments.Add(new Argument<T>(longCommand, shortCommand));
        }

        public  void LoadArgs(string[] args)
        {
            if (args.Length is 0 or 1)
                return;
            
            foreach (var arg in args)
            {
                Console.WriteLine(arg);
            }

            foreach (var arg in _arguments)
            {
                var pos = args.ToList().FindIndex(x => x == arg.ShortCommand || x == arg.LongCommand);
                
            }
            
            //string fileResult = args.ToList().Single(s => s == "-f");
           

    
            
            

            File = args[pos + 1];

            Console.WriteLine($"File {File}");
        }
    }
}