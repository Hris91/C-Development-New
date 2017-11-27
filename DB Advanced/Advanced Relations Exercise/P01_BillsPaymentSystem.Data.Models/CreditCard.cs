
using System;

namespace P01_BillsPaymentSystem.Data.Models
{
    public class CreditCard
    {
        public CreditCard()
        {
            
        }

        public CreditCard(decimal limit, decimal moneyOwed, DateTime expirationDate)
        {      
            Limit = limit;
            MoneyOwed = moneyOwed;
            ExpirationDate = expirationDate;       
        }

        public int CreditCardId { get; set; }
        public decimal Limit { get; private set; }
        public decimal MoneyOwed { get; private set; }
        public DateTime ExpirationDate { get; set; }

        public decimal LimitLeft => this.Limit - this.MoneyOwed;

        public int PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        public void Deposit(decimal sum)
        {
            this.MoneyOwed -= sum;          
        }

        public void Withdraw(decimal sum)
        {
            this.MoneyOwed += sum;
        }
    }
}
