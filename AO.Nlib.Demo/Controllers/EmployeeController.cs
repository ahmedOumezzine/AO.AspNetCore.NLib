using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AO.AspNetCore.NLib;
using AO.Nlib.Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace AO.Nlib.Demo.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork repo;

        public EmployeeController(IUnitOfWork repo)
        {
            this.repo = repo;
        }
        public List<Employee> GetEmployee()
        {
          return repo.Repository<Employee>().GetAll();
          
        }
     
    }
}