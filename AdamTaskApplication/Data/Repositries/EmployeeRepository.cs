using AdamTaskApplication.Data.Interfaces;
using AdamTaskApplication.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdamTaskApplication.Data.Repositries
{
    public class EmployeeRepository : Repository<Employee> , IEmployee
    {
        public EmployeeRepository( MainContext context) :base(context)
        {

        }
    }
}
