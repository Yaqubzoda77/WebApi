using Domain.Entits;
using Dapper;
using Domain.Dtos;
using Npgsql;
namespace Infrustructure.Services;

public class OrderServices
{
    private string _connectionString = "Server=127.0.0.1;Port=5432;Database=exem4;User Id=postgres;Password=13577;";

    public OrderServices()
    {

    }

    public List<Order> GetOrders()
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM orders";
            var result = connection.Query<Order>(sql);
            return result.ToList();
        }
    }

    public bool AddOrders(Order order)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            string sql =
                $"INSERT INTO orders (product_id    Customer_id      createdate          Productcoubnt         Price )" +
                $" VALUES ('{order.productid}' , '{order.Customerid}' , '{order.createdat}'  , '{order.Productcoubnt}'  , '{order.Price}'  )";
            var insert = connection.Execute(sql);
            if (insert > 0) return true;
            else return false;
        }
    }

    public bool UpdateOrder(Order order)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            string sql =
                $"update Orders set productid ='{order.productid}' , '{order.Customerid}','{order.createdat}'  , '{order.Productcoubnt}'  , '{order.Price}'  where id = '{order.Id}'";
            var update = connection.Execute(sql);
            if (update > 0) return true;
            else return false;
        }
    }

    public bool DeleteOrder(int Id)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            string sql = $"delete from orders where id = {Id}";
            var delete = connection.Execute(sql);
            if (delete > 0) return true;
            else return false;
        }
    }


    public List<GetOrderDto> InformationAboutCustomerANDOrders()
    {

        using (var connection = new NpgsqlConnection(_connectionString))
        {
            string sql =
                "select o.id,p.id as ProductId, c.id as CustomerId, o.createdat as CreatedDate, o.productcount as ProductCount, o.price as Price, p.productname as ProductName, c.firstname from orders o join customers c on c.id = o.customerid join products p on o.productid = p.id";
            var result = connection.Query<GetOrderDto>(sql);
            return result.ToList();
        }


    }


    public List<GetOrderDto> ALLOrdersByApple()
    {

        using (var connection = new NpgsqlConnection(_connectionString))
        {
            string sql = "select*from orders as o join products as p on o.id = p.Id where Company = 'Apple'";
            var result = connection.Query<GetOrderDto>(sql);
            return result.ToList();
        }


    }

    public List<GetOrderDto> ALLOrdersUpTo1000h()
    {


        using (var connection = new NpgsqlConnection(_connectionString))
        {
            string sql =
                "select ProductName  from Products  as p join orders as o on p.Id = o.Id where o.Price > 1000";
            var result = connection.Query<GetOrderDto>(sql);
            return result.ToList();
        }


    }
    public List<GetOrderDto> ALLCustomerleft()
    {


        using (var connection = new NpgsqlConnection(_connectionString))
        {
            string sql = $"select * from Customers as c  LEFT JOIN Products as p on  c.Id  = p.Id;";
            var result = connection.Query<GetOrderDto>(sql);
            return result.ToList();
        }


    }
    
    public List<GetOrderDto> ALLCustomerRight()
    {


        using (var connection = new NpgsqlConnection(_connectionString))
        {
            string sql = $"select * from Customers as c  right JOIN Products as p on  c.Id  = p.Id;";
            var result = connection.Query<GetOrderDto>(sql);
            return result.ToList();
        }


    }
    public List<GetOrderDto> ALLCustomerFull()
    {


        using (var connection = new NpgsqlConnection(_connectionString))
        {
            string sql = $"select * from Customers as c  full outer join Products as p on  c.Id  = p.Id;";
            var result = connection.Query<GetOrderDto>(sql);
            return result.ToList();
        }
    

    }

    
}

