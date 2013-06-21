namespace BusinessLogic
{
    public class Product
    {
        public Product(string productName)
        {
            ProductName = productName;
        }

        public string ProductName { get; private set; }
    }
}