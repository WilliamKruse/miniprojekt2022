using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using miniprojekt2022.Shared.Models;
using MongoDB.Driver;
using MongoDB.Bson;

namespace miniprojekt2022.Server.Models
{
    //definere klasse som implementer interfacet
    public class ShelterRepositoryMongo : IShelterRepository
    {
        //brugen Context klassen som er forbundet til databasen
        ShelterDBContext db = new ShelterDBContext();

        //metode der finder og returner alle shelters i en liste 
        public List<ShelterItem> GetAllShelters()
        {
            return db.alleshelters.Find(_=>true).ToList();
        }

        //metode der finder og returner alle bookinger i en liste 
        public List<BookingItem> GetAllBookings()
        {
            return db.booking.Find(_ => true).ToList();
        }

        //void metode tilføjer booking til databasen
        public void AddBooking(BookingItem item)
        {
            db.booking.InsertOne(item);
        }

        //bool metode som sletter en booking via booking id
        public bool DeleteBooking(string id)
        {
            FilterDefinition<BookingItem> item = Builders<BookingItem>.Filter.Eq("_id", id);
            var deleteItem = db.booking.FindOneAndDelete(item);
            if (deleteItem != null)
                return true;
            else
                return false;
        }
    }

}

