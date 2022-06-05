


namespace TestBlazorWASM.Shared.Entities
{
    public record  Employee
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Name field is required")]
        public string Name { get; set; } = "None";
        [Required(ErrorMessage = "Role field is required")]
        public string Role { get; set; }="Trainee";
        private string? _employeeID { get; set; } = "None";
        [Range(maximum:100,minimum:20)]
        public int? Age { get; set; }
        public string? Mobile { get; set; }
        public string EmployeeID
        {
            get { return _employeeID; }
            set {

                _employeeID = (Role[0].ToString().ToUpper())+ Name[0].ToString().ToUpper() + Name![Name.Length - 1].ToString().ToUpper()+(Age).ToString(); 
            
            }
        }



    }
}