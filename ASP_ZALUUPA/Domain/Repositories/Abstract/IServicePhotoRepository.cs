using ASP_ZALUUPA.Domain.Entities;

namespace ASP_ZALUUPA.Domain.Repositories.Abstract
{
    public interface IServicePhotoRepository
    {
        Task<ServicePhoto?> GetByIdAsync(int id);
        void Create(ServicePhoto photo);
    }
}
