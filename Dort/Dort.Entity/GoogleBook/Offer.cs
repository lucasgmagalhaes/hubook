namespace Dort.Entity.GoogleBook
{
    public class Offer
    {
        public int FinskyOfferType { get; set; }
        public ListPrice2 ListPrice { get; set; }
        public RetailPrice2 RetailPrice { get; set; }
        public bool Giftable { get; set; }
    }
}
