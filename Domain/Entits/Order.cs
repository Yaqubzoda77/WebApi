namespace Domain.Entits;

public class Order
{


    public int Id { get; set; }

    public int productid { get; set; }
    public int Customerid { get; set; }
    public DateTime createdat { get; set; }
    public int Productcoubnt { get; set; }
    public int Price { get; set; }
 
}
