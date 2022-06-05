namespace TestBlazorWASM.Shared
{
    public class Employee:BaseNameEntity
    {
        public string? Role { get; set; }

        public int Age { get; set; }

        public DateTime? Birthdate { get; set; }

        public string? Mobile { get; set; }

        public string? EmployeeID { get; set; } 
 
    }
}