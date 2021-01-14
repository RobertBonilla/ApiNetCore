using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNetCore.Domain.Entities
{
    public class Customer
    {
        public int CtmId { get; set; }
        public string CtmName { get; set; }
        public string CtmLastName { get; set; }
        public string CtmDate { get; set; }
        public string CtmDirection { get; set; }
        public string CtmTelephone { get; set; }
        public string CtmEmail { get; set; }
        public string CreatedAt { get; set; }
    }
}
