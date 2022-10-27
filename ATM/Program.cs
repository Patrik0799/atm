using System;
using System.Security;

public class cardHolder
{
    string cardNumber;
    int PIN;
    string firstName;
    string lastName;
    double balance;

    public cardHolder(string cardNumber, int PIN, string firstName, string lastName, double balance)
    {
        this.cardNumber = cardNumber;
        this.PIN = PIN;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    public string getNum()
    {
        return cardNumber;
    }

    public int getPIN()
    {
        return PIN;
    }

    public string getFirstName()
    { 
        return firstName;
    }

    public string getLastName()
    {
        return lastName;
         
    }

    public double getBalance()
    { 
        return balance;
    }

    public void setNum(string newNumber)
    {
        cardNumber = newNumber;
    }
    public void setPIN(int newPIN)
    {
        PIN = newPIN;
    }
    public void setFirstName(string newFirstName)
    {
        firstName = newFirstName;   
    }
    public void setLastName(string newLastName)
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
            Console.WriteLine("Choose one of the following options...");
            Console.WriteLine("1.Deposit");
            Console.WriteLine("2.Withdraw");
            Console.WriteLine("3.Show Balance");
            Console.WriteLine("4.Exit");
        }
        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to deposit?");
            double balance = Double.Parse(Console.ReadLine());
            currentUser.setBalance(balance + currentUser.getBalance());
            Console.WriteLine("Thank you for your deposit! Your current deposit is: " + currentUser.getBalance());
        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to withdraw?");
            double withdrawal = Double.Parse(Console.ReadLine());

            if (withdrawal > currentUser.getBalance())
            {
                Console.WriteLine("Sorry...you can't withdraw that much");
            }
            else { 
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("Aight! There you go");
            }
        }

        void balance (cardHolder currentUser)
        {
            Console.WriteLine("Your current balance is: " + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("07", 1234, "Patrik", "Zelenika", 732.21));
        cardHolders.Add(new cardHolder("12", 1573, "Robert", "Sostar", 345.15));
        cardHolders.Add(new cardHolder("10", 2657, "Marko", "Cirjak", 1025.98));
        cardHolders.Add(new cardHolder("08", 5743, "Lovre", "Gobin", 144.66));

        Console.WriteLine("Welcome to the ATM!");
        Console.WriteLine("Please insert a card number: ");
        string cardnumber = "";
        cardHolder currentUser;

        while (true)
        {
            try
            {
                cardnumber = Console.ReadLine();
                currentUser = cardHolders.FirstOrDefault(a => a.cardNumber == cardnumber);
                if (currentUser != null) { break; }
                else { Console.WriteLine("Incorrect Card Number...try again"); } 
            }
            catch { Console.WriteLine("Incorrect Card Number...try again"); }
        }

        Console.WriteLine("Please enter your PIN: ");
        int userPin = 0;

        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                if (currentUser.getPIN() == userPin) { break; }
                else { Console.WriteLine("Incorrect PIN...try again"); }
            }
            catch { Console.WriteLine("Incorrect Card Number...try again"); }
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
           
            switch (option)
            {
                case 1:
                    deposit(currentUser);
                    break;
                case 2:
                    withdraw(currentUser);
                    break;
                case 3:
                    balance(currentUser);
                    break;
                case 4:
                    break;
                default:
                    option = 0;
                    break;
            }

            /*if (option == 1) { deposit(currentUser); }
           else if (option == 2) { withdraw(currentUser); }
           else if (option == 3) { balance(currentUser); }
           else if (option == 4) { break; }
           else { option = 0; }*/

        }
        while (option != 4);
        Console.WriteLine("Thank you! Have a nice a day :)");

    }


}