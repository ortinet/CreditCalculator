using CreditCalculator.Models;

namespace CreditCalculator.Services
{
    public class MainCreditCalculator : ICreditCalculator
    {
        private double PaymentAmount(BasicCreditInfo creditInfo)
        {
            int n = creditInfo.Duration;
            double i = creditInfo.Rate / 100 / 12;

            return i * Math.Pow(1 + i, n) / (Math.Pow(1 + i, n) - 1) * creditInfo.Sum;
        }

        private double PaymentAmount(AdvancedCreditInfo creditInfo, out int n, out double i)
        {
            n = (int) Math.Ceiling((double)creditInfo.Duration / creditInfo.PaymentStep);
            i = creditInfo.Duration * creditInfo.Rate / n;
            

            return i / 100 * Math.Pow(1 + i / 100, n) / (Math.Pow(1 + i / 100, n) - 1) * creditInfo.Sum;
        }

        public IEnumerable<CreditPayment> Calculate(BasicCreditInfo creditInfo)
        {
            List<CreditPayment> creditPayments = new List<CreditPayment>();

            double paymentAmount = PaymentAmount(creditInfo);
            double remainder = creditInfo.Sum;
            DateTime firstDate = DateTime.Now;

            for (int i = 0; i < creditInfo.Duration; i++)
            {
                CreditPayment creditPayment = new CreditPayment();

                creditPayment.Number = i + 1;
                creditPayment.Payday = firstDate.AddMonths(i + 1);
                creditPayment.TotalPayment = paymentAmount;
                creditPayment.PercentPayment = remainder * creditInfo.Rate / 100 / 12;
                creditPayment.BodyPayment = paymentAmount - creditPayment.PercentPayment;

                remainder -= creditPayment.BodyPayment;

                creditPayment.Remainder = Math.Max(0, remainder);


                creditPayments.Add(creditPayment);
            }

            return creditPayments;
        }

        public IEnumerable<CreditPayment> Calculate(AdvancedCreditInfo creditInfo)
        {
            List<CreditPayment> creditPayments = new List<CreditPayment>();

            int totalSteps = default;
            double ratePerStep = default;

            double paymentAmount = PaymentAmount(creditInfo, out totalSteps, out ratePerStep);
            double remainder = creditInfo.Sum;
            DateTime firstDate = DateTime.Now;
            DateTime lastDate = firstDate.AddDays(creditInfo.Duration);

            for (int i = 0; i < totalSteps; i++)
            {
                CreditPayment creditPayment = new CreditPayment();

                creditPayment.Number = i + 1;
                creditPayment.Payday = firstDate.AddDays((i + 1) * creditInfo.PaymentStep);

                if (creditPayment.Payday > lastDate)
                    creditPayment.Payday = lastDate;

                creditPayment.TotalPayment = paymentAmount;
                creditPayment.PercentPayment = remainder * ratePerStep / 100;
                creditPayment.BodyPayment = paymentAmount - creditPayment.PercentPayment;

                remainder -= creditPayment.BodyPayment;

                creditPayment.Remainder = Math.Max(0, remainder);


                creditPayments.Add(creditPayment);
            }

            return creditPayments;
        }

        public double CalcOverpayments(IEnumerable<CreditPayment> payments, BasicCreditInfo creditInfo)
        {
            double sumPayment = 0;

            foreach (var payment in payments)
                sumPayment += payment.TotalPayment;

            return sumPayment - creditInfo.Sum;
        }
    }
}
