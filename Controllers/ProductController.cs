using ChairEcommerce.Models;
using ChairEcommerce.Service.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace ChairEcommerce.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }
        public async Task<IActionResult> IndexAsync()
        {
            ViewBag.categories = await _categoryRepository.GetAllAsync();
            return View(await _productRepository.GetAllAsync());
        }

        [HttpGet]
        public async Task<IActionResult> CreateAsync() {
            ViewBag.categories = await _categoryRepository.GetAllAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Product product )
        {
           await _productRepository.AddAsync(product);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            Product product=await _productRepository.GetByIdAsync(id);
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Product product)
        {
            await _productRepository.UpdateAsync(product);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Delete(int id)
        {

            await _productRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }


    }
}
