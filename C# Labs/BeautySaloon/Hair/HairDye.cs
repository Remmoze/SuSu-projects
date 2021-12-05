namespace BeautySaloon
{
    public class HairDye : HairBase
    {
        public override string Title => "Окрашивание волос";
        public override int Price => 150;

        public HairDye(HairLength hairLength) : base(hairLength) { }
    }
}
