using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary.Models
{
    class WithdrawingExcessAmountException:Exception
    {
        public WithdrawingExcessAmountException()
        {

        }
        public WithdrawingExcessAmountException(string message)
           : base(message)
        {
        }



    }
}
