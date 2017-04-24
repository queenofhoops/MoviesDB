using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace MovieDBTesting
{
    class MovieDbProject
    {
        public string apiKey;
        //46c0d8825c69dad66e21bcb7a8cef00c
        public string apiReadAccessToken;
        //eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJhdWQiOiI0NmMwZDg4MjVjNjlkYWQ2NmUyMWJjYjdhOGNlZjAwYyIsInN1YiI6IjU4ZmQzMTU3YzNhMzY4N2EwMzAyNDI0MyIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.VSJgtOJeQFQRFgWBkd2hOBtEGa1eS7GFbSu6mIH5Nsw
        public string apiRequest;
        //https://api.themoviedb.org/3/movie/550?api_key=46c0d8825c69dad66e21bcb7a8cef00c
             
        /// <summary>
        /// Validates that the api is returning a successful response
        /// </summary>
        /// <param name="apiKey">Access Token to Use the API Call </param>
        public bool CheckResponseGetMovie(string apiKey)
        {
            var isValid = true;
            var client = new RestClient("https://api.themoviedb.org/3/movie/12?language=en-US&api_key=" + apiKey);
            var request = new RestRequest(Method.GET);
            request.AddParameter("undefined", "{}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode.ToString().ToLower() == "ok")
            {
                Console.WriteLine(string.Format("Test Passed: {0}", response.StatusCode));
                isValid = true;
            }
            else
            {
                Console.WriteLine(string.Format("Test Failed: {0}", response.StatusCode));
                isValid = false;            
            }
            return isValid;
        }
        /// <summary>
        /// Checks if the response is unsuccsessfull 
        /// </summary>
        /// <param name="apiKey">Api access Token for the api </param>
        /// <param name="movieId">Put in an unvalide Movie ID</param>
        public bool CheckFailedResponseGetMovie(string apiKey, string movieId)
        {
            var isValid = true;
            var client = new RestClient("https://api.themoviedb.org/3/movie/"+movieId+"?language=en-US&api_key=" + apiKey);
            var request = new RestRequest(Method.GET);
            request.AddParameter("undefined", "{}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode.ToString().ToLower() == "notfound")
            {
                Console.WriteLine(string.Format("Test Passed: {0}", response.StatusCode));
                isValid = true;
            }
            else
            {
                Console.WriteLine(string.Format("Test Failed: {0}", response.StatusCode));
                isValid = false;
            }
            return isValid;
        }

        public bool ValidateJsonIsReturnedGetMOvie(string apiKey)
        {
            var isValid = true;
            var client = new RestClient("https://api.themoviedb.org/3/movie/12?language=en-US&api_key=" + apiKey);
            var request = new RestRequest(Method.GET);
            request.AddParameter("undefined", "{}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if(response.StatusCode.ToString().ToLower() == "ok")
            {
                var results = response.Content;
               
               Console.WriteLine(response.Content);
            }
            return isValid;
        }


        
    }
}
