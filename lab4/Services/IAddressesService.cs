using CdvAzure.Functions;
using Lab3.Database.Entities;

namespace lab3
{
    public interface IAddressesService
    {
        Address FindAddress(int id);

        IEnumerable<Address> GetAddresses();

        Address AddAddress(Address address);
    }
}