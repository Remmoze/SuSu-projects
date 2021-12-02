namespace BeautySaloon
{
    public class HairStyle : HairBase
    {
        public override int Price
        {
            get
            {
                return 100;
            }
        }

        public HairStyle(HairLength hairLength) : base(hairLength) { }

    }
}
