using Entities;
using MediatR;

namespace Application.Queries
{
    public class GetProductsQuery : IRequest<IList<Product>>
    {
        public string filter { get; set; }
        public int pageNumber { get; set; }
    }
}
