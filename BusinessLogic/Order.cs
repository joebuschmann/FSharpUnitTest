using System.Collections.Generic;

namespace BusinessLogic
{
    public class Order
    {
        public IEnumerable<Product> GetAvailableProducts(ICatalogService catalogService)
        {
            var request = new RetrieveAvailableProductsRequest();
            var response = catalogService.RetrieveAvailableProducts(request);

            return response.Products;
        }

        public void AddProductsToOrder(IEnumerable<Product> products, IOrderState orderState)
        {
            foreach (var product in products)
                AddProductToState(product, orderState);
        }

        protected virtual void AddProductToState(Product product, IOrderState orderState)
        {
            var products = new List<Product>(orderState.Products);
            products.Add(product);

            orderState.Products = products;
        }
    }
}
