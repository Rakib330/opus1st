using opus1st.Models;
using System.Linq;

namespace opus1st.Services
{
    public interface IProduct
    {
        IQueryable<Product> Get();
        Product Get(int id);
        bool Insert(Product product);
        bool Update(Product product);
        bool Delete(int id);

    }
}
