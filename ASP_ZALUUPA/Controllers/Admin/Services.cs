﻿using Microsoft.AspNetCore.Mvc;
using ASP_ZALUUPA.Domain.Entities;

namespace ASP_ZALUUPA.Controllers.Admin
{
    public partial class AdminController
    {
        public async Task<IActionResult> ServicesEdit(int id)
        {
            Service? entity = id == 0 ? new Service() : await _dataManager!.Services.GetServiceByIdAsync(id);
            ViewBag.ServiceCategories = await _dataManager!.ServiceCategories.GetServiceCategoriesAsync();

            return View(entity);
        }

        [HttpPost]
        public async Task<IActionResult> ServicesEdit(Service entity, IFormFile? titleImageFile)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ServiceCategories = await _dataManager!.ServiceCategories.GetServiceCategoriesAsync();
                return View(entity);
            }

            if (titleImageFile != null)
            {
                entity.Photo = titleImageFile.FileName;
                await SaveImg(titleImageFile);
            }

            await _dataManager!.Services.SaveServiceAsync(entity);
            _logger.LogInformation($"добавлена/обновлена услуга с ID {entity.Id}");
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ServicesDelete(int id)
        {
            await _dataManager!.Services.DeleteServiceAsync(id);
            _logger.LogInformation($"удалена услуга с ID {id}");
            return RedirectToAction("Index");
        }
    }
}
