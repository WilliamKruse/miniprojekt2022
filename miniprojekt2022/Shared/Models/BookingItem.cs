using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace miniprojekt2022.Shared.Models
{
	public class BookingItem
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string? ObjectIdBooking { get; set; }

		[Required]
		[BsonElement("kunde_navn")]
		[StringLength(40,ErrorMessage = "Det navn er for langt")]
		public string KundeNavn { get; set; }

		[Required]
		[DataType(DataType.EmailAddress)]
		[EmailAddress]
		[BsonElement("email")]
		public string Email { get; set; }

		[Required]
		[StringLength(8,MinimumLength = 8, ErrorMessage = "skriv dit 8-cifrede telefonnummer tak")]
		[BsonElement("telefon")]
		public string Telefon { get; set; }

		[Required]
		[BsonElement("shelter_id")]
		public string ShelterId { get; set; }

		[Required]

		[BsonElement("start_dato")]
		public DateTime? StartDato { get; set; }


		[BsonElement("slut_dato")]
		public DateTime? SlutDato { get; set; }

		public BookingItem()
        {
			
        }

		public BookingItem(string kundeNavn = "", string email = "", string telefon = "", string shelterId = "", DateTime startDato = new DateTime(), DateTime slutDato = new DateTime())
		{
			this.KundeNavn = kundeNavn;
			this.Email = email;
			this.Telefon = telefon;
			this.ShelterId = shelterId;
			this.StartDato = startDato;
			this.SlutDato = slutDato;
		}
	}
}

