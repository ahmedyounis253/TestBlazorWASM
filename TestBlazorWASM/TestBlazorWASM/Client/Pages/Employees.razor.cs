namespace TestBlazorWASM.Client.Pages
{
    public partial class Employees
    {
        [Inject] public HttpClient client { get; set; }
        [Inject] public NavigationManager navigationManager { get; set; }
        public string searchText { get; set; }
        List<Employee>? employees;

        protected override async Task OnInitializedAsync()  {
            employees = await GetEmployees(); 
            searchText="";  
    }
        
        protected override async Task OnParametersSetAsync()
        {
            employees = await GetEmployees();
            
            if (!employees.Any())
            {
                await LoadDefaultEmployeesAsync();
                employees = await GetEmployees();
            }

            StateHasChanged();
        }

        public async Task<List<Employee>?> GetEmployees()
        {
            return await client.GetFromJsonAsync<List<Employee>>("api/employees");
        }
        
        public async Task LoadDefaultEmployeesAsync()
        {
            FillEmployees fillEmployees = new FillEmployees();
            List<Employee> emps = fillEmployees.GetEmployees();
            foreach (Employee employee in emps) await client.PostAsJsonAsync("api/employees", employee);

        }

        public void AddEmployee() => navigationManager.NavigateTo("AddEmployee");
        
        public async void Delete(Guid? id)
        {
           await  client.DeleteAsync($"api/employees/{id.ToString()}");
            employees = await GetEmployees();
            StateHasChanged();
        }
        public void Update(Guid? id)
        {
            navigationManager.NavigateTo($"EditEmployee/{id.ToString()}");
            StateHasChanged();
        }
        public async Task Search()
        {
            employees = await client.GetFromJsonAsync<List<Employee>>($"api/employees/Search/{searchText}");
            StateHasChanged();
        }
    }
}
