using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICategoryRepository
    {
        public IList<Category> Get(string filter,int pageNumber);
        public void Create(Category entity);
        public void Update(Category entity);
        public Category GetById(int id);
    }
}
