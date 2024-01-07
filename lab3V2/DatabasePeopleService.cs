using CdvAzure.Functions;
using Lab3.Database;
using Lab3.Database.Entities;

public class DatabasePeopleService : PeopleService
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




}