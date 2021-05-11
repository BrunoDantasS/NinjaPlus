using System;
using Coypu;
using Coypu.Drivers.Selenium;
using NinjaPlus.Pages;
using NUnit.Framework;

namespace NinjaPlus.Tests
{
    public class LoginTests
    {
        public BrowserSession browser;
        public LoginPage _login;
        public Sidebar _side;

        [SetUp]
        public void Setup()
        {
            var configs = new SessionConfiguration 
            {
                AppHost = "http://ninjaplus-web",
                Port = 5000,
                SSL = false,
                Driver = typeof(SeleniumWebDriver),
                Browser = Coypu.Drivers.Browser.Chrome,
                Timeout = TimeSpan.FromSeconds(10)
            };

            browser = new BrowserSession(configs);

            browser.MaximiseWindow();

            _login = new LoginPage(browser);
            _side = new Sidebar(browser);
        }

        [TearDown]
        public void Finish()
        {
            browser.Dispose();
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