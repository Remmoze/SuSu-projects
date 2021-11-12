namespace BeautySaloon
{
    public class Client
    {
        public HairLengthRoot.HairLength HairLength { get; }
        public string Name { get; }
        public Client(string name, HairLengthRoot.HairLength length)
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
