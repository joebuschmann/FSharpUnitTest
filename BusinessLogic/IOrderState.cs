using System.Collections.Generic;

namespace BusinessLogic
{
    public interface IOrderState
    {
        IEnumerable<Product> Products { get; set; }
    }
}