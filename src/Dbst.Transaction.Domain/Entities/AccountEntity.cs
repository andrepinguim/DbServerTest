namespace Dbst.Transaction.Domain.Entities
{
    public class AccountEntity : BaseEntity
    {
        public AccountEntity() { }

        public AccountEntity(string number, string agency, string digit)
        {
            this.Number = number;
            this.Agency = agency;
            this.Digit = digit;
        }

        public string Number { get; set; }
        public string Agency { get; set; }
        public string Digit { get; set; }
        public double Balance { get; set; }
    }
}
