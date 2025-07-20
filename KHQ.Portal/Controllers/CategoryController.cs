using KHQ.Domain.Entities;
using KHQ.Domain.ViewModel;
using KHQ.Srv.Services;
using Microsoft.AspNetCore.Mvc;

namespace KHQ.Portal.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategorySrv _CategorySrv;

        public CategoryController(ICategorySrv categorySrv)
        {
            _CategorySrv = categorySrv;
        }
        public async Task<IActionResult> Index()
        {
            var categoryData = await _CategorySrv.GetAllAsync();
            return View(categoryData);
        }

        public async Task<IActionResult> GetById(Guid id)
        {
            var categoryData = await _CategorySrv.GetByIdAsync(id);
            return View(categoryData);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CategoryVM categoryVM)
        {
            var result = await _CategorySrv.AddAsync(categoryVM);
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
        public async Task<IActionResult> Update([FromBody] CategoryVM categoryVM)
        {
            var result = await _CategorySrv.UpdateAsync(categoryVM);
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
            var result = await _CategorySrv.DeleteAsync(id);
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
