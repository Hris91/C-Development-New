
namespace P01_BillsPaymentSystem.Data.Models
{
    public class BankAccount
    {
        public BankAccount()
        {
            
        }

        public BankAccount(string name, string swiftCode, decimal balance)
        {
            this.BankName = name;
            this.SWIFTCode = swiftCode;
            this.Balance = balance;
        }

        public int BankAccountId { get; set; }

        public decimal Balance { get; private set; }
       
        public string BankName { get; set; }
        public string SWIFTCode { get; set; }

        public int PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        public void Deposit(decimal sum)
        {
            this.Balance += sum;
        }

        public void Withdraw(decimal sum)
        {
            this.Balance -= sum;
        }
 
    }
}
