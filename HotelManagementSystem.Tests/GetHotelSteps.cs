using HotelManagementSystem.Models;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace HotelManagementSystem.Tests
{
    [Binding]
    public class GetHotelSteps
    {
        private List<Hotel> _hotels;
        [When(@"User wants to see the list of all hotels")]
        public void WhenUserWantsToSeeTheListOfAllHotels()
        {
            _hotels = new List<Hotel>();
        }
        
        [Then(@"User sees the list of all available hotels")]
        public void ThenUserSeesTheListOfAllAvailableHotels()
        {
            _hotels = HotelsApiCaller.GetAllHotels();
        }

        [When(@"User wants to see the hotel with a particular Id")]
        public void WhenUserWantsToSeeTheHotelWithParticularId()
        {
            
        }

        [Then(@"User sees the hotel with the given Id'(.*)'")]
        public Hotel ThenUserSeesTheHotelWithTheGivenId(int id)
        {
            return HotelsApiCaller.GetHotelById(id);
        }


    }
}
