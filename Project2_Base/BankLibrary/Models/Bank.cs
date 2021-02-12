using System;
using System.Collections.Generic;
using System.Linq;
using BankLibrary.Interfaces;

namespace BankLibrary.Models
{
	public class Bank<T> where T : Account
	{
		public T[] accounts;

		public string Name { get; private set; }
		private IEventNotifier Notifier { get; }

		public decimal CreditPercentage;//Adding field Credit Percentage to Bank Class

		public Person person;

		
        

        public Bank(string name, IEventNotifier notifier, decimal CreditPercentage,Person person)
		{
			this.Name = name;
            Notifier = notifier;
			
			this.person = person;
			this.CreditPercentage = CreditPercentage;

		}

		
    
        // Open new account in bank
        public void Open(AccountType accountType, decimal sum, Bank<Account> linkedbank)
        {
			
				T newAccount = null;
				switch (accountType)
				{
					case AccountType.Ordinary:
						newAccount = new DemandAccount(sum, 1, Notifier,linkedbank,person) as T;
						break;
					case AccountType.Deposit:
						newAccount = new DepositAccount(sum, 40, Notifier,linkedbank,person) as T;
						break;
                    case AccountType.Loan:
                        newAccount = new CreditAccount(sum, 10, Notifier, linkedbank, person) as T;
					 
                        break;
            }

				if (newAccount == null)
					throw new Exception("Errors during account creation");


				// add new account to accounts collections     
				if (accounts == null)
					accounts = new T[] { newAccount };

				else
				{
					T[] tempAccounts = new T[accounts.Length+1];
					for (int i = 0; i < accounts.Length; i++)
						tempAccounts[i] = accounts[i];
					tempAccounts[^1] = newAccount;
					accounts = tempAccounts;
				}

				newAccount.Open();

		}
		
		//добавление средств на счет
		public void Put(decimal sum,Account account)
		{
            ////T account = FindAccount(id);

            if (account == null)
            {
                throw new Exception("404. Account not found!");
            }
            if (sum<100.0M)
            {
				throw new DepositingAmountException("404.Entered amount should be greater than 99");//Throwing Exception for putting money into the account less than specified amount
            }
			account.Put(sum);
		}
		// вывод средств
		public void Withdraw(decimal sum, int id)
		{

			T account = FindAccount(id);
			if (account == null)
				throw new Exception("404. Account not found!");
			account.Withdraw(sum);
		
			if (sum > 40000)
			{
				throw new WithdrawingExcessAmountException("404. Cannot withdraw more than 40000 in one time");//Throwing exception for withdrawing excess amount than specified

			}

		}
		public decimal Loan(decimal LoanAmount,  int NumberofMonths)
        {

			
            decimal answer = 0;

			//answer = (LoanAmount * CreditPercentage) / 1.0m - (decimal)(Math.Pow((double)((1.0m / 1.0m) + CreditPercentage), (double)((-1)*NumberofMonths)));

			answer = (LoanAmount * ((CreditPercentage + 100) / 100)) / NumberofMonths;
			 return answer;


        }


        public bool NoMoneyToTransfer(Account fromAccount, decimal transferAmount)
        {
            //T fromAccount = FindAccount(fromAccountId);
            //T toAccount = FindAccount(toAccountId);


            if (fromAccount.CurrentSum < transferAmount)
            {
                return true;
            }
            return false;

        }

		
        public bool Transfer(Account fromAccount, int toAccountId, decimal transferAmount)
        {
            if (transferAmount <= 0)
            {
                throw new ApplicationException("transfer amount must be positive");
            }
            else if (transferAmount == 0)
            {
                throw new ApplicationException("invalid transfer amount");
            }

            //T fromAccount = FindAccount(fromAccountId);
            T toAccount = FindAccount(toAccountId);

           

            fromAccount.Transfer(-1 * transferAmount);
            toAccount.Transfer(transferAmount);

            return true;


        }
		
		
        // закрытие счета
        public void Close(int id)
		{
			int index;
            T account = FindAccount(id, out index);

            if (account == null)
            {
                throw new Exception("404. Account not found!");
            }
				

			account.Close();

			if (accounts.Length <= 1)
				accounts = null;
			else
			{
                T[] tempAccounts = new T[accounts.Length - 1];
				for (int i = 0, j = 0; i < accounts.Length; i++)
				{
					if (i != index)
						tempAccounts[j++] = accounts[i];
				}
				accounts = tempAccounts;
			}
		}
		
		public void CalculatePercentage()
		{
            if (accounts == null)
            {
                return;
            }
				
			for (int i = 0; i < accounts.Length; i++)
			{
				T account = accounts[i];
				account.IncrementDays();
				account.Calculate();
			}
		}

        // Find account by id
		public T FindAccount(int id)
		{
			for (int i = 0; i < accounts.Length; i++)
			{
				if (accounts[i].Id == id)
					return accounts[i];
			}
			return null;
		}

		public T FindAccount(int id, out int index)
		{
			for (int i = 0; i < accounts.Length; i++)
			{
				if (accounts[i].Id == id)
				{
					index = i;
					return accounts[i];
				}
			}
			index = -1;
			return null;
		}

		public T Find(string AccountNumber) //Method for Finding the Account by Account number and returning the account
		{

			for (int i = 0; i < accounts.Length; i++)
			{
				if (accounts[i].accountNumber == AccountNumber)
					return accounts[i];
			}

			throw new Exception("404.Account Not Found");

		}

        public string FindAccountHolder(string AccountNumber) //Method for Finding the Account by Account number and returning the owners name
		{
			for (int i = 0; i < accounts.Length; i++)
			{

				if (accounts[i].accountNumber == AccountNumber)
				{
					var account = accounts[i];
					return account.person.Name;
				}
			}

			throw new Exception("404.Account Not Found");
	
        }

		public bool Noaccountstodisplay()
        {
			if (accounts == null)
			{
				return true;
			}
			return false;


		}
        public List<string> DisplayBankAccounts()//Method to display all accounts created in Bank
        {
			List<string> display = new List<string>();

				foreach (var account in accounts)
            {

				//return (account.accountNumber,account.person.Name).ToString(); 
				display.Add("Account Number:" + account.accountNumber +" "+ "Name:" + account.person.Name);

			}
			return display;
			throw new Exception("404.No Accounts to display");

		}






    }
}
