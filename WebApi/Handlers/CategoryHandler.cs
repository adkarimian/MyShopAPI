using MediatR;
using Application.Queries;
using Entities;
using Application.Commands;
using Application.Interfaces;

namespace WebApi.Handlers
{
    public class CategoryHandler :
        IRequestHandler<GetCategoriesQuery, IList<Category>>,
        IRequestHandler<GetCategoryByIdQuery,Category>,
        IRequestHandler<UpdateCategoryCommand>,
        IRequestHandler<CreateCategoryCommand>
    {
        private ICategoryRepository _categoryRepository;
        public CategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public Task<IList<Category>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            return Task.Run(()=>_categoryRepository.Get(request.filter,request.pageNumber));
        }

        public Task<Category> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.Run(() => _categoryRepository.GetById(request.Id));
        }

        public Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category = new Category();
            category.Id = request.Id;
            category.Name = request.Name;
            return Task.Run(() => _categoryRepository.Update(category));
        }

        public Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category = new Category();
            //category.Id = request.Id;
            category.Name = request.Name;
            return Task.Run(() => _categoryRepository.Create(category));
        }
    }
}
