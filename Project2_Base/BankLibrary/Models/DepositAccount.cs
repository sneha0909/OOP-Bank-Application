﻿using BankLibrary.Interfaces;

namespace BankLibrary.Models
{
	public class DepositAccount : Account
	{
		public DepositAccount(decimal sum, int percentage, IEventNotifier notifier , Bank<Account> linkedbank,Person person) : base(sum, percentage, notifier , linkedbank,person)
		{
		}
        protected internal override void Open()
        {

            Notifier.NotifyAboutEventByType(EventType.AccountOpen, $"Opened new Deposit account! Id: {this.id}");
        }

        public override void Put(decimal sum)
        {
            if (Days % 30 == 0)
                base.Put(sum);
            else
                Notifier.NotifyAboutEventByType(EventType.MoneyPut, "You can add money only after 30 days since account was opened!");
        }

        public override decimal Withdraw(decimal sum)
        {
            if (Days % 30 == 0)
                return base.Withdraw(sum);

            Notifier.NotifyAboutEventByType(EventType.Withdraw, "You can withdraw money only after 30 days since account was opened!");
            return 0;
        }

        protected internal override void Calculate()
        {
            if (Days % 30 == 0)
                base.Calculate();
        }
    }
}
