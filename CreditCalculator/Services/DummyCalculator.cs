using CreditCalculator.Models;

namespace CreditCalculator.Services
{
    public class DummyCalculator : ICreditCalculator
    {
        private IEnumerable<CreditPayment> CreateStandardList()
        {
            List<CreditPayment> creditPayments = new List<CreditPayment>();
            creditPayments.Add(new CreditPayment { Number = 1, Payday = DateTime.Now, TotalPayment= 1000, BodyPayment = 888f, PercentPayment = 100f, Remainder = 100f });
            creditPayments.Add(new CreditPayment { Number = 2, Payday = DateTime.Now, TotalPayment= 1000, BodyPayment = 888f, PercentPayment = 100f, Remainder = 100f });
            creditPayments.Add(new CreditPayment { Number = 3, Payday = DateTime.Now, TotalPayment= 1000, BodyPayment = 888f, PercentPayment = 100f, Remainder = 100f });
            creditPayments.Add(new CreditPayment { Number = 4, Payday = DateTime.Now, TotalPayment= 1000, BodyPayment = 888f, PercentPayment = 100f, Remainder = 100f });
            creditPayments.Add(new CreditPayment { Number = 5, Payday = DateTime.Now, TotalPayment= 1000, BodyPayment = 888f, PercentPayment = 100f, Remainder = 100f });

            return creditPayments;
        }

        public IEnumerable<CreditPayment> Calculate(BasicCreditInfo creditInfo)
        {
            return CreateStandardList();
        }

        public IEnumerable<CreditPayment> Calculate(AdvancedCreditInfo creditInfo)
        {
            return CreateStandardList();
        }

        public double CalcOverpayments(IEnumerable<CreditPayment> payments, BasicCreditInfo creditSum)
        {
            return 100;
        }
    }
}
