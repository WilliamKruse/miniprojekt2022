using System;
using miniprojekt2022.Shared.Models;
using System.Net.Http.Json;// loader JSON filen



namespace miniprojekt2022.Client.Services
{
    public class ShelterService : IShelterService
    {
        private readonly HttpClient httpClient;



        //Contructor laver ny client
        public ShelterService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }



        //metode der returnere alle shelters
        public Task<ShelterItem[]?> GetAllShelters()
        {
            var result = httpClient.GetFromJsonAsync<ShelterItem[]>("api/shelterbookingapi/shelter");
            return result;
        }



        //metode der returnere alle bookings
        public Task<BookingItem[]?> GetAllBookings()
        {
            var result = httpClient.GetFromJsonAsync<BookingItem[]>("api/shelterbookingapi/booking");
            return result;
        }



        //ansync metode som tilføjer en booking
        public async Task<int> AddBooking(BookingItem item)
        {
            var response = await httpClient.PostAsJsonAsync("api/shelterbookingapi", item);
            var responseStatusCode = response.StatusCode;
            return (int)responseStatusCode;
        }



        //async metode til at slette en booking via booking id -- bruges ikke
        public async Task<int> DeleteBooking(int id)
        {
            var response = await httpClient.DeleteAsync("api/shelterbookingapi/" + id);
            var responseStatusCode = response.StatusCode;
            return (int)responseStatusCode;
        }



    }
}

