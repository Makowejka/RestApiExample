using Humanizer;
using Microsoft.EntityFrameworkCore;
using RestApiExample.Web.EfCore;
using RestApiExample.Web.Model;

namespace RestApiExample.Web;

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
        Order? dbTable = new Order();

        if (orderModel.Id > 0)
        {
            //PUT
            dbTable = _context.Orders.FirstOrDefault(d => d.Id.Equals(orderModel.Id));

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
            dbTable.Products = _context.Products.Where(f => f.Id.Equals(orderModel.ProductId)).ToList();

            _context.Orders.Add(dbTable);
        }

        _context.SaveChanges();
        }

    public void SaveManyOrders(List<OrderModel> orders)
    {
        foreach (var order in orders)
        {
            Order dbOrder = new Order
            {
                Phone = order.Phone,
                Address = order.Address,
                Name = order.Name,
                Products = _context.Products.Where(p => p.Id == order.ProductId).ToList()
            };

            _context.Orders.Add(dbOrder);
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
