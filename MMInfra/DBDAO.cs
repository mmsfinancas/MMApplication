using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;

namespace MMInfra
{
    public class DBDAO
    {
        IMongoClient client = new MongoClient("mongodb://mmadmin:ZkQ8auWMtbCi8FJq@mmsfinancas-shard-00-00-rg2tx.mongodb.net:27017,mmsfinancas-shard-00-01-rg2tx.mongodb.net:27017,mmsfinancas-shard-00-02-rg2tx.mongodb.net:27017/test?ssl=true&replicaSet=mmsfinancas-shard-0&authSource=admin&retryWrites=true&w=majority");
        public IMongoDatabase database;
        public DBDAO()
        {
            database = client.GetDatabase("mmsfinancas");
        }
    }
}
