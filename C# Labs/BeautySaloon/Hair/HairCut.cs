namespace BeautySaloon
{
    public class HairCut : HairBase
    {
        public override int Price
        {
            get
            {
                return 300;
            }
        }

        public HairCut(HairLength hairLength) : base(hairLength) { }
    }
}
