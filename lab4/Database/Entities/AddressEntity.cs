using CdvAzure.Functions;

namespace Lab3.Database.Entities
{
    public class AddressEntity
    {
        public int AddressEntityId{get;set;}
        public string City {get; set;}
        public string AddressLine {get; set;}
        public List<PersonEntity> people {get; set;}
    }


}