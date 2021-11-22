namespace BeautySaloon
{
    public class HairDye : HairBase
    {
        public override int Price
        {
            get
            {
                return 150;
            }
        }

        public HairDye(HairLength hairLength) : base(hairLength) { }
    }
}
