using Microsoft.AspNetCore.Mvc;
using MediatR;
using CatalogService.Service.Model;
using CatalogService.Service.Authorization;

namespace CatalogService.Service.Controllers;

#region snippet_Route
[Route("api/[controller]")]
[ApiController]
[CustomAuthorization]

public class ProductsController : ControllerBase
#endregion
{
    // private readonly IProductService _service;
    private readonly ISender _mediator;

    // public ProductsController(IProductService _service) => _mediator = service;
    public ProductsController(ISender mediator) => _mediator = mediator;

    // GET: api/Products
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Products>>> GetProducts()
    {
        // var products = await _service.GetProducts();
        var products = await _mediator.Send(new GetAllProductsQuery());
        return Ok(products);
    }

    // GET: api/Products/5
    #region snippet_GetByID
    [HttpGet("{id}")]
    public async Task<ActionResult<Products>> GetProduct(long id)
    {
        // var product = await _service.GetProduct(id);
        var product = await _mediator.Send(new GetProductByIdQuery(id));
        if (product == null)
            return NotFound();
        return Ok(product);
    }
    #endregion

    // POST: api/Products
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    #region snippet_Create
    [HttpPost]
    public async Task<ActionResult<Products>> PostProduct(Products product)
    {
        // await _service.CreateProduct(product);
        await _mediator.Send(new AddProductCommand(product));

        //return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        return CreatedAtAction(nameof(GetProduct), new { id = product.ProductId }, product);
    }
    #endregion

    // PUT: api/Products/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    #region snippet_Update
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProduct(long id, Products product)
    {
        if (id != product.ProductId)
        {
            return BadRequest();
        }

        // var result = await _service.UpdateProduct(id, product);
        var result = await _mediator.Send(new UpdateProductCommand(product));
        // if (result == "NotFound")
        //     return NotFound();

        return NoContent();
    }
    #endregion


    // DELETE: api/Products/5
    #region snippet_Delete
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(long id)
    {
        // var product = await _service.GetProduct(id);
        var product = await _mediator.Send(new GetProductByIdQuery(id));
        if (product == null)
        {
            return NotFound();
        }

        // await _service.DeleteProduct(id);
        await _mediator.Send(new DeleteProductCommand(id));
        return NoContent();
    }
    #endregion

}
