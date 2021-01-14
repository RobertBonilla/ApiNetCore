using System;
using System.Collections.Generic;
using System.Text;
using ApiNetCore.Domain.Entities;
using ApiNetCore.Domain.Responses;

namespace ApiNetCore.Infraestructure.Interfaces
{
    public interface ICustomerRepository
    {
        CustomerResponse CustomerList();
        ResponseStatus CustomerAdd(Customer customer);
        Customer CustomerEditGet(int ctmId);
        ResponseStatus CustomerEdit(Customer customer);
        ResponseStatus CustomerDelete(int ctmId);
    }
}
