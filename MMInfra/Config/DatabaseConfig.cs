using MongoDB.Driver;

namespace MMInfra.Config
{
    public class DatabaseConfig<Model> where Model : class
    {
        private IMongoClient Client { get; set; }
        private IMongoDatabase Database { get; set; }
        public IMongoCollection<Model> Collection { get; set; }

        public DatabaseConfig()
        {
            Client = new MongoClient("mongodb://mmadmin:ZkQ8auWMtbCi8FJq@mmsfinancas-shard-00-00-rg2tx.mongodb.net:27017,mmsfinancas-shard-00-01-rg2tx.mongodb.net:27017,mmsfinancas-shard-00-02-rg2tx.mongodb.net:27017/test?ssl=true&replicaSet=mmsfinancas-shard-0&authSource=admin&retryWrites=true&w=majority");
            Database = Client.GetDatabase("mmsfinancas");
        }

        public void setCollection(string CollectionName)
        {
            Collection = Database.GetCollection<Model>(CollectionName);
        }

        public void Insert(Model model)
        {
            Collection.InsertOne(model);
        }
    }
}
