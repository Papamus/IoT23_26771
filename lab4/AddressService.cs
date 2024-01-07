namespace CdvAzure.Functions
{
    public class AddressService
    {
        private List<Address> addresses {get;} = new List<Address>();
        public Address Add(string city, string addressLine)
        {
            var address = new Address
            {
                City = city,
                AddressLine =  addressLine,
                Id = addresses.Count + 1
            };

            addresses.Add(address);
            return address;
        }

        public Address Update(int id, string city, string addressLine)
        {   
            var address = addresses.First(w => w.Id == id);
            address.City = city;
            address.AddressLine = addressLine;

            return address;
        }

        public void Delete(int id)
        {
            var address = addresses.First(w => w.Id == id);
            addresses.Remove(address);
        }


        public Address Find(int id)
        {
            return addresses.First(w => w.Id == id);
        }

        public IEnumerable<Address> Get()
        {
            return addresses;
        }
    }

    public class Address
    {
        public int Id {get; set;}
        public string City {get; set;}
        public string AddressLine {get; set;}
    }
}


