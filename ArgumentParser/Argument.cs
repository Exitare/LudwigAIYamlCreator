namespace ArgumentParser
{
    public class Argument<T>
    {
        public string ShortCommand { get; set; }
        public string LongCommand { get; set; }
        public T Value { get; set; }
       // public T Type { get; set; }

       public Argument(string shortCommand, string longCommand)
       {
           ShortCommand = shortCommand;
           LongCommand = longCommand;
       }
    }
}