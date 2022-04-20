using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace miniprojekt2022.Shared.Models
{
	public class ShelterItem
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string ObjectIdShelter { get; set; }

		[Required]
		[BsonElement("navn")]
		public string ShelterNavn { get; set; }

		
		[BsonElement("lang_beskr")]
		public string? Beskrivelse { get; set; }
	
		[Required]
		[BsonElement("antal_pl")]
		public int AntalPersoner { get; set; }


		public ShelterItem(string shelterNavn ="", string? beskrivelse = "", int antalPersoner = -1)
		{
			this.ShelterNavn = shelterNavn;
			this.Beskrivelse = beskrivelse;
			this.AntalPersoner = antalPersoner;
		}
	}
}

