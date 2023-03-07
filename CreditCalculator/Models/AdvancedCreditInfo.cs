using CreditCalculator.Validation;
using System.ComponentModel.DataAnnotations;

namespace CreditCalculator.Models
{
    [AdvancedCreditValidationAttribute]
    public class AdvancedCreditInfo : BasicCreditInfo
    {
        [RegularExpression(@"^\d+$", ErrorMessage = "Значение должно быть числом")]
        [Required(ErrorMessage = "Введите шаг платежа!")]
        public int PaymentStep { get; set; }
    }
}
