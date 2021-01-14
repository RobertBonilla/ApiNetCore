using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiNetCore.Core.Interfaces;
using ApiNetCore.Core.Dtos.Entities;

namespace ApiNetCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;
        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _service.CustomerList().AllCustomer;
            return Ok(model);
        }

        [HttpGet("{ctmId}")]
        public IActionResult Get(int ctmId)
        {
            var model = _service.CustomerEditGet(ctmId);
            return Ok(model);
        }
        [HttpPost("Add")]
        public IActionResult AddCustomer(Customer customer)
        {
            var model = _service.CustomerAdd(customer);
            return Ok(model);
        }
        [HttpPost("Edit")]
        public IActionResult EditCustomer(Customer customer)
        {
            var model = _service.CustomerEdit(customer);
            return Ok(model);
        }
        [HttpDelete("{ctmId}")]
        public IActionResult Delete(int ctmId)
        {
            var model = _service.CustomerDelete(ctmId);
            return Ok(model);
        }
    }
}
