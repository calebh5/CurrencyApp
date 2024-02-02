// Controllers/HomeController.cs
using Microsoft.AspNetCore.Mvc;
using CurrencyApp.Models;

namespace CurrencyApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly CurrencyConverterModel currencyConverter;

        public HomeController()
        {
            currencyConverter = new CurrencyConverterModel();
        }

        public IActionResult Index()
        {
            ViewBag.Currencies = currencyConverter.GetAvailableCurrencies();
            return View();
        }

        [HttpPost]
        public IActionResult ConvertCurrency(string currencyFrom, string currencyTo, decimal amount)
        {
            try
            {
                decimal convertedAmount = currencyConverter.ConvertCurrency(currencyFrom, currencyTo, amount);
                ViewBag.ConvertedAmount = convertedAmount;
            }
            catch (System.Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }

            ViewBag.Currencies = currencyConverter.GetAvailableCurrencies(); // Ensure the dropdown is populated after the form submission

            return View("Index");
        }
    }
}
