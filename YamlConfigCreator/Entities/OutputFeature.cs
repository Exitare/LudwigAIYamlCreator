namespace YamlConfigCreator.Entities
{
    public class OutputFeature
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Activation { get; set; }
        public string Normalization { get; set; }
        public int NumLayers { get; set; }
        public int FcSize { get; set; }
        
        public OutputFeatureLoss Loss { get; set; }
        
    }
}