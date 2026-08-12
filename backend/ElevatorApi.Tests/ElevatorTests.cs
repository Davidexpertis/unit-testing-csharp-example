using ElevatorApi.Models;
using Xunit;

namespace ElevatorApi.Tests
{
    public class ElevatorTests
    {
        [Fact]
        public void CheckMaxWeightAllowedReached_EmptyElevator_ReturnFalse()
        {
            // Arrange
            var myElevator = new Elevator(100);

            // Act
            var result = myElevator.CheckMaxWeightAllowedReached();

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void CheckMaxWeightAllowedReached_80MaxWeightWith80WeightEmployer_ReturnTrue()
        {
            // Arrange
            var myElevator = new Elevator(80);
            // employee 1
            var programmer = new Employee { Weight = 80 };

            // Act
            // adding employees to the elevator
            myElevator.InUser(programmer);
            var result = myElevator.CheckMaxWeightAllowedReached();

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CheckMaxWeightAllowedReached_100MaxWeightWithSeveralEmployees_ReturnTrue()
        {
            // Arrange
            var myElevator = new Elevator(100);
            // employee 1
            var director = new Employee { Weight = 75, IsExecutive = true };
            // employee 2
            var producer = new Employee { Weight = 85 };

            // Act
            // adding employees to the elevator
            myElevator.InUser(director);
            myElevator.InUser(producer);
            var result = myElevator.CheckMaxWeightAllowedReached();

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CheckMaxWeightAllowedReached_100MaxWeightWithSeveralEmployeesButSubtractingOne_ReturnFalse()
        {
            // Arrange
            var myElevator = new Elevator(100);
            // employee 1
            var director = new Employee { Weight = 75, IsExecutive = true };
            // employee 2
            var producer = new Employee { Weight = 85 };

            // Act
            // adding employees to the elevator
            myElevator.InUser(director);
            myElevator.InUser(producer);
            // removing one
            myElevator.OutUser(producer);
            var result = myElevator.CheckMaxWeightAllowedReached();

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void OutUser_SubtractingSeveralEmployeeWhoAreNotInTheElevator_CurrentWeightResult0()
        {
            // Arrange
            var myElevator = new Elevator(100);
            // employee 1
            var artist = new Employee { Weight = 75 };
            // employee 2
            var gameDesigner = new Employee { Weight = 85 };

            // Act
            // removing employees who aren't inside the elevator
            myElevator.OutUser(artist);
            myElevator.OutUser(gameDesigner);

            // Assert
            Assert.Equal(0, myElevator.CurrentWeight);
        }

        [Fact]
        public void GoToVipSection_EmployeeWithVipPass_ReturnTrue()
        {
            // Arrange
            var myElevator = new Elevator(100);
            // employee
            var ceo = new Employee { Weight = 90, IsExecutive = true };

            // Act
            // adding employee inside the elevator, and go to vip section
            myElevator.InUser(ceo);
            var result = myElevator.GoToVipSection(ceo);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void GoToVipSection_EmployeeWithoutVipPass_ReturnFalse()
        {
            // Arrange
            var myElevator = new Elevator(100);
            // employee
            var guard = new Employee { Weight = 90 };

            // Act
            // adding employee inside the elevator, and go to vip section
            myElevator.InUser(guard);
            var result = myElevator.GoToVipSection(guard);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void GoToVipSection_ThereAreNotEmployeesInTheElevator_ReturnFalse()
        {
            // Arrange
            var myElevator = new Elevator(100);

            // Act
            // go to vip section
            var result = myElevator.GoToVipSection(new Employee());

            // Assert
            Assert.False(result);
        }
    }
}
