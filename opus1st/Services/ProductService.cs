using opus1st.Models;
using System.Linq;

namespace opus1st.Services
{
    public class ProductService : IProduct
    {
        ProductDbContext db;
        public ProductService(ProductDbContext db)
        {
            this.db = db;
        }

        public bool Delete(int id)
        {
            db.Entry(new Product { Id = id }).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            return db.SaveChanges() > 0;
        }

        public IQueryable<Product> Get()
        {

            return db.Products.AsQueryable();
        }

        public Product Get(int id)
        {
            return db.Products.FirstOrDefault(x => x.Id == id);
        }
        public bool Insert(Product product)
        {
            db.Products.Add(product);
            return db.SaveChanges() > 0;
        }
        public bool Update(Product product)
        {
            db.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return db.SaveChanges() > 0;
        }
    }
}
