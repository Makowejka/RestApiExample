namespace RestApiExample.Web.Model;

public class OrderModel
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }
}
