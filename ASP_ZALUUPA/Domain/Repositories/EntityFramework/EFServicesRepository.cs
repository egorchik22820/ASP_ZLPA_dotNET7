using ASP_ZALUUPA.Domain.Entities;
using ASP_ZALUUPA.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace ASP_ZALUUPA.Domain.Repositories.EntityFramework
{
    public class EFServicesRepository : IServicesRepository
    {
        private readonly AppDbContext _context;

        public EFServicesRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Service>> GetServicesAsync()
        {
            return await _context.Services.Include(x => x.ServiceCategory).ToListAsync();
        }

        public async Task<Service?> GetServiceByIdAsync(int id)
        {
            return await _context.Services.Include(x => x.ServiceCategory).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task SaveServiceAsync(Service entity)
        {
            _context.Entry(entity).State = entity.Id == default ? EntityState.Added : EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteServiceAsync(int id)
        {
            _context.Entry(new Service() { Id = id }).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }


        // фото

        public async Task SaveServicePhotoAsync(ServicePhoto photo)
        {
            _context.ServicePhotos.Add(photo);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ServicePhoto>> GetServicePhotosByServiceIdAsync(int serviceId)
        {
            return await _context.ServicePhotos
                                 .Where(p => p.ServiceId == serviceId)
                                 .ToListAsync();
        }

        public async Task DeleteServicePhotoAsync(int id)
        {
            var photo = await _context.ServicePhotos.FindAsync(id);
            if (photo != null)
            {
                _context.ServicePhotos.Remove(photo);
                await _context.SaveChangesAsync();
            }
        }

    }
}
