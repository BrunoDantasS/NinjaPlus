using Coypu;

namespace NinjaPlus.Pages
{
    public class Sidebar
    {
        private readonly BrowserSession _browser; // Underline para propriedades privadas

        public Sidebar(BrowserSession browser) //construtor
        {
            _browser = browser;
        }

        public string LoggedUser()
        {
            return _browser.FindCss(".user .info span").Text;
        }
    }
}