using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieDBTesting;

namespace MovieDBTesting
{
    [TestClass]
    public class MovieDBUnitTesting
    {
        //Api access Token Change when running 
        string apiKey = "46c0d8825c69dad66e21bcb7a8cef00c";
        MovieDbProject Mdb = new MovieDbProject();
        /// <summary>
        /// Validates Success Code
        /// Returns OK
        /// </summary>
        [TestMethod]
        public void SuccessfullResponseGetMovie()
        {

            var results = Mdb.CheckResponseGetMovie(apiKey);
            Assert.IsTrue(results);
        }

        /// <summary>
        /// Validate Not Found Code
        /// </summary>
        [TestMethod]
        public void UnsuccessfullGetMovieResponse()
        {
            var results = Mdb.CheckFailedResponseGetMovie(apiKey, "babjbdabbfabsfsbdaf");
            Assert.IsTrue(results);
        }
        /// <summary>
        /// validate that Json is returned in the test
        /// </summary>
        [TestMethod]
        public void ValidateJsonIsReturnedGetMOvie()
        {
            var results = Mdb.ValidateJsonIsReturnedGetMOvie(apiKey);
            Assert.IsTrue(results);
        }
        /// <summary>
        /// Pseudo
        /// Validates the json in each data set
        /// </summary>
        [TestMethod]
        public void ValidateJsonReturnsExpectedValuesGetMovie()
        {
            var results = Mdb.ValidateJsonReturnsExpectedValuesGetMovie(apiKey);
            Assert.IsTrue(results);
        }


    }
}
