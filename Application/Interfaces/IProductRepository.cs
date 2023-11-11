using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProductRepository
    {
        public IList<Product> Get(string filter,int pageNumber);
        public void Create(Product entity);
        public void Update(Product entity);
        public Product GetById(int id);
    }
}
