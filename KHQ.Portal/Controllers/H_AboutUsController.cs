﻿using KHQ.Domain.Entities;
using KHQ.Domain.ViewModel;
using KHQ.Srv.Services;
using Microsoft.AspNetCore.Mvc;

namespace KHQ.Portal.Controllers
{
    public class H_AboutUsController : Controller
    {
        private readonly IH_AboutUsService _H_AboutUsService;

        public H_AboutUsController(IH_AboutUsService h_AboutUsService)
        {
            _H_AboutUsService = h_AboutUsService;
        }
        public async Task<IActionResult> Index()
        {
            var h_AboutUsData = await _H_AboutUsService.GetAllAsync();
            return View(h_AboutUsData);
        }

        public async Task<IActionResult> GetById(Guid id)
        {
            var h_AboutUsData = await _H_AboutUsService.GetByIdAsync(id);
            return View(h_AboutUsData);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] H_AboutUsVM h_AboutUsVM)
        {
            var result = await _H_AboutUsService.AddAsync(h_AboutUsVM);
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
        public async Task<IActionResult> Update([FromBody] H_AboutUsVM h_AboutUsVM)
        {
            var result = await _H_AboutUsService.UpdateAsync(h_AboutUsVM);
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
            var result = await _H_AboutUsService.DeleteAsync(id);
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
