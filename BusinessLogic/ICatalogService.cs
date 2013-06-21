namespace BusinessLogic
{
    public interface ICatalogService
    {
        RetrieveAvailableProductsResponse RetrieveAvailableProducts(RetrieveAvailableProductsRequest request);
    }
}
