using BankLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary.Models
{
    public class CreditAccount:Account
    {
        public CreditAccount(decimal sum, int percentage, IEventNotifier notifier, Bank<Account> linkedbank, Person person)
            : base(sum*-1.0M, percentage, notifier, linkedbank, person)
        {

        }


        protected internal override void Open()
        {
            base.Open();
            Notifier.NotifyAboutEventByType(EventType.AccountOpen, $"balance : {this.Sum}");
        }


        public override void Loan(decimal LoanAmount)
        {
            base.Loan(LoanAmount);
        }





    }
}
