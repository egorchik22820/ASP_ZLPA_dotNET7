using Microsoft.AspNetCore.Mvc;
using ASP_ZALUUPA.Domain.Entities;
using System.IO;

namespace ASP_ZALUUPA.Controllers.Admin
{
    public partial class AdminController
    {
        public async Task<IActionResult> ServicesEdit(int id)
        {
            if (_dataManager == null)
                return RedirectToAction("Index");

            Service? entity = id == 0
                ? new Service()
                : await _dataManager.Services.GetServiceByIdAsync(id);

            if (entity == null)
                return RedirectToAction("Index");

            ViewBag.ServiceCategories = await _dataManager.ServiceCategories.GetServiceCategoriesAsync();
            return View(entity);
        }

        [HttpPost]
        public async Task<IActionResult> ServicesEdit(Service entity, IFormFile? titleImageFile)
        {
            if (_dataManager == null || !ModelState.IsValid)
            {
                ViewBag.ServiceCategories = await _dataManager!.ServiceCategories.GetServiceCategoriesAsync();
                return View(entity);
            }

            try
            {
                if (titleImageFile != null)
                {
                    // Сохраняем в файловую систему
                    entity.Photo = titleImageFile.FileName;
                    await SaveImg(titleImageFile);

                    // Сохраняем в БД
                    using var memoryStream = new MemoryStream();
                    await titleImageFile.CopyToAsync(memoryStream);
                    byte[] imageData = memoryStream.ToArray();

                    // Удаляем старое фото если есть
                    if (entity.ServicePhotoId.HasValue)
                    {
                        await _dataManager.Services.DeleteServicePhotoAsync(entity.ServicePhotoId.Value);
                    }

                    var photoEntity = new ServicePhoto
                    {
                        FileName = titleImageFile.FileName,
                        Data = imageData
                    };

                    // Сохраняем новое фото и получаем его ID
                    await _dataManager.Services.SaveServicePhotoAsync(photoEntity);
                    entity.ServicePhotoId = photoEntity.Id;
                }

                await _dataManager.Services.SaveServiceAsync(entity);
                _logger.LogInformation($"Добавлена/обновлена услуга с ID {entity.Id}");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при сохранении услуги");
                ViewBag.ServiceCategories = await _dataManager.ServiceCategories.GetServiceCategoriesAsync();
                ModelState.AddModelError("", "Произошла ошибка при сохранении");
                return View(entity);
            }
        }

        [HttpPost]
        public async Task<IActionResult> ServicesDelete(int id)
        {
            if (_dataManager == null)
                return RedirectToAction("Index");

            try
            {
                var service = await _dataManager.Services.GetServiceByIdAsync(id);
                if (service == null) return RedirectToAction("Index");

                // Удаление связанного фото из БД и файловой системы
                if (service.ServicePhotoId.HasValue)
                {
                    var photo = await _dataManager.Services.GetServicePhotoByIdAsync(service.ServicePhotoId.Value);
                    if (photo != null)
                    {
                        var path = Path.Combine(_hostingEnvironment.WebRootPath, "img", photo.FileName ?? "");
                        if (System.IO.File.Exists(path))
                        {
                            System.IO.File.Delete(path);
                        }
                        await _dataManager.Services.DeleteServicePhotoAsync(photo.Id);
                    }
                }

                await _dataManager.Services.DeleteServiceAsync(id);
                _logger.LogInformation($"Удалена услуга с ID {id}");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Ошибка при удалении услуги с ID {id}");
                return RedirectToAction("Index");
            }
        }
    }
}