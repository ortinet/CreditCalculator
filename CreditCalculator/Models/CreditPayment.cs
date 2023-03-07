namespace CreditCalculator.Models
{
    public class CreditPayment
    {
        public int Number { get; set; }
        public DateTime Payday { get; set; }
        public double TotalPayment { get; set; }
        public double BodyPayment { get; set; }
        public double PercentPayment { get; set; }
        public double Remainder { get; set; }
    }
}
