using ChairEcommerce.Models;
using ChairEcommerce.Service.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ChairEcommerce.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICartRepository _cartRepository;
        private readonly UserManager<User> _userManager;
        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository,ICartRepository cartRepository, UserManager<User> userManager)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _cartRepository = cartRepository;
            _userManager = userManager;
        }
        public async Task<IActionResult> IndexAsync()
        {
            ViewBag.categories = await _categoryRepository.GetAllAsync();
            return View(await _productRepository.GetAllAsync());
        }

        [HttpGet]
        public async Task<IActionResult> CreateAsync()
        {
            ViewBag.categories = await _categoryRepository.GetAllAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            await _productRepository.AddAsync(product);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            Product product = await _productRepository.GetByIdAsync(id);
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Product product)
        {
            await _productRepository.UpdateAsync(product);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> getProductByCategoryName(string name)
        {
            List<Product> products = (List<Product>)await _productRepository.GetProductsByCatName(name);
            return View("ProductsPage",products);
        }

        public async Task<IActionResult> Delete(int id)
        {

            await _productRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> AddProductinCartAndCartItem(int productId)
        {
            var user = await _userManager.GetUserAsync(User);
            var userId = user.Id;
            await _cartRepository.AddProductAsync(userId, productId);
            return RedirectToAction("Index");
        }



    }
}
