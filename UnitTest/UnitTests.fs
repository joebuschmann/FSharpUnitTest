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

[<Fact>]
let TestAddProductsToOrderUsingMockOrderState() =
  let order = new Order()
  let mockOrderState = getMockOrderState()
  order.AddProductsToOrder(mockProducts, mockOrderState)
  Assert.Equal(4, mockOrderState.Products |> Seq.length)
  mockOrderState.Products |> Seq.iteri (fun i p ->
                                          let i = i + 1
                                          Assert.Equal("Product " + i.ToString(), p.ProductName))

[<Fact>]
let TestAddProductsToOrder() =
  let products = ref []
  let mockOrder =
    { new Order() with
      member x.AddProductToState(product, state) = products := product :: !products }
  let mockOrderState = getMockOrderState()
  mockOrder.AddProductsToOrder(mockProducts, mockOrderState)
  Assert.Equal(0, mockOrderState.Products |> Seq.length)
  Assert.Equal(4, !products |> List.length)
  