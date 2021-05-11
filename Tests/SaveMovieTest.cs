using System.Threading;
using NinjaPlus.Common;
using NinjaPlus.Pages;
using NUnit.Framework;

namespace NinjaPlus.Tests
{
    public class SaveMovieTest : BaseTest
    {
        private LoginPage _login;
        private MoviePage _movie;

        [SetUp]
        public void Before()
        {
            _login = new LoginPage(Browser);
            _movie = new MoviePage(Browser);
            _login.With("papito@ninjaplus.com", "pwd123");
        }

        [Test]
        public void ShouldSaveMovie()
        {
            _movie.Add();
            _movie.Save("Resident Evil", "Disponível");
            Thread.Sleep(5000);
        }
    }
}