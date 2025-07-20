using KHQ.Domain.ViewModel;
using KHQ.Srv.Services;
using Microsoft.AspNetCore.Mvc;

namespace KHQ.Portal.Controllers
{
    public class SubProductController : Controller
    {
        private readonly ISubProductSrv _SubProductSrv;

        public SubProductController(ISubProductSrv subProductSrv)
        {
            _SubProductSrv = subProductSrv;
        }
        public async Task<IActionResult> Index()
        {
            var subProductData = await _SubProductSrv.GetAllAsync();
            return View(subProductData);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var subProductData = await _SubProductSrv.GetByIdAsync(id);
            return View(subProductData);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SubProductVM subProductVM)
        {
            var result = await _SubProductSrv.AddAsync(subProductVM);
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
        public async Task<IActionResult> Update([FromBody] SubProductVM subProductVM)
        {
            var result = await _SubProductSrv.UpdateAsync(subProductVM);
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
            var result = await _SubProductSrv.DeleteAsync(id);
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
