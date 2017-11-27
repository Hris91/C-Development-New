(1)Your task is to create a database for Bills Payment System, using the Code First approach. 
In the database, we should keep information about the users (first name, last name, email, password, payment methods). 
Every payment method should have an id, an owner, a type and a credit card or a bank account connected to it. 
There are two types of billing details – credit card and bank account.
The credit card has expiration date, a limit and an amount of money owed. 
The bank account has a balance, a bank name and a SWIFT code.

(2) Make a Seed() method to seed some data into the BillsPaymentSystem database.

(3) Create a console app that retrieves from the database a user and all of his payment methods by a given user id, and prints them on the console
First, list the user’s bank accounts and then – his credit cards. If no such user exist, print "User with id {userId} not found!" instead.

(4) Add Withdraw() and Deposit() methods to the BankAccount and CreditCard classes, and make sure they are the only way you can change the Balance, MoneyOwed and Limit properties. 
Then create a PayBills(int userId, decimal amount) method that uses all of a user’s payment methods to pay his bills.
Start with his bank accounts, ordered by id, and then his credit cards, ordered by id. If the user doesn’t have enough money available, don’t withdraw anything and print "Insufficient funds!" to the console.

