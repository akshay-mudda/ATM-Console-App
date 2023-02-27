using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Console_App
{
    internal class Program
    {
        public class cardHolder
        {
            String cardNum;
            int pin;
            String firstName;
            String lastName;
            double balance;

            public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
            {
                this.cardNum = cardNum;
                this.pin = pin;
                this.firstName = firstName;
                this.lastName = lastName;
                this.balance = balance;
            }

            public int getPin()
            {
                return pin;
            }

            public String getFirstName()
            {
                return firstName;
            }
            public String getLastName()
            {
                return lastName;
            }
            public double getBalance()
            {
                return balance;
            }
            public void setNum(String newCardNum)
            {
                cardNum = newCardNum;
            }
            public void setPin(int newPin)
            {
                pin = newPin;
            }
            public void setFirstName(String newFirstName)
            {
                firstName = newFirstName;
            }
            public void setLastName(String newLastName)
            {
                lastName = newLastName;
            }
            public void setBalance(double newBalance)
            {
                balance = newBalance;
            }

            public static void Main(string[] args)
            {
                void printOptions()
                {
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine("Please Choose an option from the following: ");
                    Console.WriteLine("1. Deposit");
                    Console.WriteLine("2. Withdraw");
                    Console.WriteLine("3. Show Balance");
                    Console.WriteLine("4. Exit");
                }

                void deposit(cardHolder CurrentUser)
                {
                    Console.WriteLine("How much would you like to deposit?");
                    double Deposit = Double.Parse(Console.ReadLine());
                    CurrentUser.setBalance(CurrentUser.getBalance() + Deposit);
                    Console.WriteLine("Thank You for investing $$. Your current balance is: " + CurrentUser.getBalance());
                }

                void withdraw(cardHolder CurrentUser)
                {
                    Console.WriteLine("How much you are going to withdraw: ");
                    double withdrawl = Double.Parse(Console.ReadLine());
                    //check if user has money
                    if (CurrentUser.getBalance() < withdrawl)
                    {
                        Console.WriteLine("Insufficient Balance!");
                    }
                    else
                    {
                        CurrentUser.setBalance(CurrentUser.getBalance() - withdrawl);
                        Console.WriteLine("You are good to go. Thank You!");
                    }
                }
                void balance(cardHolder CurrentUser)
                {
                    Console.WriteLine("Current Balance: " + CurrentUser.getBalance());
                }

                List<cardHolder> cardHolders = new List<cardHolder>();
                cardHolders.Add(new cardHolder("1234567887654321", 1234, "Akshay", "Mudda", 50000.00));
                cardHolders.Add(new cardHolder("9876543212345678", 5678, "Harsha", "Vardhan", 100000.00));
                cardHolders.Add(new cardHolder("7852804454131214", 4756, "Adarsh", "Satya", 40000.00));
                cardHolders.Add(new cardHolder("2001200414315531", 9012, "Keshav", "Chukka", 25000.00));
                cardHolders.Add(new cardHolder("9339901092939094", 2014, "Sayeesh", "Boddu", 5000.00));

                //prompt user
                Console.WriteLine("HII!  Welcome to Simple ATM :)");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Please insert your debit card: ");
                string debitCardNum = "";
                cardHolder currentUser;

                while (true)
                {
                    try
                    {
                        debitCardNum = Console.ReadLine();
                        //check against our DB
                        currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                        if (currentUser != null) { break; }
                        else { Console.WriteLine("Card not recognised. Please try again!"); }
                    }
                    catch { Console.WriteLine("Card not recognised. Please try again!"); }
                }
                Console.WriteLine("Please enter your pin: ");
                int userPin = 0;

                while (true)
                {
                    try
                    {
                        userPin = int.Parse(Console.ReadLine());
                        //check against our DB
                        if (currentUser.getPin()==userPin) { break; }
                        else { Console.WriteLine("Incorrect Pin. Please try again!"); }
                    }
                    catch { Console.WriteLine("Incorrect Pin. Please try again!"); }
                }

                Console.WriteLine("Welcome " + currentUser.getFirstName() + " :)");
                int option = 0;
                do
                {
                    printOptions();
                    try
                    {
                        option = int.Parse(Console.ReadLine());
                    }
                    catch { }
                    if(option == 1) { deposit(currentUser); }
                    else if(option==2) { withdraw(currentUser); }
                    else if (option == 3) { balance(currentUser); }
                    else { option = 4; }
                }
                while (option != 4);
                Console.WriteLine("                                      ");
                Console.WriteLine("Thank You! Have a nice day :)");
                Console.WriteLine("                                      ");
                Console.WriteLine("--Created by Akshay");
            }   
        }
    }
}
