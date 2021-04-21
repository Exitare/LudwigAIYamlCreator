namespace YamlConfigCreator.Entities
{
    public class InputFeature
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int NumLayers { get; set; }
        public string Activation { get; set; }
        public int Dropout { get; set; }
        public string Normalization { get; set; }
    }
}