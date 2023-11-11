using MediatR;
using Application.Queries;
using Entities;
using Application.Commands;
using Application.Interfaces;

namespace WebApi.Handlers
{
    public class ProductHandler 
        : IRequestHandler<GetProductsQuery, IList<Product>>,
          IRequestHandler<GetProductByIdQuery,Product>,
          IRequestHandler<CreateProductCommand>,
          IRequestHandler<UpdateProductCommand>
    {
        private IProductRepository _productRepository;
        public ProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public Task<IList<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return Task.Run(() => _productRepository.Get(request.filter,request.pageNumber));
        }

        public Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.Run(() => _productRepository.GetById(request.Id));
        }

        public Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Product product = new Product();
            product.Name = request.Name;
            product.CategoryId = request.CategoryId;
            return Task.Run(() => _productRepository.Create(product));
        }

        public Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            Product product = new Product();
            product.Id = request.Id;
            product.Name = request.Name;
            product.CategoryId = request.CategoryId;
            return Task.Run(() => _productRepository.Update(product));
        }
    }
}
