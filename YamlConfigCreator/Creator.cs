using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using YamlConfigCreator.Entities;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace YamlConfigCreator
{
    public class Creator
    {
        public static void CreateYaml(List<string> availableMarkers)
        {
            
            // Multi file creation
            if (string.IsNullOrEmpty(Configuration.OutputFeature))
            {
                foreach (var marker in availableMarkers)
                {
                    Console.WriteLine($"Creating yaml file for marker: {marker}");
                    var inputMarkers = availableMarkers.Select(item => (string)item.Clone()).ToList();
                    if (marker is "ERK1_1" or "ERK1_2")
                    {
                        inputMarkers.Remove("ERK1_1");
                        inputMarkers.Remove("ERK1_2");
                    }
                    else
                        inputMarkers.Remove(marker);
                    
                    Yaml(inputMarkers, marker);
                }

                return;
            }
            
            
            if (!availableMarkers.Contains(Configuration.OutputFeature))
            {
                Console.WriteLine($"Dataset does not contain specified output feature {Configuration.OutputFeature}");
                Environment.Exit(20);
            }
            
            availableMarkers.Remove(Configuration.OutputFeature);
            
            if (availableMarkers.Contains("ERK1_1") && availableMarkers.Contains("ERK1_2"))
                availableMarkers.Remove("ERK1_1");
            
            Yaml(availableMarkers, Configuration.OutputFeature);
            
        }

        private static void Yaml(List<string> inputMarkers, string outputMarker)
        {
            var inputs = new List<InputFeature>();
            foreach (var marker in inputMarkers)
            {
                inputs.Add(new InputFeature()
                {
                    Name = marker,
                    Type = "numerical",
                    Dropout = Configuration.Dropout,
                    NumLayers = Configuration.NumLayers,
                    Normalization = Configuration.Normalization,
                    Activation = Configuration.ActivationFunction,
                });
            }

            var ludwigAi = new LudwigAI
            {
                InputFeatures = inputs,
                OutputFeatures = new List<OutputFeature>()
                {
                    new()
                    {
                        Name = outputMarker,
                        Type = "numerical",
                        Activation = Configuration.ActivationFunction,
                        Normalization = Configuration.Normalization,
                        NumLayers = Configuration.NumLayers,
                        FcSize = Configuration.FCSize,
                        Loss = new OutputFeatureLoss
                        {
                            Type = Configuration.Loss,
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
            if (!Directory.Exists("Results"))
                Directory.CreateDirectory("Results");

            File.WriteAllText($"Results/{Configuration.File}_{outputMarker}.yaml", yaml);

        }
    }
}