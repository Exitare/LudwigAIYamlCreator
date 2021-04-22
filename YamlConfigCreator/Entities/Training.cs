namespace YamlConfigCreator.Entities
{
    public class Training
    {
        public int BatchSize { get; set; } = 96;
        public int Epochs { get; set; } = 100;

        public string Regulizer { get; set; } = "L1";
    }
}