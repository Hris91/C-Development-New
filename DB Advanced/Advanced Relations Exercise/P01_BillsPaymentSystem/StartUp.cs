using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using P01_BillsPaymentSystem.Data;
using P01_BillsPaymentSystem.Data.Models;

namespace P01_BillsPaymentSystem
{
    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BillsPaymentSystemContext())
            {
                db.Database.EnsureDeleted();

                db.Database.EnsureCreated();

                Seed(db);

                Console.Write("Enter User Id: ");
                var userId = int.Parse(Console.ReadLine());

                if (db.Users.Any(u => u.UserId == userId))
                {                
                    SelctUser(db, userId);            
                }
                else
                {
                    Console.WriteLine($"User with id {userId} not found!");
                }

                Console.WriteLine();                                           
                Console.Write("Enter Amount to pay bills: ");
                var amount = decimal.Parse(Console.ReadLine());

                PayBills(userId, amount, db);
                SelctUser(db, userId);

            }
        }
        private static void PayBills(int id, decimal amount, BillsPaymentSystemContext db)
        {
            
            var currentAmount = amount;

            var userBankAccounts = db.Users
                .Where(u => u.UserId == id)
                .Select(u => new
                {
                    BankAccounts = u.PaymentMethods
                        .Where(pm => pm.Type == PaymentMethodType.BankAccount)
                        .Select(pm => pm.BankAccount)
                        .OrderBy(pm => pm.BankAccountId)
                        .ToList()
                })
                .FirstOrDefault();

            var usercreditCards = db.Users
                .Where(pm => pm.UserId == id)
                .Select(u => new
                {
                    CreditCards = u.PaymentMethods
                        .Where(pm => pm.Type == PaymentMethodType.CreditCard)
                        .Select(pm => pm.CreditCard)
                        .OrderBy(pm => pm.CreditCardId)
                        .ToList()
                })
                .FirstOrDefault();

            var totalMoneyOwned = 0m;

            foreach (var creditCard in usercreditCards.CreditCards)
            {
                totalMoneyOwned += creditCard.LimitLeft;
            }

            foreach (var bankAccount in userBankAccounts.BankAccounts)
            {
                totalMoneyOwned += bankAccount.Balance;
            }

            if (totalMoneyOwned < currentAmount)
            {
                Console.WriteLine("Insufficient funds!");
                return;
            }

            foreach (var userBankAccount in userBankAccounts.BankAccounts)
            {
                if (userBankAccount.Balance - currentAmount < 0 && currentAmount > 0)
                {
                    currentAmount = currentAmount - userBankAccount.Balance;
                    userBankAccount.Withdraw(userBankAccount.Balance);                   
                }
                else
                {
                    userBankAccount.Withdraw(currentAmount);
                    Console.WriteLine(Environment.NewLine + "Bills payed successfully" + Environment.NewLine);
                    return;
                }
            }

            foreach (var creditCard in usercreditCards.CreditCards)
            {
                if (creditCard.MoneyOwed + currentAmount > creditCard.Limit && currentAmount > 0)
                {
                    currentAmount -= creditCard.LimitLeft;
                    creditCard.Withdraw(creditCard.LimitLeft);                                  
                }
                else
                {
                    creditCard.Withdraw(currentAmount);
                    Console.WriteLine(Environment.NewLine + "Bills payed successfully" + Environment.NewLine);
                    return;
                }
            }
          
            db.SaveChanges();
        }

        public static void Seed(BillsPaymentSystemContext db)
        {
            var user = new User()
            {
                FirstName = "Pesho",
                LastName = "Peshov",
                Email = "peshaka@abv.bg",
                Password = "dhaiuwdhhdaw"
            };

            var creditCards = new CreditCard[]
            {
                new CreditCard(100000M,  333M, DateTime.ParseExact("12.09.2200", "dd.MM.yyyy", null)),
               
                new CreditCard(200M, 8, DateTime.ParseExact("12.09.2200", "dd.MM.yyyy", null))             
            };

            var bankAccount = new BankAccount("Some Bank", "THECODE", 1500m);
                      
            var paymentMethods = new PaymentMethod[]
            {
                new PaymentMethod()
                {
                    User = user,
                    CreditCard = creditCards[0],
                    Type = PaymentMethodType.CreditCard
                },

                new PaymentMethod()
                {
                    User = user,
                    CreditCard = creditCards[1],
                    Type = PaymentMethodType.CreditCard
                },

                new PaymentMethod()
                {
                    User = user,
                    BankAccount = bankAccount,
                    Type = PaymentMethodType.BankAccount
                }
            };

            db.Users.Add(user);
            db.CreditCards.AddRange(creditCards);
            db.BankAccounts.Add(bankAccount);
            db.PaymentMethods.AddRange(paymentMethods);

            db.SaveChanges();
        }

        public static void SelctUser(BillsPaymentSystemContext db, int userId)
        {           
            var user = db.Users
                .Where(u => u.UserId == userId)
                .Select(u => new
                {
                    UserName = $"{u.FirstName} {u.LastName}",
                    CreditCards = u.PaymentMethods
                        .Where(pm => pm.Type == PaymentMethodType.CreditCard)
                        .Select(pm => pm.CreditCard)
                        .ToList(),
                    BankAccounts = u.PaymentMethods
                        .Where(pm => pm.Type == PaymentMethodType.BankAccount)
                        .Select(pm => pm.BankAccount)
                        .ToList()
                })
                .FirstOrDefault();

            Console.WriteLine($"User: {user.UserName}");

            if (user.BankAccounts.Any())
            {
                Console.WriteLine("Bank Accounts:");
            }

            foreach (var bankAccount in user.BankAccounts)
            {
                Console.WriteLine($"-- ID: {bankAccount.BankAccountId}");
                Console.WriteLine($"--- Balance: {bankAccount.Balance:f2}");
                Console.WriteLine($"--- Bank: {bankAccount.BankName}");
                Console.WriteLine($"--- SWIFT: {bankAccount.SWIFTCode}");            
            }
             
            if (user.CreditCards.Any())
            {
                Console.WriteLine($"Credit Cards:");
            }

            foreach (var creditCard in user.CreditCards)
            {
                Console.WriteLine($"-- ID: {creditCard.CreditCardId}");
                Console.WriteLine($"--- Limit: {creditCard.Limit}");
                Console.WriteLine($"--- Money Owed: {creditCard.MoneyOwed}");
                Console.WriteLine($"--- Limit Left:: {creditCard.LimitLeft}");
                Console.WriteLine($"--- Expiration Date: {creditCard.ExpirationDate.Year}/{creditCard.ExpirationDate.Month}");               
            }
        }   
    }
}
