


namespace TestBlazorWASM.Shared.Entities
{
    public record Employee
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Name field is required")]
        public string Name { get; set; } = "None";

        [Required(ErrorMessage = "Role field is required")]
        public string Role { get; set; } = "Trainee";

        [Range(maximum: 100, minimum: 20)]
        public int Age { get; set; }

        public DateTime? Birthdate { get; set; }

        public string? Mobile { get; set; }

        public string? EmployeeID { get; set; } 
 
    }
}