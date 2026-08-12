namespace ElevatorApi.Models
{
    public class Elevator
    {
        public int MaxWeightAllowed { get; }
        public int CurrentWeight { get; private set; }

        /// <summary>
        /// Contructor: Initializes maxweight and current weight
        /// </summary>
        public Elevator(int maxWeightAllowed)
        {
            MaxWeightAllowed = maxWeightAllowed;
            CurrentWeight = 0;
        }

        /// <summary>
        /// Add the weight of the user has entered to the elevator
        /// </summary>
        public void InUser(Employee user)
        {
            CurrentWeight += user.Weight;
        }

        /// <summary>
        /// Subtract the weight of the user from total current weight
        /// </summary>
        public void OutUser(Employee user)
        {
            CurrentWeight -= user.Weight;
            if (CurrentWeight < 0) CurrentWeight = 0;
        }

        /// <summary>
        /// Checks if the max weight allowed in the elevator is reached
        /// </summary>
        /// <returns>true if the elevator has reached the max weight allowed, false instead</returns>
        public bool CheckMaxWeightAllowedReached()
        {
            return CurrentWeight >= MaxWeightAllowed;
        }

        /// <summary>
        /// Check if the employee has permission to the vip section and there is
        /// someone inside the elevator (only for one employee)
        /// </summary>
        /// <param name="user">Employee who wants to go to vip section</param>
        /// <returns>true if can go to vip section, false instead</returns>
        public bool GoToVipSection(Employee user)
        {
            return CurrentWeight > 0 && user.IsExecutive;
        }
    }
}
