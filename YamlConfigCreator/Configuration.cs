using System;
using System.Linq;

namespace YamlConfigCreator
{
    public static class Configuration
    {
        public static string OutputFeature { get; set; }
        public static string File { get; set; }
        public static string ActivationFunction { get; set; } = "relu";
        public static uint NumLayers { get; set; } = 0;
        public static uint Dropout { get; set; } = 0;
        public static string Normalization { get; set; } = "minmax";


        public static void LoadArgs(string[] args)
        {
            if (args.Length <= 1)
                return;
            
            foreach (var arg in args)
            {
                Console.WriteLine(arg);
            }

            File = GetArg(args, "-f");
            ActivationFunction = ( GetArg(args, "-a") != "") ? GetArg(args, "-a"): ActivationFunction;
            NumLayers = (GetArg(args, "-n") != "") ? Convert.ToUInt32(GetArg(args, "-n")) : NumLayers;
            //string fileResult = args.ToList().Single(s => s == "-f");
           
            
            Console.WriteLine($"File {File}");
        }

        private static string GetArg(string[] args, string searchParam)
        {
            try
            {
                var pos = args.ToList().FindIndex(x => x == searchParam);
                return pos == -1 ? "" : args[pos + 1];
            }
            catch
            {
                return "";
            }
           
        }
    }
}