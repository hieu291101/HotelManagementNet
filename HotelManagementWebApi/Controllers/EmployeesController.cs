using HotelManagementWebApi.BLL;
using HotelManagementWebApi.Common.Param;
using HotelManagementWebApi.Common.Req;
using HotelManagementWebApi.Common.Rsp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private EmployeeSvc employeeSvc;
        public EmployeesController()
        {
            employeeSvc = new EmployeeSvc();
        }
        [HttpGet("{id}")]
        public IActionResult GetEmployee(int id)
        {
            var res = new SingleRsp();
            res = employeeSvc.Read(id);
            if (res == null)
                NotFound();
            return Ok(res);
        }

        [HttpGet("employeeByNumberPhone")]
        public IActionResult GetEmployeeByNumberPhone(string numberPhone)
        {

            var res = new SingleRsp();
            res = employeeSvc.getEmployeeByNumberPhone(numberPhone);
            if (res == null)
                NotFound();
            return Ok(res);
        }

        [HttpGet("roomByNumberPhone")]
        public IActionResult GetRoomByNumberPhone(string numberPhone)
        {

            var res = new SingleRsp();
            res = employeeSvc.getRoomByNumberPhone(numberPhone);
            if (res == null)
                NotFound();
            return Ok(res);
        }

        [HttpPost("employeeLogin")]
        public IActionResult GetGuestLogin(EmployeeParameters employeeParameters)
        {

            var res = new SingleRsp();
            res = employeeSvc.getEmployeeLogin(employeeParameters);
            if (res == null)
                NotFound();
            return Ok(res);
        }


        [HttpPost("createEmployee")]
        public IActionResult CreateEmployee([FromBody] EmployeeReq employeeReq)
        {
            var res = new SingleRsp();
            res = employeeSvc.CreateEmployee(employeeReq);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, [FromBody] EmployeeReq employeeReq)
        {
            var res = new SingleRsp();

            try
            {
                if (id != employeeReq.EmployeeId)
                    return BadRequest("Employee ID mismatch");

                var employee = employeeSvc.ReadModel(id).Data;

                if (employee == null)
                {
                    return NotFound($"Employee with ID = {id} not found");
                }

                res = employeeSvc.UpdateEmployee(employeeReq);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
            }

            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var res = new SingleRsp();

            try
            {
                var employee = employeeSvc.Read(id).Data;

                if (employee == null)
                {
                    return NotFound($"Employee with ID = {id} not found");
                }

                res = employeeSvc.DeleteEmployee(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
            }

            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }


    }
}
