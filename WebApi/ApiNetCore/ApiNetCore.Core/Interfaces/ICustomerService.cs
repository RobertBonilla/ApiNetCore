using System;
using System.Collections.Generic;
using System.Text;
using ApiNetCore.Core.Dtos.Entities;
using ApiNetCore.Core.Dtos.Responses;

namespace ApiNetCore.Core.Interfaces
{
    public interface ICustomerService
    {
        CustomerResponse CustomerList();
        ResponseStatus CustomerAdd(Customer customer);
        Customer CustomerEditGet(int ctmId);
        ResponseStatus CustomerEdit(Customer customer);
        ResponseStatus CustomerDelete(int ctmId);
    }
}
