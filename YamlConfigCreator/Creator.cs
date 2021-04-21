using System.Collections.Generic;
using System.IO;
using YamlConfigCreator.Entities;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace YamlConfigCreator
{
    public class Creator
    {
        public static void CreateYAML(List<string> inputMarkers, string outputMarker)
        {
            var inputs = new List<InputFeature>();

            if (inputMarkers.Contains("ERK1_1") && inputMarkers.Contains("ERK1_2"))
                inputMarkers.Remove("ERK1_1");
            
            
            
            foreach (var marker in inputMarkers)
            {
                inputs.Add(  new InputFeature()
                {
                    Name = marker,
                    Type = "numerical",
                    Dropout = 10,
                    NumLayers = 20,
                    Normalization = "minmax",
                    Activation = "relu",
                });   
            }

            var ludwigAi = new LudwigAI
            {
                InputFeatures = inputs,
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
            File.WriteAllText("WriteLines.txt", yaml);
            
        }
    }
}