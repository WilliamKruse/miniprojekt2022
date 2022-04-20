using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using miniprojekt2022.Shared.Models;

namespace miniprojekt2022.Server.Models
{

    //laver interfacet med metoder til klasserne
    public interface IShelterRepository
    {
        List<ShelterItem> GetAllShelters();
        List<BookingItem> GetAllBookings();

        void AddBooking(BookingItem item);

        bool DeleteBooking(string id);

    }
}
