using Coypu;

namespace NinjaPlus.Pages
{
    public class LoginPage
    {
        private readonly BrowserSession _browser; // Underline para propriedades privadas

        public LoginPage(BrowserSession browser) //construtor
        {
            _browser = browser;
        }

        public void Load()
        {
            _browser.Visit("/login");
        }

        public void With(string email, string pass)
        {
            this.Load();
            _browser.FillIn("email").With(email);
            _browser.FindCss("#passId").SendKeys(pass);
            _browser.ClickButton("Entrar");
        }

        public string AlertMessage()
        {
            return _browser.FindCss(".alert").Text;
        }
    }
}