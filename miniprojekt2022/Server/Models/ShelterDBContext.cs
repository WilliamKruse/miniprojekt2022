using System;
using MongoDB.Driver;
using miniprojekt2022.Shared.Models; 

namespace miniprojekt2022.Server.Models
{
    public class ShelterDBContext
    {
        //readonly interace til databasen
        private readonly IMongoDatabase mongoDatabase;

        //tilkobler databasen
        public ShelterDBContext()
        {
            var client = new MongoClient("mongodb+srv://enghlan:hverguderne@sheltercluster.hlhhm.mongodb.net/test");
            mongoDatabase = client.GetDatabase("miniprojekt2022");
        }

        //vælger collection inde fra databasen - alleshelters
        public IMongoCollection<ShelterItem> Items
        {
            get
            {
                return mongoDatabase.GetCollection<ShelterItem>("alleshelters"); 
            }
        }



    }
}
