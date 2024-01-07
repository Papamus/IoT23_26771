using Microsoft.AspNetCore.Mvc;
using FromBodyAttribute = Microsoft.AspNetCore.Mvc.FromBodyAttribute;
using Microsoft.Extensions.Logging;
using CdvAzure.Functions;
using Lab3.Database.Entities;

namespace lab3.AddressesFn
{
    [ApiController]
    [Route("address")]
    public class AddressController : ControllerBase
    {
        private readonly ILogger<AddressController> logger;
        private readonly IAddressesService addressesService;
        public AddressController(ILogger<AddressController> logger, IAddressesService addressesService){
            this.logger = logger;
            this.addressesService = addressesService;
        }
        [HttpGet]
        public IEnumerable<Address> GetAddresses(){
            return addressesService.GetAddresses();
        }
        [HttpPost]
        public Address AddAddress([FromBody] Address address){
            return addressesService.AddAddress(address);
        }
        [HttpGet("{id}")]
        public Address FindAddress([FromRoute] int id){
            return addressesService.FindAddress(id);
        }
    }


}