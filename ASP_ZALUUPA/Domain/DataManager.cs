using ASP_ZALUUPA.Domain.Repositories.Abstract;

namespace ASP_ZALUUPA.Domain
{
    public class DataManager
    {
        public IServiceCategoriesRepository ServiceCategories { get; set; }
        public IServicesRepository Services { get; set; }
        public IServicePhotoRepository ServicePhotos { get; set; }

        public DataManager(
            IServiceCategoriesRepository serviceCategoriesRepository,
            IServicesRepository servicesRepository,
            IServicePhotoRepository servicePhotosRepository)
        {
            ServiceCategories = serviceCategoriesRepository;
            Services = servicesRepository;
            ServicePhotos = servicePhotosRepository;
        }
    }
}
