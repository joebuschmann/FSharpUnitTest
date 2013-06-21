using System.Collections.Generic;

namespace BusinessLogic
{
    public class RetrieveAvailableProductsResponse
    {
        public RetrieveAvailableProductsResponse(IEnumerable<Product> products)
        {
            Products = products;
        }

        public IEnumerable<Product> Products { get; private set; }
    }
}