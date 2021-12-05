namespace BeautySaloon
{
    public class HairCut : HairBase
    {
        public override string Title => "Стрижка";
        public override int Price => 300;

        public HairCut(HairLength hairLength) : base(hairLength) { }
    }
}
