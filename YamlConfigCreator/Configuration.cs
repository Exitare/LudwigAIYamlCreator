using System;
using System.Linq;

namespace YamlConfigCreator
{
    public static class Configuration
    {
        public static string OutputFeature { get; set; }
        public static string File { get; set; }
        public static string ActivationFunction { get; set; } = "relu";
        public static int NumLayers { get; set; } = 20;
        public static int Dropout { get; set; } = 10;
        public static string Normalization { get; set; } = "minmax";

        public static string Loss { get; set; } = "mean_squared_error";

        public static int FCSize { get; set; } = 512;


        public static bool LoadArgs(string[] args)
        {
            if (args.Length <= 1)
                return false;
            
            foreach (var arg in args)
            {
                Console.WriteLine(arg);
            }

            File = GetArg(args, "-f");
            ActivationFunction = ( GetArg(args, "-a") != "") ? GetArg(args, "-a"): ActivationFunction;
            NumLayers = (GetArg(args, "-n") != "") ? Convert.ToInt32(GetArg(args, "-n")) : NumLayers;
            Dropout = (GetArg(args, "-d") != "") ? Convert.ToInt32(GetArg(args, "-d")) : Dropout;
            OutputFeature = GetArg(args, "-o");
            Normalization =(GetArg(args, "-n") != "") ? GetArg(args, "-n") : Normalization;
            //string fileResult = args.ToList().Single(s => s == "-f");


            return !string.IsNullOrEmpty(File) && !string.IsNullOrEmpty(OutputFeature);
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