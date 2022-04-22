using System;
using miniprojekt2022.Shared.Models;



namespace miniprojekt2022.Client.Services
{
    public interface IShelterService
    {
        //GRUD operationer

        //READ
        Task<ShelterItem[]?> GetAllShelters();

        //READ
        Task<BookingItem[]?> GetAllBookings();

        //CREATE
        Task<int> AddBooking(BookingItem item);

        //DELETE
        Task<int> DeleteBooking(int id);
    }
}
