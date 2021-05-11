using Coypu;

namespace NinjaPlus.Pages
{
    public class MoviePage
    {
        private readonly BrowserSession _browser; 

        public MoviePage(BrowserSession browser)
        {
            _browser = browser;
        }

        public void Add()
        {
            _browser.FindCss(".movie-add").Click();
        }

        public void SelectStatus(string status)
        {
            // _browser.Select("OPÇÃO_DROPDOWN").From("SELETOR_DO_ELEMENTO"); *Forma tradicional de selecionar DropDown 
            _browser.FindCss("input[placeholder=Status]").Click();
            var option = _browser.FindCss("ul li span", text: status); //Recurso exclusivo do Coypu
            option.Click();
        }

        public void Save(string title, string status)
        {
            _browser.FindCss("input[name=title]").SendKeys(title);
            SelectStatus(status);
            
        }
    }
}