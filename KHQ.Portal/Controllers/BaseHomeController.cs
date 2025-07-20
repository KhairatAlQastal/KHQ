using KHQ.Domain.Entities;
using KHQ.Domain.ViewModel;
using KHQ.Srv.Services;
using Microsoft.AspNetCore.Mvc;

namespace KHQ.Portal.Controllers
{
    public class BaseHomeController : Controller
    {
        private readonly IBaseHomeService _BaseHomeService;

        public BaseHomeController(IBaseHomeService baseHomeService)
        {
            _BaseHomeService = baseHomeService;
        }
        public async Task<IActionResult> Index()
        {
            //var baseHomeData = await _BaseHomeService.GetAllAsync();
            return View();
        }

        public async Task<IActionResult> GetById(Guid id)
        {
            var baseHomeData = await _BaseHomeService.GetByIdAsync(id);
            return View(baseHomeData);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] BaseHomeVM baseHome)
        {
            var baseHomeData = await _BaseHomeService.AddAsync(baseHome);
            if (baseHomeData > 0)
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
        public async Task<IActionResult> Update([FromBody] BaseHomeVM baseHome)
        {
            var baseHomeData = await _BaseHomeService.UpdateAsync(baseHome);
            if (baseHomeData > 0)
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
            var baseHomeData = await _BaseHomeService.DeleteAsync(id);
            if (baseHomeData > 0)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetSectionData(string sectionType)
        {
            try
            {
                var data = await _BaseHomeService.GetSectionDataAsync(sectionType);
                if (data != null)
                {
                    return Json(new { exists = true, data });
                }
                return Json(new { exists = false });
            }
            catch (Exception ex)
            {
                return Json(new { exists = false, error = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> SaveSection(SaveSectionRequest request)
        {
            try
            {
                var result = await _BaseHomeService.SaveSectionAsync(request);
                if (result > 0)
                {
                    return Json(new { success = true });
                }
                return Json(new { success = false, message = "Failed to save section" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}
