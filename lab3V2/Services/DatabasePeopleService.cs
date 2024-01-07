using CdvAzure.Functions;
using lab3;
using Lab3.Database;
using Lab3.Database.Entities;

public class DatabasePeopleService : IPeopleService
{
    private readonly PeopleDB db;

    public DatabasePeopleService(PeopleDB db)
    {
        this.db = db;
    }

    public Person AddPerson(Person person)
    {
        var entity = new PersonEntity
        {
            FirstName = person.FirstName,
            LastName = person.LastName
        };
        db.People.Add(entity);
        db.SaveChanges();
        person.Id = entity.Id;
        return person;
    }


    public IEnumerable<Person> GetPeople()
    {
        var peopleList = db.People.Select(s=> new Person
        {
            FirstName = s.FirstName,
            Id = s.Id,
            LastName = s.LastName
        });

        return peopleList;
    }

     public Person MapToDTO(PersonEntity entity)
     {
        return new Person
        {
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Id = entity.Id
        };
    }
    Person IPeopleService.FindPerson(int id)
    {
       var person = db.People.First(w => w.Id == id);
       return MapToDTO(person);
    }
}