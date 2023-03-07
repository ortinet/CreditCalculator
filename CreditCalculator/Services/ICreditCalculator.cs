using CreditCalculator.Models;

namespace CreditCalculator.Services
{
    public interface ICreditCalculator
    {
        IEnumerable<CreditPayment> Calculate(BasicCreditInfo creditInfo);

        IEnumerable<CreditPayment> Calculate(AdvancedCreditInfo creditInfo);

        double CalcOverpayments(IEnumerable<CreditPayment> payments, BasicCreditInfo creditSum);
    }
}
