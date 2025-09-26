using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop_API.Models.DTOs;
using Shop_API.Models.Entities;
using Shop_API.Models.Interfaces;
using System.Threading.Tasks;

namespace Shop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // 🔹 Change: inject IUnitOfWork instead of IGenericRepository<Product>
        private readonly IUnitOfWork _uow; // was _productRepo

        // 🔹 Change: constructor now takes IUnitOfWork
        public ProductController(IUnitOfWork uow)
        {
            _uow = uow; // was productRepo
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // 🔹 Change: use _uow.Products instead of _productRepo
            var products = await _uow.products.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            // 🔹 Change: use _uow.Products
            var product = await _uow.products.GetByIdAsync(id);
            if (product == null) { return NotFound(); }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDTO productDto)
        {
            var product = new Product
            {
                Name = productDto.Name,
                price = productDto.price
            };

            // 🔹 Change: use _uow.Products
            await _uow.products.AddAsync(product);

            // 🔹 Change: Save once in UoW
            await _uow.SaveAsync();

            return Ok(product); // optional: return CreatedAtAction
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductDTO productDto)
        {
            // 🔹 Change: use _uow.Products
            var existingProduct = await _uow.products.GetByIdAsync(id);
            if (existingProduct == null)
                return NotFound();

            existingProduct.Name = productDto.Name;
            existingProduct.price = productDto.price;

            // 🔹 Change: use _uow.Products
            _uow.products.Update(existingProduct);

            // 🔹 Change: Save in UoW
            await _uow.SaveAsync();

            return Ok(existingProduct);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // 🔹 Change: load product first from _uow.Products
            var product = await _uow.products.GetByIdAsync(id);
            if (product == null)
                return NotFound();

            _uow.products.DeleteAsync (id);

            // 🔹 Change: Save in UoW
            await _uow.SaveAsync();

            return Ok();
        }
    }
}
//using Microsoft.AspNetCore.Http; using Microsoft.AspNetCore.Mvc; using Shop_API.Models.DTOs; using Shop_API.Models.Entities; using Shop_API.Models.Interfaces; using System.Threading.Tasks; namespace Shop_API.Controllers { [Route("api/[controller]")][ApiController] public class ProductController : ControllerBase { private readonly IGenericRepository<Product> _productRepo; public ProductController(IGenericRepository<Product> productRepo) { _productRepo = productRepo; } [HttpGet] public async Task<IActionResult> GetAll() { var products = await _productRepo.GetAllAsync(); return Ok(products); } [HttpGet("{id}")] public async Task<IActionResult> GetById(int id) { var products = await _productRepo.GetByIdAsync(id); if (products == null) { return NotFound(); } return Ok(products); } [HttpPost] public async Task<IActionResult> Create(ProductDTO productDto) { var product = new Product { Name = productDto.Name, price = productDto.price }; await _productRepo.AddAsync(product); return Ok(); } [HttpPut("{id}")] public async Task<IActionResult> Update(int id, ProductDTO productDto) { // Load existing entity from DB var existingProduct = await _productRepo.GetByIdAsync(id); if (existingProduct == null) return NotFound(); // Map DTO to entity existingProduct.Name = productDto.Name; existingProduct.price = productDto.price; _productRepo.Update(existingProduct); return Ok(); } [HttpDelete("{id}")] public async Task <IActionResult> Delete(int id) { _productRepo.DeleteAsync(id); return Ok(); } } }