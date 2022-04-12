﻿using Microsoft.AspNetCore.Mvc;
using GoilGasStation.Model;
using GoilGasStation.EF.Repositories;
using GoilGasStation.Blazor.Shared.ViewModels;

namespace RedMotors.Blazor.Server.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEntityRepo<Employee> _employeeRepo;
        public EmployeeController(IEntityRepo<Employee> customerRepo)
        {
            _employeeRepo = customerRepo;
        }
        [HttpGet]
        public async Task<IEnumerable<EmployeeViewModel>> Get()
        {
            var result = await _employeeRepo.GetAllAsync();
            return result.Select(employee => new EmployeeViewModel
            {
                ID = employee.ID,
                Name = employee.Name,
                Surname = employee.Surname,
                EmployeeType = employee.EmployeeType,
                SalaryPerMonth = employee.SalaryPerMonth,
                HireDateStart = employee.HireDateStart,
                HireDateEnd = employee.HireDateEnd


            });
        }
        [HttpGet("{id}")]
        public async Task<EmployeeEditViewModel> Get(Guid id)
        {
            EmployeeEditViewModel model = new();
            if (id != Guid.Empty)
            {
                var existingEmployee = await _employeeRepo.GetByIdAsync(id);
                model.ID = existingEmployee.ID;
                model.Name = existingEmployee.Name;
                model.Surname = existingEmployee.Surname;
                model.EmployeeType = existingEmployee.EmployeeType;
                model.SalaryPerMonth = existingEmployee.SalaryPerMonth;
                model.HireDateStart = existingEmployee.HireDateStart;
                model.HireDateEnd = existingEmployee.HireDateEnd;
            }
            return model;
        }
        [HttpPost]
        public async Task Post(EmployeeEditViewModel employee)
        {
            var newEmployee = new Employee
            {
                Name = employee.Name,
                Surname = employee.Surname,
                EmployeeType = employee.EmployeeType,
                SalaryPerMonth = employee.SalaryPerMonth,
                HireDateStart = employee.HireDateStart,
                HireDateEnd = employee.HireDateEnd
            };
            await _employeeRepo.CreateAsync(newEmployee);
        }


        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _employeeRepo.DeleteAsync(id);
        }

        [HttpPut]
        public async Task<ActionResult> Put(EmployeeEditViewModel employee)
        {
            var employeeToUpdate = await _employeeRepo.GetByIdAsync(employee.ID);
            if (employeeToUpdate == null) return NotFound();
            employeeToUpdate.Name = employee.Name;
            employeeToUpdate.Surname = employee.Surname;
            employeeToUpdate.EmployeeType = employee.EmployeeType;
            employeeToUpdate.SalaryPerMonth = employee.SalaryPerMonth;
            employeeToUpdate.HireDateStart = employee.HireDateStart;
            employeeToUpdate.HireDateEnd = employee.HireDateEnd;
            await _employeeRepo.UpdateAsync(employee.ID, employeeToUpdate);
            return Ok();
        }
    }
}