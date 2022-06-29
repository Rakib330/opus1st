using opus1st.Models;
using System.Linq;

namespace opus1st.Services
{
    public interface IOrder
    {
        IQueryable<Order> Get();
        IQueryable<Product> GetProduct();
        Order Get(int id);
        bool Insert(Order product);
        bool Update(Order product);
        bool Delete(int id);
       
    }
}
