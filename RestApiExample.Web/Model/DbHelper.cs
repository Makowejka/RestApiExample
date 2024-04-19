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
    public List<ProductModel> GetProducts()
    {
        List<ProductModel> response = new List<ProductModel>();
        var dataList = _context.Products.ToList();
        dataList.ForEach(row => response.Add(new ProductModel()
        {
            Brand = row.Brand,
            Id = row.Id,
            Name = row.Name,
            Price = row.Price,
            Size = row.Size
        }));
        return response;
    }

    public ProductModel GetProductById(int id)
    {
        ProductModel response = new ProductModel();
        var row = _context.Products.FirstOrDefault(d => d.Id.Equals(id));
        return new ProductModel()
        {
            Brand = row!.Brand,
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
        void DeleteOrder(int id)
        {
            var order = _context.Orders.FirstOrDefault(d => d.Id.Equals(id));
            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
        }
    }
}
