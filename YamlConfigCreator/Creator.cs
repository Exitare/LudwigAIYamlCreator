using System;
using System.Collections.Generic;
using System.IO;
using YamlConfigCreator.Entities;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace YamlConfigCreator
{
    public class Creator
    {
        public static void CreateYaml(List<string> availableMarkers)
        {
            var inputs = new List<InputFeature>();


            if (!availableMarkers.Contains(Configuration.OutputFeature))
            {
                Console.WriteLine($"Dataset does not contain specified output feature {Configuration.OutputFeature}");
                Environment.Exit(20);
            }

            availableMarkers.Remove(Configuration.OutputFeature);
            
            if (availableMarkers.Contains("ERK1_1") && availableMarkers.Contains("ERK1_2"))
                availableMarkers.Remove("ERK1_1");
            
            
            
            foreach (var marker in availableMarkers)
            {
                inputs.Add(  new InputFeature()
                {
                    Name = marker,
                    Type = "numerical",
                    Dropout = Configuration.Dropout,
                    NumLayers =Configuration.NumLayers,
                    Normalization = Configuration.Normalization,
                    Activation = Configuration.ActivationFunction,
                });   
            }

            var ludwigAi = new LudwigAI
            {
                InputFeatures = inputs,
                OutputFeatures = new List<OutputFeature>()
                {
                    new OutputFeature()
                    {
                        Name = Configuration.OutputFeature,
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
            File.WriteAllText("TestConfig.yaml", yaml);
            
        }
    }
}