using Models;
using MongoDB.Driver;

namespace Persistence;
public class MainContext
{
    public MainContext()
    {
        db = null;
    }
    private IMongoDatabase Db
    {
        get
        {
            if (db == null) Load();
            return db;
        }
    }
    private void Load()
    {
        var connectionString = "mongodb://mongoadmin:LltF8Nx*yo@localhost:27017";
        var client = new MongoClient(connectionString);
        db = client.GetDatabase("dbStoreFront");
    }
    private IMongoDatabase? db { get; set; }

    public IMongoCollection<Persistence.Product> Product
    {
        get
        {
            return Db.GetCollection<Persistence.Product>("Product");
        }
    }
}