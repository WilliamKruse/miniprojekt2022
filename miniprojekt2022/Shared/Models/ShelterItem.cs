using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.Driver;

namespace miniprojekt2022.Shared.Models
{
	
	[BsonIgnoreExtraElements]
	public class ShelterItem
	{

		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string ObjectIdShelter { get; set; }

		
		public string? ShelterNavn { get { return property.PropShelterNavn; } set { ShelterNavn = value; } } 

		public string? Beskrivelse { get { return property.PropBeskrivelse; } set { Beskrivelse = value; } }
	
		public int AntalPersoner { get { return property.PropAntalPersoner; } set {AntalPersoner=value; } }

		[BsonElement("properties")]
		public ShelterProperty property;


		public ShelterItem(string shelterNavn ="hej", string? beskrivelse = "", int antalPersoner = -1)
		{
			this.ShelterNavn = shelterNavn;
			this.Beskrivelse = beskrivelse;
			this.AntalPersoner = antalPersoner;
		}
	
	}
	
}

