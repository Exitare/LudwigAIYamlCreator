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
                return;
            
        
            Configuration.LoadArgs(args);
           Console.WriteLine($"File is {Configuration.File}");
           Console.WriteLine($"Activation is {Configuration.ActivationFunction}");


           if (!File.Exists(Configuration.File))
           {
               Console.WriteLine($"File {Configuration.File} does not exits");
               return;
           }
           // TODO add config. Search for config trigger, get value by place  +1 

            List<string> markers = FileLoader.LoadFile(Configuration.File);

            foreach (var marker in markers)
            {
                Console.WriteLine(marker);
            }
            
            

            /*var ludwigAi = new LudwigAI
            {
                InputFeatures = new List<InputFeature>()
                {
                    new InputFeature()
                    {
                          Name = "HER2",
                          Type = "numerical",
                          Dropout = 10,
                          NumLayers = 20,
                          Normalization = "minmax",
                          Activation = "relu",
                    }
                },
                OutputFeatures = new List<OutputFeature>()
                {
                    new OutputFeature()
                    {
                        Name = "CD45",
                        Type = "numerical",
                        Activation = "relu",
                        Normalization = "minmax",
                        NumLayers = 2,
                        FcSize = 512,
                        Loss = new OutputFeatureLoss
                        {
                            Type = "mean_squared_error",
                        }
                    } 
                },
                Training = new Training
                {
                    BatchSize = 96,
                    Epochs = 100,
                }
            };
            
            
            var serializer = new SerializerBuilder()
                .WithNamingConvention(UnderscoredNamingConvention.Instance)
                .Build();
            var yaml = serializer.Serialize(ludwigAi);
            System.Console.WriteLine(yaml);
               */
        }
    }
}