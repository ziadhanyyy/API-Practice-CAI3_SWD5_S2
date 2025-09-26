using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop_API.Models.DTOs;
using Shop_API.Models.Entities;
using Shop_API.Models.Interfaces;

namespace Shop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _uow; // ✅ Inject Unit of Work instead of repository

        // ✅ Constructor now takes IUnitOfWork
        public CategoryController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _uow.categories.GetAllAsync(); // ✅ Use UoW
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _uow.categories.GetByIdAsync(id); // ✅ Use UoW
            if (category == null)
                return NotFound();

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDTO categoryDto)
        {
            var category = new Category { Name = categoryDto.Name };

            await _uow.categories.AddAsync(category); // ✅ Add via UoW
            await _uow.SaveAsync(); // ✅ Commit changes once here

            return Ok(category); // Return created category
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CategoryDTO categoryDto)
        {
            // Load existing entity from DB
            var existingCategory = await _uow.categories.GetByIdAsync(id);
            if (existingCategory == null)
                return NotFound();

            // Map DTO to entity
            existingCategory.Name = categoryDto.Name;

            _uow.categories.Update(existingCategory); // ✅ Update via UoW
            await _uow.SaveAsync(); // ✅ Save changes

            return Ok(existingCategory);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
             _uow.categories.DeleteAsync(id); // ✅ Delete via UoW
            await _uow.SaveAsync(); // ✅ Save changes

            return Ok();
        }
    }
}

/*using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop_API.Models.DTOs;
using Shop_API.Models.Entities;
using Shop_API.Models.Interfaces;

namespace Shop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IGenericRepository<Category> _categotyRepo;
        public CategoryController(IGenericRepository<Category> categoryRepo)
        {
            _categotyRepo = categoryRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()

        {
            var categoris = await _categotyRepo.GetAllAsync();
            return Ok(categoris);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)

        {
            var categoris = await _categotyRepo.GetByIdAsync(id);
            if (categoris == null) { return NotFound(); }
            return Ok(categoris);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryDTO categorisDto)
        {
            var categoris=new Category { Name = categorisDto.Name };
            await _categotyRepo.AddAsync(categoris);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CategoryDTO productDto)
        {

            // Load existing entity from DB
            var existingProduct = await _categotyRepo.GetByIdAsync(id);
            if (existingProduct == null)
                return NotFound();

            // Map DTO to entity
            existingProduct.Name = productDto.Name;

            _categotyRepo.Update(existingProduct);
            

            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _categotyRepo.DeleteAsync(id);
            
            return Ok();
        }

    }

}
*/