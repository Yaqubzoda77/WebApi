using Domain.Entits;
using Dapper;
using Npgsql;
namespace Infrustructure.Services;

public class CustomerServices
{

    private string _connectionString = "Server=127.0.0.1;Port=5432;Database=exem4;User Id=postgres;Password=13577;";
    public CustomerServices()
    {
        
    }

    public List<Customer> GetCustumer()
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM custumers";
            var result = connection.Query<Customer>(sql);
            return result.ToList();
        }
    }   
    public bool AddCustumer(Customer customer)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            string sql = $"INSERT INTO custumers (Firstname)" +
            $" VALUES ('{customer.FirstName}')";
            var insert = connection.Execute(sql);
            if (insert > 0) return true;
            else return false;
        }
    }
    public bool UpdateCustumer(Customer customer)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            string sql = $"update custumers set productid ='{customer.FirstName}'  where id = '{customer.Id}'";
            var update = connection.Execute(sql);
            if (update > 0) return true;
            else return false;
        }
    }
    public bool DeleteCustumer(int Id)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            string sql = $"delete from custumers where id = {Id}";
            var delete = connection.Execute(sql);
            if (delete > 0) return true;
            else return false;
        }
    }
    
}
