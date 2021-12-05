namespace BeautySaloon
{
    public class HairStyle : HairBase
    {
        public override string Title => "Прическа";
        public override int Price => 100;

        public HairStyle(HairLength hairLength) : base(hairLength) { }

    }
}
