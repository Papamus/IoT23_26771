using System.Net;
using System.Text.Json;
using CdvAzure.Functions;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace lab4.cdv
{
    public class Addressfn
    {
        private readonly ILogger _logger;

        private readonly DatabaseAddressService addressService;

        public Addressfn(ILoggerFactory loggerFactory, DatabaseAddressService addressService)
        {
            _logger = loggerFactory.CreateLogger<Addressfn>();
            this.addressService = addressService;
        }

        [Function("Addressfn")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", "delete", "put")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
        
             switch  (req.Method){
                case "POST":
                    StreamReader reader = new StreamReader(req.Body, System.Text.Encoding.UTF8);
                    var json = reader.ReadToEnd();
                    var address = JsonSerializer.Deserialize<Address>(json);
                    var res =  addressService.AddAddress(address);
                    response.WriteAsJsonAsync(res);
                    break;
                case "PUT":
                    StreamReader putReader = new StreamReader(req.Body, System.Text.Encoding.UTF8);
                    var putJson = putReader.ReadToEnd();
                    var updatedAddress = JsonSerializer.Deserialize<Address>(putJson);
                    // var updated = addressService.Update(updatedAddress.Id, updatedAddress.City, updatedAddress.AddressLine);
                    // response.WriteAsJsonAsync(updated);
                    break;
                case "GET":
                    var getaddress = addressService.GetAddresses();
                    response.WriteAsJsonAsync(getaddress);
                    break;
                case "DELETE":
                    StreamReader deleteReader = new StreamReader(req.Body, System.Text.Encoding.UTF8);
                    var deleteJson = deleteReader.ReadToEnd();
                    var addressToDelete = JsonSerializer.Deserialize<Address>(deleteJson);
                    // addressService.Delete(addressToDelete.Id);
                    // response.WriteString("Address deleted successfully");
                    break;    
            }


            return response;
        }
    }
}
