using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using miniprojekt2022.Server.Models;
using miniprojekt2022.Shared.Models;


namespace miniprojekt2022.Server.Controllers
{
    [ApiController]
    [Route("api/shelterbookingapi")]

    public class ShelterController : ControllerBase
    {
        private readonly IShelterRepository Repository = new ShelterRepositoryMongo();

        //contructor tjekker om repository er tom og hvis den er, laves et nyt repository 
        public ShelterController(IShelterRepository shelterRepository)
        {
            if (Repository == null && shelterRepository != null)
            {
                Repository = shelterRepository;
                Console.WriteLine("Repository initialized");
            }
        }

        //implementer get metoden
        [HttpGet]
        //returner alle shelters fra databasen
        public IEnumerable<ShelterItem> GetAllShelters()
        {
            return Repository.GetAllShelters();
        }

        //implementer get metoden
        [HttpGet]
        //returner alle bookinger fra databasen
        public IEnumerable<BookingItem> GetAllBookings()
        {
            return Repository.GetAllBookings();
        }

        //implementer post metoden 
        [HttpPost]
        //tilføjer en ny booking til repository 
        public void AddBooking(BookingItem item)
        {
            Console.WriteLine("Add item called: " + item.ToString());
            Repository.AddBooking(item);
        }

        [HttpDelete("{id:string}")]
        //metode der sletter en booking - returner en status kode
        public StatusCodeResult DeleteBooking(string id)
        {
            Console.WriteLine("Server: Delete item called: id = " + id);

            bool deleted = Repository.DeleteBooking(id);
            if (deleted)
            {
                Console.WriteLine("Server: Item deleted succces");
                int code = (int)HttpStatusCode.OK;
                return new StatusCodeResult(code);
            }
            else
            {
                Console.WriteLine("Server: Item deleted fail - not found");
                int code = (int)HttpStatusCode.NotFound;
                return new StatusCodeResult(code);
            }
        }

    }
}

