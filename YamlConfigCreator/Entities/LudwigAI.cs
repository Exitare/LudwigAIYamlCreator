using System.Collections.Generic;

namespace YamlConfigCreator.Entities
{
    public class LudwigAI
    {
        public List<InputFeature> InputFeatures { get; set; }
        public List<OutputFeature> OutputFeatures { get; set; }
        public Training Training { get; set; }
    }
}