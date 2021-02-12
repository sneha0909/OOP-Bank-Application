using BankLibrary.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace BankLibrary.Models
{
	public abstract class Account : IAccount
	{
		protected readonly int id;
		protected readonly IEventNotifier Notifier;
		public static int Counter = 0;
		protected decimal Sum;
		protected readonly int percentage;

		protected int Days = 0; // Days since account is created

		public Person person;//Add a link of person to Account Class 

		protected Bank<Account> Linkedbank;
		protected readonly string AccountNumber; //creating a field AccountNumber
		protected readonly decimal transferAmount;
		public decimal loanAmount;
		public int NumberofMonths;
		public decimal MonthlyPayment;
		public decimal creditPercentage;



		public Account()//Generating a random Account Number
		{
			var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
			var stringChars = new char[8];
			Random r = new Random();
			for (int i = 0; i < stringChars.Length; i++)
			{
				stringChars[i] = chars[r.Next(chars.Length)];
			}

			AccountNumber = new String(stringChars);

		}

		
		public Account(decimal sum, int percentage, IEventNotifier notifier,Bank<Account>linkedbank,Person person)
		{
			Sum = sum;
			this.percentage = percentage;
			id = ++Counter;
            Notifier = notifier;
			Linkedbank = linkedbank;
			this.person = person;
			
			
		
			
			var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
			var stringChars = new char[8];
			Random r = new Random();
			for (int i = 0; i < stringChars.Length; i++)
			{
				stringChars[i] = chars[r.Next(chars.Length)];
			}

			AccountNumber = new String(stringChars);
		}

		// Current money amount
		public decimal CurrentSum => Sum;

        public int Percentage => percentage;

        public int Id => id;

		public string accountNumber => AccountNumber;

		public decimal LoanAmount => loanAmount;

		

        public virtual void Put(decimal sum)
		{
			Sum += sum;
			Notifier.NotifyAboutEventByType(EventType.MoneyPut, $"Added to account {sum}");
        }
		public virtual decimal Withdraw(decimal sum)
		{
			decimal result = 0;
			
			if (sum <= Sum)
			{
				Sum -= sum;
				result = sum;
                Notifier.NotifyAboutEventByType(EventType.Withdraw, $"Amount {sum} withdrawed from account {id}");
            }
			
			else
			{
                Notifier.NotifyAboutEventByType(EventType.Withdraw, $"Not enough money in account {id}");
            }
			return result;
		}


		public virtual void Loan(decimal LoanAmount)
		{
			decimal result = 0;
			if (LoanAmount>=1000)
            {
				Sum += LoanAmount;
				result = Sum;

            }
            else
            {

				Notifier.NotifyAboutEventByType(EventType.LoanAccount, $"To take Loan the amount should be greater than 1000 {id}");
			}



		}


		public virtual void Transfer(decimal transferAmount)
        {
		
            if (Sum > transferAmount)
            {
                Sum += transferAmount;

                Notifier.NotifyAboutEventByType(EventType.FundTransfer, $"Amount {transferAmount} transfered to account {id}");
            }
            

			
        }
		

        // Opening account
        protected internal virtual void Open()
		{
            Notifier.NotifyAboutEventByType(EventType.AccountOpen, $"New account is opened! Id: {id}");
        }

        
        // Closing account
        protected internal virtual void Close()
		{
            Notifier.NotifyAboutEventByType(EventType.AccountClose, $"Account {id} is closed. Total amount: {CurrentSum}");
        }

		protected internal void IncrementDays()
		{
			Days++;
		}

		// Percentage
		protected internal virtual void Calculate()
		{
			var increment = Sum * percentage / 100;
			Sum = Sum + increment;
            Notifier.NotifyAboutEventByType(EventType.MoneyCalculation, $"Money added after percentages calculations: {increment}");
        }

		



	}
}
