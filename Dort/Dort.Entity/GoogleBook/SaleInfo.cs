using System.Collections.Generic;

namespace Dort.Entity.GoogleBook
{
    public class SaleInfo
    {
        public string Country { get; set; }
        public string Saleability { get; set; }
        public bool IsEbook { get; set; }
        public ListPrice ListPrice { get; set; }
        public RetailPrice RetailPrice { get; set; }
        public string BuyLink { get; set; }
        public List<Offer> Offers { get; }

        public SaleInfo()
        {
            Offers = new List<Offer>();
        }
    }
}
