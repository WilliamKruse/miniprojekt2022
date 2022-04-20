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
        public ShelterController(IShelterRepository shelterRepository)
        {
            if (Repository == null && shelterRepository != null)
            {
                Repository = shelterRepository;
                Console.WriteLine("Repository initialized");
            }
        }

        [HttpGet]
        public IEnumerable<ShelterItem> GetAllShelters()
        {
            return Repository.GetAllShelters();
        }

        [HttpGet]
        public IEnumerable<BookingItem> GetAllBookings()
        {
            return Repository.GetAllBookings();
        }

        [HttpPost]
        public void AddBooking(BookingItem item)
        {
            Console.WriteLine("Add item called: " + item.ToString());
            Repository.AddBooking(item);
        }

        [HttpDelete("{id:string}")]
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
