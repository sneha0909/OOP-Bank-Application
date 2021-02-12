using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary.Models
{
    public class Person //Created Person Class with following fields
    {

            public String Name { get; set; }
            public int Age { get; set; }
            public int Insurance_Number { get; set; }
            public ulong Phone { get; set; }
            public string Email { get; set; }

            public Person(string name,int age,int insurance_number,ulong phone,string email)
            {
            this.Name = name;
            this.Age = age;
            this.Insurance_Number = insurance_number;
            this.Phone = phone;
            this.Email = email;



            }



    }



}
