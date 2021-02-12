using BankLibrary.Interfaces;
using BankLibrary.Services;
using System.Buffers.Text;

namespace BankLibrary.Models
{
	public class DemandAccount : Account
	{
		public DemandAccount(decimal sum, int percentage, IEventNotifier notifier, Bank<Account> linkedbank,Person person) 
            : base(sum, percentage, notifier,linkedbank,person)
		{
		}

		protected internal override void Open()
		{

			Notifier.NotifyAboutEventByType(EventType.AccountOpen, $"Opened new Classic account! Id: {this.id}");
			

		}
		
	}
}
