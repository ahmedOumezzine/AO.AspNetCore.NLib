using AO.AspNetCore.NLib;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;

namespace AO.Nlib.Demo.Models
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }
        public int EmpId
        {
            get;
            set;
        }
        public string Name
    {
        get;
        set;
    }
    public int Salary
    {
        get;
        set;
    }
    public string Address
    {
        get;
        set;
    }
}
 

public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}