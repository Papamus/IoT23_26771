using CdvAzure.Functions;
using Lab3.Database;

public class DatabasePeopleService : PeopleService
{
    private readonly PeopleDB db;

    public DatabasePeopleService(PeopleDB db)
    {
        this.db = db;
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