using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace Bank
{
    public class Customer
    {
        public List<Account> Accounts { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }

    }
}