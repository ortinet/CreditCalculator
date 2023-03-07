using CreditCalculator.Models;
using CreditCalculator.Services;
using CreditCalculator.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CreditCalculator.Controllers
{
    public class CreditController : Controller
    {
        private readonly ICreditCalculator _creditCalculator;

        public CreditController(ICreditCalculator creditCalculator)
        {
            _creditCalculator = creditCalculator;
        }

        [HttpGet]
        public IActionResult Basic()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Basic(BasicCreditInfo creditInfo)
        {
            if (!ModelState.IsValid)
            {
                return View(creditInfo);
            }

            IEnumerable<CreditPayment> creditPayments = _creditCalculator.Calculate(creditInfo);
            CreditPaymentsViewModel viewModel = new CreditPaymentsViewModel()
            {
                CreditPayments = creditPayments,
                TotalOverpayment = _creditCalculator.CalcOverpayments(creditPayments, creditInfo),
            };

            return View("CreditPayments", viewModel);
        }

        [HttpGet]
        public IActionResult Advanced()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Advanced(AdvancedCreditInfo creditInfo)
        {
            if (!ModelState.IsValid)
            {
                return View(creditInfo);
            }

            IEnumerable<CreditPayment> creditPayments = _creditCalculator.Calculate(creditInfo);
            CreditPaymentsViewModel viewModel = new CreditPaymentsViewModel()
            {
                CreditPayments = creditPayments,
                TotalOverpayment = _creditCalculator.CalcOverpayments(creditPayments, creditInfo),
            };

            return View("CreditPayments", viewModel);
        }
    }
}
