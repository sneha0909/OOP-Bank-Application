using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary.Models
{
    class DepositingAmountException : Exception
    {
        public DepositingAmountException()
        {


        }
        public DepositingAmountException(string message)
           : base(message)
        {
        }



    }
}
