using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountManagementSystem{
    class Account {

        private string name;
        private string address;
        private decimal balance;
        private int accountNumber;// private variable visible only to the AccountNumber method


        public override string ToString(){ //Overrided function which means that this function existed as the function whit the same name but different outcome 
        
            return "Account: " + accountNumber +
                "Name: " + name +
                "Adress: " + address +
                "Balance: " + balance;
        }


        public int AccountNumber { //Get function (Dank stuff(shit))
            get
            {
                return accountNumber;
            }
        }

        public bool Save(System.IO.TextWriter textOut) { //Saving the Account info into stream whit the try - catch methodes in it whick dont return info about the error(Dank as well)
            try
            {
                textOut.WriteLine(accountNumber);
                textOut.WriteLine(name);
                textOut.WriteLine(address);
                textOut.WriteLine(balance);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public void Save(string filename){ //Using the Save method to check for errors and dispplay them if they are found and if not closing the file (textOut.close())        
            System.IO.TextWriter textOut = null;
            try
            {
                textOut = new System.IO.StreamWriter(filename);
                Save(textOut);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (textOut != null) textOut.Close();
            }
        }

        public static Account Load(System.IO.TextReader textIn){ //Loading from the file into the Account       
            int accountNumber = int.Parse(textIn.ReadLine());
            string nameText = textIn.ReadLine();
            string addressText = textIn.ReadLine();
            string balanceText = textIn.ReadLine();
            decimal balanceValue = decimal.Parse(balanceText);
            return new Account(nameText, addressText, balanceValue, accountNumber);
        }

        public static Account Load(string filename){ //Using the Load method to check for errors and closing the textIn file
            Account result;
            System.IO.TextReader textIn = null;
            try
            {
                textIn = new System.IO.StreamReader(filename);
                result = Load(textIn);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (textIn != null) textIn.Close();
            }
            return result;
        }

        public Account(string inName, string inAddress, decimal inBalance, int inAccountNumber) {//Creating the Account
            name = inName;
            address = inAddress;
            balance = inBalance;
            accountNumber = inAccountNumber;
        }

        public override bool Equals(object obj) {//Overriding the default Equals method to suite the Account atributes (Dank!!!)
       
            Account compateWith = (Account)obj;
            //Comparing name from the first account whit the names in the second, and if the same names are found the method returns true
            if (name != compateWith.name) {
                return false;
            }
            if (address != compateWith.address) {
                return false;
            }

            return true;
        }
    }

    class Bank {       
        private string bankName; //Private string visible only to the BankName method

        public string BankName { //GetName method that returns the name of the bank
            get
            {
                return bankName;
            }
        }

        private List<Account> bankAccounts;//Creating the list for the Accounts Class that we are using now in the Bank class
        static int newAccountNumber = 1;

        public Bank(string newBankName) { //Setting the name of a bank
            bankName = newBankName;
            bankAccounts = new List<Account>();
        }

        public Account AddAccount(string inName, string inAddress, decimal inBalance) { //Adding an account to the bank
            Account result = new Account(inName, inAddress, inBalance, newAccountNumber);
            bankAccounts.Add(result);
            newAccountNumber = newAccountNumber + 1;
            return result;
        }
        public Account FindAccount(int searchNumber) { //Finding method that searches for the given number of the account
            foreach (Account a in bankAccounts) {
                if (a.AccountNumber == searchNumber)
                    return a;
            }
            return null;
        }

        public int NumberOFAccounts(){ //Method that returns the number of the accounts in the bank
            int counter = 0;
            for (int i = 0; i < bankAccounts.Count; i++){
                counter++;
            }
            return counter;
        }

        public override string ToString(){ //Overrided function for the needs of the Bank Class
            return "Bank name: " + bankName +
                "Number of accounts: " + NumberOFAccounts();
        }

        public bool DeleteAccount(int deleteNumber){ //Function for deleting the account from the Bank by the given AccountNumber (deleteNumber)
            Account del = FindAccount(deleteNumber);
            if (del != null){
                bankAccounts.Remove(del);
                return true;
            }
            return false;
        }

        public void Save(System.IO.TextWriter textOut){ //Saving the accounts in the bank
            textOut.WriteLine(bankName);
            textOut.WriteLine(newAccountNumber);
            textOut.WriteLine(bankAccounts.Count);
            foreach (Account a in bankAccounts){ //For each Account in bankAccounts
                if (a != null){
                    a.Save(textOut);
                }
            }
        }

        public void Save(string filename){ //Using the Save metohd to check for errors and closing the textOut file
            System.IO.TextWriter textOut = null;
            try
            {
                textOut = new System.IO.StreamWriter(filename);
                Save(textOut);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (textOut != null) textOut.Close();
            }
        }

        public static Bank Load(System.IO.TextReader textIn){ //Loading accounts into the bank from a file
            string bankName = textIn.ReadLine();
            Bank result = new Bank(bankName);
            newAccountNumber = int.Parse(textIn.ReadLine());
            int numberOfAccounts = int.Parse(textIn.ReadLine());
            for (int i = 0; i < numberOfAccounts; i++){
                Account a = Account.Load(textIn);
                result.bankAccounts.Add(a);
            }
            return result;
        }

        public static Bank Load(string filename){ //Using the load method to check for errors and close the textIn file 
            Bank result;
            System.IO.TextReader textIn = null;
            try
            {
                textIn = new System.IO.StreamReader(filename);
                result = Load(textIn);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (textIn != null) textIn.Close();
            }
            return result;
        }
    }
        

    class Program{
        static void Main(string[] args)
        {
            Bank friendlyBank = new Bank("The Dead³ine's Bank");
            //Creating accounts for the bank
            string[] firstNames = new string[] { "ivan", "Ivica", "Isus", "xD", "lucija", "jana", "Gloria", "marica" };
            string[] surnames = new string[] { "ivic", "ivancic","krist", "Dx", "lucijic", "todoric", "gloric", "maric" };

            foreach (string surname in surnames)
            {
                foreach (string firstname in firstNames){ //Combining the above firstnames and surnames for the sake of filling the Bank whit Bank accounts 
                    Console.WriteLine(firstname + " " + surname);
                }
            }
            Account Rok = friendlyBank.AddAccount("Rok", "Grgec", 1000);
            Account Kor = friendlyBank.AddAccount("Rok", "Grgec", 1000);

            if (Rok.Equals(Kor)){ //This part goes trough the file and looks if there are more than 1 accounts whit the same atributes but differents class names, in this case Robs and Bobs account
                Console.WriteLine("Success!");
            }
            else {
                Console.WriteLine("Fail!");
            }
            Console.WriteLine("Account created with account number: " + Rok.AccountNumber);
            friendlyBank.Save("test.txt");
            Bank loadedBank = Bank.Load("test.txt");
        }
    }
}
