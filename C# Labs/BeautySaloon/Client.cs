namespace BeautySaloon
{
    public class Client
    {
        public HairLength HairLength { get; }
        public string Name { get; }
        public Client(string name, HairLength length)
        {
            Name = name;
            HairLength = length;
        }

        public override string ToString()
        {
            return $"{Name} ({HairLength.Length} волосы)";
        }
    }
}
