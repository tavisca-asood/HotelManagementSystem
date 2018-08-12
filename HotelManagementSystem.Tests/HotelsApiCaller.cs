using HotelManagementSystem.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;



namespace HotelManagementSystem.Tests
{
    public static class HotelsApiCaller
    {
        private static RestClient client = new RestClient("http://localhost:52475/api");
        public static List<Hotel> AddHotel(Hotel hotel)
        {
           var request = new RestRequest("Hotel", Method.POST);
            string json = JsonConvert.SerializeObject(hotel);
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            if (content.Contains("ID already exists"))
                return null;
            return JsonConvert.DeserializeObject<List<Hotel>>(content);
        }

        public static List<Hotel> GetAllHotels()
        {
            var getRequest = new RestRequest("Hotel", Method.GET);
            IRestResponse response = client.Execute(getRequest);
            var content = response.Content;
            return JsonConvert.DeserializeObject<List<Hotel>>(content);
        }

        public static Hotel GetHotelById(int id)
        {
            try
            {
                var getRequest = new RestRequest(string.Format("Hotel/{0}",id), Method.GET);
                IRestResponse response = client.Execute(getRequest);
                var content = response.Content;
                return JsonConvert.DeserializeObject<Hotel>(content);
            }
            catch(Exception exc)
            {
                return null;
            }
        }
    }
}
