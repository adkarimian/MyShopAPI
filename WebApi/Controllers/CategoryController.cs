using Application.Commands;
using Application.Queries;
using Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    //[Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoryController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        [Route("category")]
        public async Task<ActionResult<IList<Category>>> Get(GetCategoriesQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Route("category/{id}")]
        public async Task<ActionResult<Category>> GetById(int id)
        {
            var query = new GetCategoryByIdQuery();
            query.Id = id;
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [Authorize(Roles="Admin")]
        [HttpPost]
        [Route("category")]
        public async Task<IActionResult> Create(CreateCategoryCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        [Route("category")]
        public async Task<IActionResult> Update(UpdateCategoryCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
