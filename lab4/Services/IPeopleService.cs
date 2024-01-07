using CdvAzure.Functions;
using Lab3.Database.Entities;

namespace lab3
{
    public interface IPeopleService
    {
        Person FindPerson(int id);

        IEnumerable<Person> GetPeople();

        Person AddPerson(Person person);
    }
}
