namespace BeautySaloon
{
    public class HairCare : HairBase
    {
        public override int Price
        {
            get
            {
                return 50;
            }
        }

        public HairCare(HairLength hairLength): base(hairLength) { }
    }
}
