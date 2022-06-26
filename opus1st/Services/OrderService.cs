using Microsoft.EntityFrameworkCore;
using opus1st.Models;
using System.Linq;

namespace opus1st.Services
{
    public class OrderService : IOrder
    {
        ProductDbContext db;
        public OrderService(ProductDbContext db)
        {
            this.db = db;
        }

        public bool Delete(int id)
        {
            db.Entry(new Order { Id = id }).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            return db.SaveChanges() > 0;
        }

        public IQueryable<Order> Get()
        {

            return db.Orders.Include(x=>x.Product).AsQueryable();
        }
        public IQueryable<Product> GetProduct()
        {

            return db.Products.AsQueryable();
        }
        public Order Get(int id)
        {
            return db.Orders.FirstOrDefault(x => x.Id == id);
        }

        
        public bool Insert(Order Order)
        {
            db.Orders.Add(Order);
            return db.SaveChanges() > 0;
        }
        public bool Update(Order Order)
        {
            db.Entry(Order).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return db.SaveChanges() > 0;
        }
    }
}
