using ASP_ZALUUPA.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASP_ZALUUPA.Domain.Repositories.Abstract
{
    public interface IServicesRepository
    {
        // Методы для работы с услугами (Service)
        Task<IEnumerable<Service>> GetServicesAsync();
        Task<Service?> GetServiceByIdAsync(int id);
        Task SaveServiceAsync(Service entity);
        Task DeleteServiceAsync(int id);

        // Методы для работы с фотографиями услуг (ServicePhoto)
        Task<ServicePhoto?> GetServicePhotoByIdAsync(int id);
        Task<int> SaveServicePhotoAsync(ServicePhoto photo);
        Task DeleteServicePhotoAsync(int id);
    }
}