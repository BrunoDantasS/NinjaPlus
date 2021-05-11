using System.Collections.Generic;
using System.Threading;
using Coypu;
using NinjaPlus.Models;
using OpenQA.Selenium;

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

        private void SelectStatus(string status)
        {
            // _browser.Select("OPÇÃO_DROPDOWN").From("SELETOR_DO_ELEMENTO"); *Forma tradicional de selecionar DropDown 
            _browser.FindCss("input[placeholder=Status]").Click();
            var option = _browser.FindCss("ul li span", text: status); //Recurso exclusivo do Coypu
            option.Click();
        }

        private void InputCast(List<string> cast)
        {
            var element = _browser.FindCss("input[placeholder$=ator]");
            foreach(var actor in cast)
            {
                element.SendKeys(actor);
                element.SendKeys(Keys.Tab); // Simular tecla Tab
                Thread.Sleep(500); //Thinking Time
            }
        }

        public void Save(MovieModel movie)
        {
            _browser.FindCss("input[name=title]").SendKeys(movie.Title);
            SelectStatus(movie.Status);

            _browser.FindCss("input[name=year]").SendKeys(movie.Year.ToString());

            _browser.FindCss("input[name=release_date]").SendKeys(movie.ReleaseDate);

            InputCast(movie.Cast);

            _browser.FindCss("textarea[name=overview]").SendKeys(movie.Plot);

            
        }
    }
}