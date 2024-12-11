using AutoCarParts.Models.ViewModels.ManfacturesDtos;

namespace AutoCarParts.BusinessLogic.ManufacturesService
{
    public interface IManufacturesRepo
    {
        GetManfactures AddManufactures(AddManufactures manufacture);
        List<GetManfactures> GetAllManufactures();

    }
}
