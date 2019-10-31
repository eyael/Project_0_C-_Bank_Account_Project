
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Program
    {
        static List<Customer> customers = new List<Customer>();
        static List<Account> accounts = new List<Account>();
        Random rd = new Random();
        static string password = "", name = "", age = "", accountNumber = "", accountType = "", balance = "", transferFrom = "", transferTo = "";

        static void Main(string[] args)
        {
            while (true)
            {
            HOME:
                Console.WriteLine("-------------Welcome to Eyael Bank--------------");
                Console.WriteLine("-------------Do you have account before, press y or n--------------");
                switch (Console.ReadLine())
                {
                    case "y":
                        Console.WriteLine("Please Insert your Account Number: ");
                        accountNumber = Console.ReadLine();

                        Console.WriteLine("Please Insert your Password: ");
                        password = Console.ReadLine();
                        Customer cust = CheckUser(accountNumber, password);
                        if (cust != null)
                            BankOperation();
                        else
                        {
                            Console.WriteLine("Incorrect Account Number or Password or You are not Registered beore! ");
                            goto HOME;
                        }
                        break;
                    case "n":
                        AddNewUser();
                        break;
                    default:
                        break;
                }
                if (customers.Count > 0)
                {
                    BankOperation();

                }

            }
        }

        private static void AddNewUser()
        {
            Console.WriteLine("---Would like to Open Account? Press y or n---");
            switch (Console.ReadLine())
            {
                case "n":
                    break;
                case "y":
                    Console.WriteLine("Full Name: ");
                    name = Console.ReadLine();
                    Console.WriteLine("Age: ");
                    age = Console.ReadLine();
                    Console.WriteLine("Password: ");
                    password = Console.ReadLine();
                ACC:
                    Console.WriteLine("These are types of Account we have");
                    Console.WriteLine("Press 1 for Checking Account");
                    Console.WriteLine("Press 2 for Business Account");
                    Console.WriteLine("Press 3 for Certification of Deposit");
                    switch (Console.ReadLine())
                    {
                        case "1":

                            accountType = "Checking Account";
                            Random rd = new Random();
                            accountNumber = rd.Next(1, 9).ToString() + rd.Next(1, 9) + rd.Next(1, 9) +
                                            rd.Next(1, 9) + rd.Next(1, 9) + rd.Next(1, 9);
                            addAccount(accountType, accountNumber);
                            Console.WriteLine("-----------------------------------");
                            Console.WriteLine("Successfully Crated!");
                            Console.WriteLine("Your Account Number is " + accountNumber);
                            Console.WriteLine("-----------------------------------");
                            Console.WriteLine("Do you want to Deposit on this Account? press y or n");
                            switch (Console.ReadLine())
                            {
                                case "y":
                                    Console.WriteLine("Amount: ");
                                    balance = Console.ReadLine();
                                    updateBalance(balance, accountNumber);
                                    Console.WriteLine("-----------------------------------");
                                    Console.WriteLine("------Successfully Deposited!------");
                                    Console.WriteLine("---Your Balance is:$ " + balance + " ---");
                                    Console.WriteLine("-----------------------------------");
                                    break;
                                case "n":
                                    break;
                                default:
                                    break;
                            }
                            Console.WriteLine("Do you want to Create another account? press y or n");
                            switch (Console.ReadLine())
                            {
                                case "y":
                                    goto ACC;
                                    break;
                                case "n":
                                    addCustomer(accounts, name, age, password);
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case "2":
                            accountType = "Business Account";
                            Random rdm = new Random();
                            accountNumber = rdm.Next(1, 9).ToString() + rdm.Next(1, 9) + rdm.Next(1, 9) +
                                            rdm.Next(1, 9) + rdm.Next(1, 9) + rdm.Next(1, 9);
                            addAccount(accountType, accountNumber);
                            Console.WriteLine("-----------------------------------");
                            Console.WriteLine("Successfully Crated!");
                            Console.WriteLine("Your Account Number is " + accountNumber);
                            Console.WriteLine("-----------------------------------");
                            Console.WriteLine("Do you want to Deposit on this Account? press y or n");
                            switch (Console.ReadLine())
                            {
                                case "y":
                                    Console.WriteLine("Amount: ");
                                    balance = Console.ReadLine();
                                    updateBalance(balance, accountNumber);
                                    Console.WriteLine("-----------------------------------");
                                    Console.WriteLine("------Successfully Deposited!------");
                                    Console.WriteLine("---Your Balance is:$ " + balance + " ---");
                                    Console.WriteLine("-----------------------------------");
                                    break;
                                case "n":
                                    break;
                                default:
                                    break;
                            }
                            Console.WriteLine("Do you want to Create another account? press y or n");
                            switch (Console.ReadLine())
                            {
                                case "y":
                                    goto ACC;
                                    break;
                                case "n":
                                    addCustomer(accounts, name, age, password);
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case "3":
                            accountType = "CD";
                            Random rndm = new Random();
                            accountNumber = rndm.Next(1, 9).ToString() + rndm.Next(1, 9) +
                                            rndm.Next(1, 9) + rndm.Next(1, 9) + rndm.Next(1, 9) +
                                            rndm.Next(1, 9);
                            addAccount(accountType, accountNumber);
                            Console.WriteLine("-----------------------------------");
                            Console.WriteLine("Successfully Crated!");
                            DateTime thisDay = DateTime.Today;
                            // Display the date in the default (general) format.
                            Console.WriteLine(thisDay.ToString());
                            Console.WriteLine("Your Account Number is " + accountNumber);
                            Console.WriteLine("-----------------------------------");
                            Console.WriteLine("Do you want to Deposit on this Account? press y or n");
                            switch (Console.ReadLine())
                            {
                                case "y":
                                    Console.WriteLine("Amount: ");
                                    balance = Console.ReadLine();
                                    updateBalance(balance, accountNumber);
                                    Console.WriteLine("-----------------------------------");
                                    Console.WriteLine("------Successfully Deposited!------");
                                    Console.WriteLine("---Your Balance is:$ " + balance + " ---");
                                    Console.WriteLine("-----------------------------------");
                                    break;
                                case "n":
                                    break;
                                default:
                                    break;
                            }
                            Console.WriteLine("Do you want to Create another account? press y or n");
                            switch (Console.ReadLine())
                            {
                                case "y":
                                    goto ACC;
                                    break;
                                case "n":
                                    addCustomer(accounts, name, age, password);
                                    break;
                                default:
                                    break;
                            }
                            break;
                        default:
                            break;
                    }
                    break;

                default:
                    break;

            }
        }

        private static void BankOperation()
        {
        OPP:
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("These are types of Service we have");
            Console.WriteLine("Press 1 Withdrawal");
            Console.WriteLine("Press 2 Deposit");
            Console.WriteLine("Press 3 Transfer");
            Console.WriteLine("Press 4 Pay Loan");
            Console.WriteLine("Press 5 View Accounts");
            Console.WriteLine("Press 6 Transactions");
            Console.WriteLine("Press any other key to exist!");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Please Insert your Account Number to Withdraw: ");
                    accountNumber = Console.ReadLine();
                    Account account = GetAccountInformation(accountNumber);
                    if (account != null)
                    {
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine("Account Number: " + account.AccountNumber);
                        Console.WriteLine("Account Type: " + account.AccountType);
                        Console.WriteLine("Balance $ " + account.Balance);
                        Console.WriteLine("-----------------------------------");
                        if (Convert.ToDouble(account.Balance) <= 0.00 ||
                            string.IsNullOrWhiteSpace(account.Balance))
                        {
                            Console.WriteLine("-----------------------------------");
                            Console.WriteLine("You can't Withdraw! You have Insufficient balance");
                            goto OPP;
                        }
                        else
                        {
                            Console.WriteLine("Insert the Amount you want to Withdraw");
                            balance = Console.ReadLine();
                            Account acco = WithdrawalFromAccount(account.AccountNumber, balance);

                            if (acco != null)
                            {
                                Console.WriteLine("------------------------------------------");
                                Console.WriteLine("----------Successfully Withdrawal!-----------");
                                Console.WriteLine("You Current Balance is $ " + acco.Balance);
                                goto OPP;
                            }
                            else
                            {
                                Console.WriteLine("-----------------------------------");
                                Console.WriteLine("You can't Withdraw! You are under 18 age");
                                Console.WriteLine("-----------------------------------");
                                goto OPP;
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine("Incorrect Account Number!");
                        Console.ReadLine();
                        goto OPP;
                    }

                    break;
                case "2":
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Please Insert your Account Number to Deposit: ");
                    accountNumber = Console.ReadLine();
                    Account depositAccount = GetAccountInformation(accountNumber);
                    if (depositAccount != null)
                    {
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine("Account Number: " + depositAccount.AccountNumber);
                        Console.WriteLine("Account Type: " + depositAccount.AccountType);
                        Console.WriteLine("Current Balance $ " + depositAccount.Balance);
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine("Please Insert the Amount you want to Deposit: ");
                        balance = Console.ReadLine();
                        Account depAccount = Deposit(balance, depositAccount.AccountNumber);
                        if (depAccount != null)
                        {
                            Console.WriteLine("-----------------------------------");
                            Console.WriteLine("Successfully Deposited!");
                            Console.WriteLine("Account Number: " + depAccount.AccountNumber);
                            Console.WriteLine("Account Type: " + depAccount.AccountType);
                            Console.WriteLine("Balance $ " + depAccount.Balance);
                            Console.WriteLine("-----------------------------------");
                            goto OPP;
                        }
                        else
                        {
                            Console.WriteLine("-----------------------------------");
                            Console.WriteLine("Failed To Deposit!");
                            goto OPP;
                        }
                    }
                    else
                    {
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine("Incorrect Account Number!");
                        goto OPP;
                    }
                    break;
                case "3":
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("From Which Account number you want to Trasfer: ");
                    transferFrom = Console.ReadLine();
                    Console.WriteLine("To Which Account number you want to Trasfer: ");
                    transferTo = Console.ReadLine();
                    Console.WriteLine("Please Insert the amount you want to Trasfer: ");
                    balance = Console.ReadLine();
                    string transferStatus = Transfer(transferFrom, transferTo, balance);
                    if (transferStatus == "success")
                    {
                        Account fromAccount = GetAccountInformation(transferFrom);
                        Account toAccount = GetAccountInformation(transferTo);
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine("Successfully Transfered!");
                        Console.WriteLine("-------Transfer From---------");
                        Console.WriteLine("Account Number: " + fromAccount.AccountNumber);
                        Console.WriteLine("Account Type: " + fromAccount.AccountType);
                        Console.WriteLine("Current Balance $ " + fromAccount.Balance);
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine("-------Transfer To---------");
                        Console.WriteLine("Account Number: " + toAccount.AccountNumber);
                        Console.WriteLine("Account Type: " + toAccount.AccountType);
                        Console.WriteLine("Current Balance $ " + toAccount.Balance);
                        Console.WriteLine("-----------------------------------");
                        goto OPP;
                    }
                    else
                    {
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine("Failed To Transfered!" + transferStatus);
                        Console.WriteLine("-----------------------------------");
                        goto OPP;
                    }
                    break;
                case "4":
                   // double newbalance;
                    double TotalLone;
                    double InterestLoan; //amount that user have used from approved loan
                    double Time; //time refers to the number of months that user has not paid
                    double LoanUsed = 3000; //maximum loan approved for existing user
                    double InterestRate = 0.09; //interest rate
                    Console.WriteLine("Welcome, how much have you used?");
                    InterestLoan = double.Parse(Console.ReadLine());
                   
                    Console.WriteLine("how many months have you not paid?");
                    Time = double.Parse(Console.ReadLine());
                    TotalLone = (Time * InterestRate * InterestLoan) + InterestLoan;

                    Console.WriteLine("your loan balance is {0}", TotalLone + "$");
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("From Which Account number you want to pay loan: ");
                    transferFrom = Console.ReadLine();
                    //Console.WriteLine("To Which Account number you want to Trasfer: ");
                    //transferTo = Console.ReadLine();
                    Console.WriteLine("Please Insert the amount you want to pay: ");
                    balance = Console.ReadLine();
                    double pay = TotalLone - Convert.ToDouble(balance);

                    Console.WriteLine("you paid {0} ", balance + "$");
                    Console.WriteLine("your new loan balance is {0} ", pay + "$");
                    Console.ReadLine();
                    
                    //Console.WriteLine("you paid{0} ");
                    goto OPP;
                    break;
                case "5":
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Insert Your One Account Number:");
                    accountNumber = Console.ReadLine();
                    Console.WriteLine("Insert Password:");
                    password = Console.ReadLine();
                    Customer user = CheckUser(accountNumber, password);
                    if (user != null)
                    {
                        Console.WriteLine("-------User Information---------------");
                        Console.WriteLine("First Name: " + user.Name);
                        Console.WriteLine("Age: " + user.Age);
                        foreach (var customer in user.Accounts)
                        {
                            Console.WriteLine("------------Account Information-------------");
                            Console.WriteLine("Account Type: " + customer.AccountType);
                            Console.WriteLine("Account Numer: " + customer.AccountNumber);
                            Console.WriteLine("Balance: " + customer.Balance);
                            Console.WriteLine("-----------------------------------------");
                        }

                    }
                    goto OPP;
                    break;
                case "6":
                    break;
                default:
                    break;
            }
        }

        private static string Transfer(string transferFrom, string transferTo, string balance)
        {
            string from = "", to = "";
            foreach (var cust in customers)
            {
                foreach (var acc in cust.Accounts)
                {

                    if (acc.AccountNumber == transferFrom)
                    {
                        from = acc.Balance;
                        if ((Convert.ToDouble(from) - Convert.ToDouble(balance)) < 0)
                            return "Insufficient Balance!";

                    }

                    if (acc.AccountNumber == transferTo)
                    {
                        to = acc.Balance;
                    }

                }
                if (!string.IsNullOrWhiteSpace(from) && !string.IsNullOrWhiteSpace(to))
                {
                    foreach (var acc in cust.Accounts)
                    {

                        if (acc.AccountNumber == transferFrom)
                        {
                            acc.Balance =
                                        (Convert.ToDouble(acc.Balance) - Convert.ToDouble(balance)).ToString();

                        }

                        if (acc.AccountNumber == transferTo)
                        {
                            acc.Balance =
                                (Convert.ToDouble(acc.Balance) + Convert.ToDouble(balance)).ToString();
                        }


                    }
                    return "success";
                }
            }
            return null;
        }

        private static Account Deposit(string balance, string accountNumber)
        {
            foreach (var cust in customers)
            {
                foreach (var acc in cust.Accounts)
                {
                    if (acc.AccountNumber == accountNumber)
                    {
                        acc.Balance = (Convert.ToDouble(acc.Balance) + Convert.ToDouble(balance)).ToString();
                        return acc;

                    }
                }

            }

            return null;
        }

        private static Account WithdrawalFromAccount(string accountNumber, string balance)
        {
            foreach (var cust in customers)
            {
                foreach (var acc in cust.Accounts)
                {
                    if (acc.AccountNumber == accountNumber)
                    {
                        if (Convert.ToInt32(cust.Age) >= 18)
                        {
                            acc.Balance = (Convert.ToDouble(acc.Balance) - Convert.ToDouble(balance)).ToString();
                            return acc;
                        }

                    }
                }

            }

            return null;
        }

        private static Account GetAccountInformation(string accountNumber)
        {

            foreach (var cust in customers)
            {
                foreach (var acc in cust.Accounts)
                {
                    if (acc.AccountNumber == accountNumber)
                    {
                        return acc;
                    }
                }

            }
            return null;
        }

        private static void updateBalance(string balance, string accountNumber)
        {
            foreach (var acc in accounts)
            {
                if (acc.AccountNumber == accountNumber)
                {
                    acc.Balance = balance;
                }
            }
        }

        private static void addAccount(string accountType, string accountNumber)
        {
            Account account = new Account();
            account.AccountNumber = accountNumber;
            account.AccountType = accountType;
            account.Balance = "0.00";
            accounts.Add(account);

        }

        private static void addCustomer(List<Account> account, string name, string age, string password)
        {
            Customer customer = new Customer();
            customer.Name = name;
            customer.Age = age;
            customer.Password = password;
            customer.Accounts = account;
            customers.Add(customer);
            accounts = new List<Account>();
            account = new List<Account>();
        }

        private static Customer CheckUser(string accountNumber, string password)
        {
            if (customers.Count > 0)
            {
                foreach (var cust in customers)
                {
                    foreach (var acc in cust.Accounts)
                    {
                        if (acc.AccountNumber == accountNumber)
                        {
                            if (cust.Password == password)
                                return cust;
                        }
                    }
                }
            }
            return null;
        }
    }
}

