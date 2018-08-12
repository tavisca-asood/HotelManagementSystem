using System;
using System.Linq;
using Xunit;
using HotelManagementSystem.Models;
using System.Collections.Generic;
using FluentAssertions;

namespace HotelManagementSystem.Tests
{
    public class HotelManagementSystemTests
    {
        [Fact]
        public void GetHotelById()
        {
            List<Hotel> hotels = HotelsApiCaller.AddHotel(new Hotel()
            {
                Name = "Hyatt Regency",
                Address = "Viman Nagar, Pune",
                Id = 100,
                LocationCode = "PNQ"
            });
            Hotel hotel = hotels.Find(h => h.Id == 100 && h.Name == "Hyatt Regency");
            hotel.Should().NotBeNull("The added hotel was not found in the list");
        }

        [Fact]
        public void GetListOfAllHotelsAdded()
        {
            List<Hotel> hotelsToAdd = new List<Hotel>()
            {
                new Hotel()
                {
                    Name="The Taj Mahal Hotel",
                    Address="Man Singh Road, New Delhi",
                    Id=101,
                    LocationCode="DEL"
                },
                new Hotel()
                {
                    Name="The Oberoi",
                    Address="Nariman Point, Mumbai",
                    Id=102,
                    LocationCode="BOM"
                },
                new Hotel()
                {
                    Name="JW Marriott Hotel",
                    Address="Sector 35, Chandigarh",
                    Id=103,
                    LocationCode="IXC"
                }
            };
            List<Hotel> hotels = new List<Hotel>();
            foreach(Hotel hotel in hotelsToAdd)
            {
                hotels = HotelsApiCaller.AddHotel(hotel);
            }
            Hotel Delhi = hotels.Find(h => h.Id == 101 && h.Name == "The Taj Mahal Hotel");
            Hotel Mumbai = hotels.Find(h => h.Id == 102 && h.Name == "The Oberoi");
            Hotel Chandigarh = hotels.Find(h => h.Id == 103 && h.Name == "JW Marriott Hotel");
            Delhi.Should().NotBeNull("The Taj Mahal Hotel was not found in the list");
            Mumbai.Should().NotBeNull("The Oberoi was not found in the list");
            Chandigarh.Should().NotBeNull("JW Marriott Hotel was not found in the list");
        }

    }
}
