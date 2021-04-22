using System.Collections.Generic;

namespace YamlConfigCreator.Entities
{
    public class LudwigAI
    {
        public List<Preprocessing> Preproccesing { get; set; }
        public List<InputFeature> InputFeatures { get; set; }
        public List<OutputFeature> OutputFeatures { get; set; }
        public Training Training { get; set; }
    }
}