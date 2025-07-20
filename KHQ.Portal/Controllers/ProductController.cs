using KHQ.Domain.ViewModel;
using KHQ.Srv.Services;
using Microsoft.AspNetCore.Mvc;

namespace KHQ.Portal.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductSrv _ProductSrv;

        public ProductController(IProductSrv productSrv)
        {
            _ProductSrv = productSrv;
        }
        public async Task<IActionResult> Index()
        {
            var productData = await _ProductSrv.GetAllAsync();
            return View(productData);
        }

        public async Task<IActionResult> GetById(Guid id)
        {
            var productData = await _ProductSrv.GetByIdAsync(id);
            return View(productData);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ProductVM productVM)
        {
            var result = await _ProductSrv.AddAsync(productVM);
            if (result > 0)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] ProductVM productVM)
        {
            var result = await _ProductSrv.UpdateAsync(productVM);
            if (result > 0)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return BadRequest();
            }
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _ProductSrv.DeleteAsync(id);
            if (result > 0)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
