using Entities;
using MediatR;

namespace Application.Queries
{
    public class GetCategoriesQuery : IRequest<IList<Category>>
    {
        public string filter { get; set; }
        public int pageNumber { get; set; }
    }
}
