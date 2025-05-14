using Microsoft.AspNetCore.Mvc;
using ASP_ZALUUPA.Domain.Entities;
using System.Text.Json;

namespace ASP_ZALUUPA.Controllers.Admin
{
    public partial class AdminController
    {
        public async Task<IActionResult> ServicesEdit(int id)
        {
            Service? entity = id == 0
                ? new Service()
                : await _dataManager!.Services.GetServiceByIdAsync(id);

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
                // сохраняем в файловую систему
                entity.Photo = titleImageFile.FileName;
                await SaveImg(titleImageFile);

                // сохраняем в БД
                using var memoryStream = new MemoryStream();
                await titleImageFile.CopyToAsync(memoryStream);
                byte[] imageData = memoryStream.ToArray();

                var photoEntity = new ServicePhoto
                {
                    FileName = titleImageFile.FileName,
                    Data = imageData,
                    ServiceId = entity.Id
                };

                await _dataManager!.Services.SaveServicePhotoAsync(photoEntity);
            }

            await _dataManager!.Services.SaveServiceAsync(entity);
            _logger.LogInformation($"добавлена/обновлена услуга с ID {entity.Id}");
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ServicesDelete(int id)
        {
            var service = await _dataManager!.Services.GetServiceByIdAsync(id);
            if (service == null) return RedirectToAction("Index");

            // Удаление связанных фотографий из БД и файловой системы
            var photos = await _dataManager.Services.GetServicePhotosByServiceIdAsync(id);
            foreach (var photo in photos)
            {
                var path = Path.Combine(_hostingEnvironment.WebRootPath, "img", photo.FileName ?? "");
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }

                await _dataManager.Services.DeleteServicePhotoAsync(photo.Id);
            }

            await _dataManager.Services.DeleteServiceAsync(id);
            _logger.LogInformation($"удалена услуга с ID {id}");
            return RedirectToAction("Index");
        }
    }
}
