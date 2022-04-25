using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.Driver;



namespace miniprojekt2022.Shared.Models
{
    //deseralizering - Databasen har fields vi skal ignorere
    [BsonIgnoreExtraElements]
    public class ShelterItem
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ObjectIdShelter { get; set; }

        //Seralizering - binder objektet "properties" fra mongo til klassen "ShelterProperty"
        [BsonElement("properties")]
        public ShelterProperty property { get; set; }

        //Tom contructor - Mongo bruger kun tomme
        public ShelterItem()
        {
           
        }

    }

}

