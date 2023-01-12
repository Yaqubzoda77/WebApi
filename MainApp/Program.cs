
using Domain.Entits;
using Infrustructure.Services;
var orderServices = new OrderServices();
ShowOrder();
void ShowOrder()
{
    var allOrders = orderServices.GetOrders();
    foreach (var pr in allOrders)
    {
        System.Console.WriteLine($"Id: {pr.Id}  ProductId: {pr.Customer_id}  CustomerId: {pr.product_id}" +
          $"CreatedAt: {pr.createdate}    Price: {pr.Price}");
    }
}
void AddOrder()
{
    var order= new Order()
    {
        Customer_id = 5,
        product_id = 5,
        createdate = new DateTime(2023,11,24),
        Productcoubnt = 15,
        Price = 500,
    };
    orderServices.AddOrders(order);
}
AddOrder(); 



