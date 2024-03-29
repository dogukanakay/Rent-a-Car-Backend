﻿using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        public IResult Add(Customer customer);
        public IResult Delete(Customer customer);
        public IResult Update(Customer customer);
        public IDataResult<List<Customer>> GetAll();
        public IDataResult<List<CustomerDetailDto>> GetCustomerDetails();
        public IDataResult<int>GetCustomerIdByUserId(int userId);

        public IDataResult<Customer> GetByCustomerId(int customerId);
     
    }
}
