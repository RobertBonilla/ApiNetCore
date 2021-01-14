using ApiNetCore.Core.Dtos.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNetCore.Core.Dtos.Responses
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
