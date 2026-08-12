using ElevatorApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ElevatorApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ElevatorController : ControllerBase
    {
        // Simple in-memory elevator instance shared across requests (demo purposes only).
        private static readonly Elevator SharedElevator = new(maxWeightAllowed: 200);

        public record EmployeeDto(string Name, int Weight, bool IsExecutive);

        public record ElevatorStatusDto(int MaxWeightAllowed, int CurrentWeight, bool MaxWeightAllowedReached);

        [HttpGet("status")]
        public ActionResult<ElevatorStatusDto> GetStatus()
        {
            return Ok(new ElevatorStatusDto(
                SharedElevator.MaxWeightAllowed,
                SharedElevator.CurrentWeight,
                SharedElevator.CheckMaxWeightAllowedReached()));
        }

        [HttpPost("in")]
        public ActionResult<ElevatorStatusDto> InUser([FromBody] EmployeeDto employeeDto)
        {
            var employee = new Employee
            {
                Name = employeeDto.Name,
                Weight = employeeDto.Weight,
                IsExecutive = employeeDto.IsExecutive
            };

            SharedElevator.InUser(employee);
            return Ok(new ElevatorStatusDto(
                SharedElevator.MaxWeightAllowed,
                SharedElevator.CurrentWeight,
                SharedElevator.CheckMaxWeightAllowedReached()));
        }

        [HttpPost("out")]
        public ActionResult<ElevatorStatusDto> OutUser([FromBody] EmployeeDto employeeDto)
        {
            var employee = new Employee
            {
                Name = employeeDto.Name,
                Weight = employeeDto.Weight,
                IsExecutive = employeeDto.IsExecutive
            };

            SharedElevator.OutUser(employee);
            return Ok(new ElevatorStatusDto(
                SharedElevator.MaxWeightAllowed,
                SharedElevator.CurrentWeight,
                SharedElevator.CheckMaxWeightAllowedReached()));
        }

        [HttpPost("vip-section")]
        public ActionResult<bool> GoToVipSection([FromBody] EmployeeDto employeeDto)
        {
            var employee = new Employee
            {
                Name = employeeDto.Name,
                Weight = employeeDto.Weight,
                IsExecutive = employeeDto.IsExecutive
            };

            return Ok(SharedElevator.GoToVipSection(employee));
        }
    }
}
