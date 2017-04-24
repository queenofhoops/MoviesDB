using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieDBTesting;

namespace MovieDBTesting
{
    [TestClass]
    public class MovieDBUnitTesting
    {
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

    [TestMethod]
        public void ValidateJsonIsReturnedGetMOvie()
        {
            var results = Mdb.ValidateJsonIsReturnedGetMOvie(apiKey);
            Assert.IsTrue(results);
        }
    }
}
