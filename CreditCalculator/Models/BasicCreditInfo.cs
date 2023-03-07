using System.ComponentModel.DataAnnotations;

namespace CreditCalculator.Models
{
    public class BasicCreditInfo
    {
        [RegularExpression(@"^\d+$", ErrorMessage = "Значение должно быть целым числом")]
        [Required(ErrorMessage = "Введите сумму!")]
        public int Sum { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "Значение должно быть целым числом")]
        [Required(ErrorMessage = "Введите срок!")]
        public int Duration { get; set; }

        [RegularExpression(@"^[0-9]*[.,]?[0-9]+$", ErrorMessage = "Значение должно быть числом")]
        [Required(ErrorMessage = "Введите ставку!")]
        public double Rate { get; set; }
    }
}
