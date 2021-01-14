using System;
using System.Collections.Generic;
using System.Text;
using ApiNetCore.Domain.Entities;

namespace ApiNetCore.Domain.Responses
{
    public class CustomerResponse
    {
        public CustomerResponse()
        {
            AllCustomer = new List<Customer>();
            ResponseStatus = new ResponseStatus();
        }
        public List<Customer> AllCustomer { get; set; }
        public ResponseStatus ResponseStatus { get; set; }
    }
}
