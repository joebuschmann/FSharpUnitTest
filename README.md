FSharpUnitTest
==============

This repository contains a short demo project showing how to create mocks using F# [Object Expressions](http://msdn.microsoft.com/en-us/library/dd233237.aspx). Object Expressions are useful when writing unit tests because they reduce the need for a mocking framework or creating mocks with static class definitions.

##Example

```
module OrderTests

open Xunit
open BusinessLogic

let mockProducts = seq { yield new Product("Product 1")
                         yield new Product("Product 2")
                         yield new Product("Product 3")
                         yield new Product("Product 4") }

let getMockOrderState() =
  let productsInState = ref Seq.empty
  { new IOrderState with
    member x.Products with get() = !productsInState
                      and set(value) = productsInState := value }

[<Fact>]
let TestGetAvailableProducts() =
  let mockCatalogService = { new ICatalogService with
    member x.RetrieveAvailableProducts(request) =
      new RetrieveAvailableProductsResponse(mockProducts) }
  let order = new Order()
  let products = order.GetAvailableProducts(mockCatalogService)
  Assert.Equal(4, Seq.length(products))
  Assert.Same(mockProducts, products)
```


