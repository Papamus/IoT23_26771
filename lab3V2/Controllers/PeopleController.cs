using Microsoft.AspNetCore.Mvc;
using FromBodyAttribute = Microsoft.AspNetCore.Mvc.FromBodyAttribute;
using Microsoft.Extensions.Logging;
using CdvAzure.Functions;
using Lab3.Database.Entities;
using lab3;


namespace Lab3.PeopleFn
{
    [ApiController]
    [Route("person")]
    public class PeopleController : ControllerBase
    {
        private readonly ILogger<PeopleController> logger;
        private readonly IPeopleService peopleService;
        public PeopleController(ILogger<PeopleController> logger, IPeopleService peopleService){
            this.logger = logger;
            this.peopleService = peopleService;
        }
        [HttpGet]
        public IEnumerable<Person> GetPeople(){
            return peopleService.GetPeople();
        }
        [HttpPost]
        public Person AddPerson([FromBody] Person person){
            return peopleService.AddPerson(person);
        }
        [HttpGet("{id}")]
        public Person FindPerson([FromRoute] int id){
            return peopleService.FindPerson(id);
        }
    }



}