using ChairEcommerce.Models;
using ChairEcommerce.Service.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace ChairEcommerce.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _categoryRepository.GetAllAsync());
        }
        public async Task<IActionResult> Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Category category)
        {
            await _categoryRepository.AddAsync(category);
            return RedirectToAction("index");
        }


        public async Task<IActionResult> Update(int id)
        {

            return View(await _categoryRepository.GetByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Update(Category category)
        {
            await _categoryRepository.UpdateAsync(category);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _categoryRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }

    }
}
