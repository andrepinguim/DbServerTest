using System.ComponentModel.DataAnnotations;

namespace Dbst.Transaction.Api.Models
{
    public class Transference
    {
        [Required(ErrorMessage = "Conta de origem obrigatória")]
        public int OriginAccountId { get; set; }

        [Required(ErrorMessage = "Conta de destino obrigatória")]
        public int DestinationAccountId { get; set; }

        [Required(ErrorMessage = "Valor a ser transferido obrigatório")]
        [Range(0, int.MaxValue)]
        public double Value { get; set; }
    }
}
