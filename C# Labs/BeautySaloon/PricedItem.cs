namespace BeautySaloon
{
    public interface IPricedItem
    {
        public int Price { get; }
    }

    public interface IPricedHairItem : IPricedItem
    {
        public int CalculatePrice(HairLengthRoot.HairLength hairLength);
    }
}
