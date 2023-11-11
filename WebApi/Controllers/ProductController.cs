using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Queries;
using Application.Commands;
using Entities;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator) => _mediator = mediator;
        
        [HttpGet]
        [Route("product")]
        public async Task<ActionResult<IList<Product>>> Get(GetProductsQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Route("product/{id}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            var query = new GetProductByIdQuery();
            query.Id = id;
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("product")]
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        [Route("product")]
        public async Task<IActionResult> Update(UpdateProductCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
