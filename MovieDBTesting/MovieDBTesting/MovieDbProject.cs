using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MovieDBTesting
{
    class MovieDbProject
    {
        /*identify dozen or so tests you would write
        * https://api.themoviedb.org/3/movie/{movie_id}/rating?api_key=<<api_key>>https://api.themoviedb.org/3/movie/{movie_id}/rating?api_key=<<api_key>>
        * Validate the 201 code of the api call
        * Validate the 404 code of the api call 
        * Validate the guest session id
        * Validate a unauthorized guest session id
        * Validate a valid session id
        * Validate a non valid session id
        * Validate the Json response body is returning what is expected
        * Validate the 401 response code
        * Validate enter a successful number for rating 
        * Validate enter a string and Validate and unsuccessful call 
        * Validate the movid_id
        * Validate different versions of the api are still working
        */

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
                
                isValid = true;
            }
            else
            {
                Console.WriteLine(string.Format("Failed to get a successful response: {0}", response.StatusCode));
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
            var client = new RestClient("https://api.themoviedb.org/3/movie/" + movieId + "?language=en-US&api_key=" + apiKey);
            var request = new RestRequest(Method.GET);
            request.AddParameter("undefined", "{}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode.ToString().ToLower() == "notfound")
            {
                
                isValid = true;
            }
            else
            {
                Console.WriteLine(string.Format("Failed to get a successful response: {0}", response.StatusCode));
                isValid = false;
            }
            return isValid;
        }
        /// <summary>
        /// Validates Json is returned in the response body
        /// </summary>
        /// <param name="apiKey">Access Token to make api call</param>
        /// <returns></returns>
        public bool ValidateJsonIsReturnedGetMOvie(string apiKey)
        {
            var isValid = true;
            var client = new RestClient("https://api.themoviedb.org/3/movie/12?language=en-US&api_key=" + apiKey);
            var request = new RestRequest(Method.GET);
            request.AddParameter("undefined", "{}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode.ToString().ToLower() == "ok")
            {
                var results = response.Content;
                var jResults = JObject.Parse(results);

                var id = (JValue)jResults["id"];
                if (id.ToString().Equals(null))
                {
                    isValid = false;
                    Console.WriteLine("Id was null");
                }
            }
            else
            {
                isValid = false;
                Console.WriteLine("Failed to get a successful response {0}", response.StatusCode);
            }
            return isValid;

        }
        /// <summary>
        /// validates the Json in Get Movie Api call
        /// </summary>
        /// <param name="apiKey">Token for API access</param>
        /// <returns></returns>
        public bool ValidateJsonReturnsExpectedValuesGetMovie(string apiKey)
        {

            var isValid = true;
            var client = new RestClient("https://api.themoviedb.org/3/movie/12?language=en-US&api_key=" + apiKey);
            var request = new RestRequest(Method.GET);
            request.AddParameter("undefined", "{}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode.ToString().ToLower() == "ok")
            {
                var results = response.Content;
                var jResults = JObject.Parse(results);
                var adult = (JValue)jResults["adult"];
                if (!adult.ToString().Equals(null))
                {
                    isValid = true;
                    var backdropPath = (JValue)jResults["backdrop_path"];
                    if (!backdropPath.ToString().Equals(null))
                    {
                        isValid = true;
                    }
                    else
                    {
                        isValid = false;
                        Console.WriteLine("Back Drop Path is null");
                    }

                }
                else
                {
                    isValid = false;
                    Console.WriteLine("adult is null");
                }
            }
            else
            {
                isValid = false;
                Console.WriteLine("Failed to get a successful response {0}", response.StatusCode);
            }
            return isValid;


        }
     


    }
}
