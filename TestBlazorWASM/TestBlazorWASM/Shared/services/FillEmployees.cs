namespace TestBlazorWASM.Shared
{
    public class FillEmployees
    {
        public static List<Employee> employees { get; set; } = new();
        
        public string GetPhone()
        {
            Random random = new Random();
            return random.Next(121212121, 999999999).ToString();
        }
        public FillEmployees()
        {

            employees = new List<Employee>()
            {
                new Employee
                {
                    Name="Wael Shehab",
                    Mobile="+2"+GetPhone(),
                    Role="Coach",
                    Age=42
                },             
                new Employee
                {
                    Name="Ahmed Hegazy",
                    Age=22,
                    Mobile="+2"+GetPhone(),
                    Role="Trainee"
                },               
                new Employee
                {
                    Name="Mahmound Kassem",
                    Age=22,
                    Mobile="+2"+GetPhone(),
                    Role="Trainee"
                },             
                new Employee
                {
                    Name="Amir Darwish",
                    Age=22,
                    Mobile="+2"+GetPhone(),
                    Role="Trainee"
                },             
                new Employee
                {
                    Name="Mohamed Hassan",
                    Age=22,
                    Mobile="+2"+GetPhone(),
                    Role="Trainee"
                },              
                new Employee
                {
                    Name="Ahmed Younis",
                    Age=22,
                    Mobile="+2"+GetPhone(),
                    Role="Trainee"
                },              
                new Employee
                {
                    Name="Menna Moataz",
                    Age=22,
                    Mobile="+2"+GetPhone(),
                    Role="Trainee"
                },
                new Employee
                {
                    Name="Rahaf",
                    Age=22,
                    Mobile="+2"+GetPhone(),
                    Role="Trainee"
                },
                                
                new Employee
                {
                    Name="Mariam Khaled",
                    Age=22,
                    Mobile="+2"+GetPhone(),
                    Role="Trainee"
                },
                                
                new Employee
                {
                    Name="Yasmen Maged",
                    Age=22,
                    Mobile="+2"+GetPhone(),
                    Role="Trainee"
                }
            };
        }

        public  List<Employee> GetEmployees()
        {
            return employees;
        }

    }
}
