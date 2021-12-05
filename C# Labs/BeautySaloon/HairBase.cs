namespace BeautySaloon
{
    public interface IPricedItem
    {
        public int Price { get; }
        public string Title { get; }
    }

    public abstract class HairBase : IPricedItem
    {
        public abstract int Price { get; }
        public abstract string Title { get; }
        public virtual HairLength HairLength { get; set; }

        public HairBase(HairLength hairLength)
        {
            HairLength = hairLength;
        }

        public virtual int FinalPrice()
        {
            return Price * HairLength.PriceMultiplier;
        }
    }

    public abstract class ItemBase : IPricedItem
    {
        public virtual int Price { get; }
        public abstract string Title { get; }
        public virtual int FinalPrice()
        {
            return Price;
        }
    }
}