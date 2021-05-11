using NinjaPlus.Common;
using NinjaPlus.Pages;
using NUnit.Framework;

namespace NinjaPlus.Tests
{
    public class LoginTests : BaseTest
    {
        public LoginPage _login;
        public Sidebar _side;

        [SetUp]
        public void Start()
        {
            _login = new LoginPage(Browser);
            _side = new Sidebar(Browser);
        }

        [Test]
        [Category("Critical")]
        public void ShouldSeeLoggedUser()
        {
            _login.With("papito@ninjaplus.com", "pwd123");
            Assert.AreEqual("Papito", _side.LoggedUser());
        }

        [Test]
        public void ShouldSeeIncorrectPass()
        {
            _login.With("papito@ninjaplus.com", "123456");
            Assert.AreEqual("Usuário e/ou senha inválidos", _login.AlertMessage());
        }

        [Test]
        public void ShouldSeeIncorrectUser()
        {
            _login.With("404@ninjaplus.com", "123456");
            Assert.AreEqual("Usuário e/ou senha inválidos", _login.AlertMessage());

        }

        [Test]
        public void ShouldSeeRequiredEmail()
        {
            _login.With("", "123456");
            Assert.AreEqual("Opps. Cadê o email?", _login.AlertMessage());
        }
        
        [Test]
        public void ShouldSeeRequiredPass()
        {
            _login.With("404@ninjaplus.com", "");
            Assert.AreEqual("Opps. Cadê a senha?", _login.AlertMessage());
        }
    }
}