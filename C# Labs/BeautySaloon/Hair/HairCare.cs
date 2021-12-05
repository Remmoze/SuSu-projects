namespace BeautySaloon
{
    public class HairCare : HairBase
    {
        public override string Title => "Уход за волосами";
        public override int Price => 50;

        public HairCare(HairLength hairLength) : base(hairLength) { }
    }
}
