using CdvAzure.Functions;
using lab3;
using Lab3.Database;
using Lab3.Database.Entities;

public class DatabaseAddressService: IAddressesService
{
    private readonly PeopleDB db;

    public DatabaseAddressService(PeopleDB db)
    {
        this.db = db;
    }

    public Address AddAddress(Address address)
    {
        var entity = new AddressEntity
        {
            City = address.City,
            AddressLine = address.AddressLine
        };
        db.Address.Add(entity);
        db.SaveChanges();
        address.Id = entity.AddressEntityId;
        return address;
    }


    public IEnumerable<Address> GetAddresses()
    {
        var addressesList = db.Address.Select(s=> new Address
        {
            Id = s.AddressEntityId,
            City = s.City,
            AddressLine = s.AddressLine
        });

        return addressesList;
    }

     public Address MapToDTO(AddressEntity entity)
     {
        return new Address
        {
            City = entity.City,
            AddressLine = entity.AddressLine,
            Id = entity.AddressEntityId
        };
    }
    Address IAddressesService.FindAddress(int id)
    {
       var address = db.Address.First(w => w.AddressEntityId == id);
       return MapToDTO(address);
    }
}