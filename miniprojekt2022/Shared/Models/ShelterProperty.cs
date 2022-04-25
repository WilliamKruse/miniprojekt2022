using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace miniprojekt2022.Shared.Models
{
	//deseralizering
	[BsonIgnoreExtraElements]
	public class ShelterProperty
	{
		
		[BsonElement("navn")]
		public string? PropShelterNavn { get; set; }

		[BsonElement("lang_beskr")]
		public string? PropBeskrivelse { get; set; }

		[Required]
		[BsonElement("antal_pl")]
		public int PropAntalPersoner { get; set; }

	}
}

