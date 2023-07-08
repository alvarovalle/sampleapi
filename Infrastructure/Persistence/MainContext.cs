namespace Infrastructure.Persistence;
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
        var connectionString = "mongodb://mongoadmin:VodkaRussa1974@localhost:27017";
        var client = new MongoClient(connectionString);
        db = client.GetDatabase("dbStoreFront");
    }
    private IMongoDatabase? db { get; set; }

    public IMongoCollection<Persistence.Product.Product> Product
    {
        get
        {
            return Db.GetCollection<Persistence.Product.Product>("Product");
        }
    }
}