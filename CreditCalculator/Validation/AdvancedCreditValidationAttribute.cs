using CreditCalculator.Models;
using System.ComponentModel.DataAnnotations;

namespace CreditCalculator.Validation
{
    public class AdvancedCreditValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is AdvancedCreditInfo creditInfo)
            {
                if (creditInfo.Duration % creditInfo.PaymentStep != 0)
                {
                    ErrorMessage = "Шаг платежа должен нацело делить срок займа";
                    return false;
                }
                if (creditInfo.Duration < creditInfo.PaymentStep)
                {
                    ErrorMessage = "Шаг платежа должен быть меньше срока займа";
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}
