using System.Net.Sockets;

namespace Lab3.Database.Entities{
    public class PersonEntity{
        public int Id{get;set;}
        public string FirstName{get;set;}
        public string LastName{get;set;}
        public AddressEntity address{get;set;}
        public int AddressEntityId{get;set;}

    }
}