using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using ApiNetCore.Core.Dtos.Entities;
using ApiNetCore.Core.Dtos.Responses;
using ApiNetCore.Core.Interfaces;
using ApiNetCore.Infraestructure.Interfaces;
using AutoMapper;

namespace ApiNetCore.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;
        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }
        public ResponseStatus CustomerAdd(Customer customer)
        {
            var CustomerDomain = Mapper.Map<Dtos.Entities.Customer, Domain.Entities.Customer>(customer);
            CustomerDomain.CreatedAt = customer.CreatedAt.ToString("yyyy-MM-dd");
            CustomerDomain.CtmDate = customer.CtmDate.ToString("yyyy-MM-dd");
            var result = _repository.CustomerAdd(CustomerDomain);
            return Mapper.Map<Domain.Responses.ResponseStatus, Dtos.Responses.ResponseStatus>(result);
        }

        public CustomerResponse CustomerList()
        {            
            var result = _repository.CustomerList();
            return Mapper.Map<Domain.Responses.CustomerResponse, Dtos.Responses.CustomerResponse>(result);
        }

        public ResponseStatus CustomerDelete(int ctmId)
        {
            var result = _repository.CustomerDelete(ctmId);
            return Mapper.Map<Domain.Responses.ResponseStatus, Dtos.Responses.ResponseStatus>(result);
        }

        public ResponseStatus CustomerEdit(Customer customer)
        {
            var CustomerDomain = Mapper.Map<Dtos.Entities.Customer, Domain.Entities.Customer>(customer);
            CustomerDomain.CreatedAt = customer.CreatedAt.ToString("yyyy-MM-dd");
            CustomerDomain.CtmDate = customer.CtmDate.ToString("yyyy-MM-dd");
            var result = _repository.CustomerEdit(CustomerDomain);
            return Mapper.Map<Domain.Responses.ResponseStatus, Dtos.Responses.ResponseStatus>(result);
        }

        public Customer CustomerEditGet(int ctmId)
        {
            var result = _repository.CustomerEditGet(ctmId);
            var Customer = Mapper.Map<Domain.Entities.Customer, Dtos.Entities.Customer>(result);
            if (Customer.CtmId == 0)
            {
                return null;
            }
            if(result.CreatedAt != null)
            {
                Customer.CreatedAt = (!result.CreatedAt.Equals("")) ? Convert.ToDateTime(result.CreatedAt) : Customer.CreatedAt;
            }
            if(result.CtmDate != null)
            {
                Customer.CtmDate = (!result.CtmDate.Equals("")) ? Convert.ToDateTime(result.CtmDate) : Customer.CtmDate;
            }            
            return Customer;
        }
    }
}
