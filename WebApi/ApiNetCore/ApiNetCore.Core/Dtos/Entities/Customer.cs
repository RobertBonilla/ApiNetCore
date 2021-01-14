using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNetCore.Core.Dtos.Entities
{
    public class Customer
    {
        public Customer()
        {
            CreatedAt = DateTime.Now;
        }
        public int CtmId { get; set; }
        public string CtmName { get; set; }
        public string CtmLastName { get; set; }
        public DateTime CtmDate { get; set; }
        public string CtmDirection { get; set; }
        public string CtmTelephone { get; set; }
        public string CtmEmail { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
