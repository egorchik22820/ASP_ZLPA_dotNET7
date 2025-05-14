using ASP_ZALUUPA.Domain.Entities;
using ASP_ZALUUPA.Domain.Repositories.Abstract;

namespace ASP_ZALUUPA.Domain.Repositories.EntityFramework
{
    public class EFServicePhotoRepository : IServicePhotoRepository
    {
        private readonly AppDbContext _context;

        public EFServicePhotoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServicePhoto?> GetByIdAsync(int id) =>
            await _context.ServicePhotos.FindAsync(id);

        public void Create(ServicePhoto photo)
        {
            _context.ServicePhotos.Add(photo);
        }
    }
}
