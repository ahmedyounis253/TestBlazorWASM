namespace TestBlazorWASM.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        public List<Employee> _employees;
        public ApplicationDbContext context { get; set; }

        public EmployeesController(ApplicationDbContext applicationDbContext) =>context = applicationDbContext;
        
        // GET: api/<EmployeesController>
        [HttpGet]
        public async Task<List<Employee>?> Get()
        {
            var employees= context.Employees.ToList();
            if (employees.Count==0)
            {
                FillEmployees emps = new();
                foreach (Employee emp in emps.GetEmployees())
                {
                    context.Employees.Add(emp);
                    await context.SaveChangesAsync();
                }
            }
            employees = context.Employees.ToList();
            return await Task.FromResult(employees);
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public async Task<Employee> Get(int id)
        {
            Employee employee = await context.Employees.FirstAsync(employee => employee.id == id);
            return employee;
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public async Task<string> Post([FromBody] Employee employee)
        {

            context.Employees.Add(employee);
            await context.SaveChangesAsync();
            return "done";
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public async Task<int?> Put(int id, [FromBody] Employee employee)
        {
            var currentEmployee = context.Employees.First(emp => emp.id == id);
            try
            {
                context.Employees.Update(employee);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return await Task.FromResult(currentEmployee.Age);
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            Employee employee = context.Employees.FirstOrDefault(employee => employee.id == id);
            context.Employees.Remove(employee);
            await context.SaveChangesAsync();
        }
    }
}
