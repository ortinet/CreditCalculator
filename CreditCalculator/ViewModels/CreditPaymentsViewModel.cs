using CreditCalculator.Models;

namespace CreditCalculator.ViewModels
{
    public class CreditPaymentsViewModel
    {
        public IEnumerable<CreditPayment> CreditPayments { get; set; } = Enumerable.Empty<CreditPayment>();
        public double TotalOverpayment { get; set; }
    }
}
