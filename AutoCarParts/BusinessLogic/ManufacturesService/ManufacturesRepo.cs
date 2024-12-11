using AutoCarParts.Models;
using AutoCarParts.Models.ViewModels.ManfacturesDtos;

namespace AutoCarParts.BusinessLogic.ManufacturesService
{
    public class ManufacturesRepo:IManufacturesRepo
    {
        private readonly AppDbContext Context;
        public ManufacturesRepo(AppDbContext _context)
        {
            Context = _context;
        }

        public GetManfactures AddManufactures(AddManufactures manufacture)
        {
            Manufacturer manufacturer2Add=new Manufacturer();   
            manufacturer2Add.Address = manufacture.Address;
            manufacturer2Add.ContactNumber = manufacture.ContactNumber;
            manufacturer2Add.Name = manufacture.Name;
            Context.Add(manufacturer2Add);
            Context.SaveChanges();
            return new GetManfactures { Id=manufacturer2Add.ManufacturerId,Name=manufacturer2Add.Name,Address=manufacturer2Add.Address,ContactNumber=manufacturer2Add.ContactNumber};
        }

        public List<GetManfactures> GetAllManufactures()
        {
            var r =Context.manufacturers.Select(r => new GetManfactures { Id = r.ManufacturerId, Name = r.Name, Address = r.Address, ContactNumber = r.ContactNumber }).ToList();
            return r;
        }
    }
}
