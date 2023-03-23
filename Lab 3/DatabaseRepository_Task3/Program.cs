DatabaseRepository databaseRepository = DatabaseRepository.Initialize();
Console.WriteLine(databaseRepository.GetHashCode());
DatabaseRepository databaseRepository2 = DatabaseRepository.Initialize();
Console.WriteLine(databaseRepository2.GetHashCode());
Console.ReadKey();
class DatabaseRepository
{
    private static DatabaseRepository dbRep = null;

    protected DatabaseRepository()
    {
    }
    public static DatabaseRepository Initialize()
    {
        if (dbRep == null)
            dbRep = new DatabaseRepository();
        return dbRep;
    }
}