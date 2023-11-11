using Application.Interfaces;
using Entities;
using WebApi.EF;

namespace WebApi.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private ShopDbContext _context;

        public CategoryRepository(ShopDbContext context)
        {
            _context = context;
        }
        public void Create(Category entity)
        {
            if(_context.Categories.SingleOrDefault(p=>p.Id == entity.Id)!= null)
            {
                Update(entity);
            }
            _context.Categories.Add(entity);
            _context.SaveChanges();
        }

        public IList<Category> Get(string filter,int pageNumber)
        {
            if (filter != "")
            {
                return _context.Categories.Where(p => p.Name.Contains(filter))
                    .Skip(pageNumber*10).Take(10).ToList();
            }
            else
            {
                return _context.Categories
                    .Skip(pageNumber * 10).Take(10).ToList();
            }
        }

        public Category GetById(int id)
        {
            return _context.Categories.Find(id);
        }

        public void Update(Category entity)
        {
            var category = _context.Categories.SingleOrDefault(c => c.Id == entity.Id);
            if(category == null)
            {
                Create(entity);
            }
            category.Name = entity.Name;
            if (category != null)
            {
                _context.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }
        }
    }
}
