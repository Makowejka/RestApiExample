using RestApiExample.Web.EfCore;

namespace RestApiExample.Web.Model;

public class DbHelper
{
    private EfDataContext _context;

    public DbHelper(EfDataContext context)
    {
        _context = context;
    }

    // GET
    public List<ProductModel> GetProducts() =>
        _context
            .Products
            .Select(x => new ProductModel
                {
                    Brand = x.Brand,
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    Size = x.Size
                }
            )
            .ToList();

    public ProductModel? GetProductById(int id)
    {
        var row = _context.Products.FirstOrDefault(d => d.Id.Equals(id));

        if (row == null)
        {
            return null;
        }

        return new ProductModel
        {
            Brand = row.Brand,
            Id = row.Id,
            Name = row.Name,
            Price = row.Price,
            Size = row.Size
        };
    }

    // It serves the POST/PUT/PATCH
    public void SaveOrder(OrderModel orderModel)
    {
        Order dbTable = new Order();

        if (orderModel.Id > 0)
        {
            //PUT
            dbTable = _context.Orders.Where(d => d.Id.Equals(orderModel.Id)).FirstOrDefault();

            if (dbTable != null)
            {
                dbTable.Phone = orderModel.Phone;
                dbTable.Address = orderModel.Address;
            }
        }
        else
        {
            dbTable!.Phone = orderModel.Phone;
            dbTable.Address = orderModel.Address;
            dbTable.Name = orderModel.Name;
            dbTable.Product = _context.Products.FirstOrDefault(f => f.Id.Equals(orderModel.ProductId));

            _context.Orders.Add(dbTable);
        }

        _context.SaveChanges();
        }


    // DELETE
    public void DeleteOrder(int id)
    {
        var order = _context.Orders.FirstOrDefault(d => d.Id.Equals(id));

        if (order != null)
        {
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }
    }
}
