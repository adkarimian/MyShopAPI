using Application.Interfaces;
using Entities;
using WebApi.EF;

namespace WebApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ShopDbContext _context;

        public ProductRepository(ShopDbContext context)
        {
            _context = context;
        }
        public void Create(Product entity)
        {
            if(_context.Products.SingleOrDefault(p => p.Id == entity.Id) != null)
            {
                Update(entity);
            }
            _context.Products.Add(entity);
            _context.SaveChanges();
        }

        public IList<Product> Get(string filter,int pageNumber)
        {
            if (filter != "")
            {
                return _context.Products.Where(p => p.Name.Contains(filter))
                    .Skip(pageNumber * 10).Take(10).ToList();
            }
            else
            {
                return _context.Products
                    .Skip(pageNumber * 10).Take(10).ToList();
            }
        }

        public Product GetById(int id)
        {
            return _context.Products.Find(id);
        }

        public void Update(Product entity)
        {
            var product = _context.Products.SingleOrDefault(c => c.Id == entity.Id);
            if(product == null)
            {
                Create(entity);
            }
            product.Name = entity.Name;
            //product.CategoryId = entity.CategoryId;
            if (product != null)
            {
                _context.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }
        }
    }
}
