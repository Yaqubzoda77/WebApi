namespace Infrustructure.Services;
using Domain.Entits;
using Dapper;
using Npgsql;
public class Productservices
{
    private string _connectionString = "Server=127.0.0.1;Port=5432;Database=exem4;User Id=postgres;Password=13577;";
    public Productservices()
    {
        
    }

    public List<Product> GetProduct()
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM products";
            var result = connection.Query<Product>(sql);
            return result.ToList();
        }
    }
    public bool AddProduct(Product product)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            string sql = $"INSERT INTO products (Productname    company      createdate          Productcoubnt         Price )" +
            $" VALUES ('{product.Productname}' , '{product.company}'    , '{product.Productcoubnt}'  , '{product.Price}'    )";
            var insert = connection.Execute(sql);
            if (insert > 0) return true;
            else return false;
        }
    }
    public bool UpdateProduct(Product product)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            string sql = $"update products set productid ='{product.Productname}' , '{product.company}'    , '{product.Productcoubnt}'  , '{product.Price}' where id = '{product.Id}'";
            var update = connection.Execute(sql);
            if (update > 0) return true;
            else return false;
        }
    }
    public bool DeleteProduct(int Id)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            string sql = $"delete from products where id = {Id}";
            var delete = connection.Execute(sql);
            if (delete > 0) return true;
            else return false;
        }
    }
}
