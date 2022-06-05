namespace TestBlazorWASM.Client.Pages
{
    public partial class Employees
    {
        [Inject] public HttpClient client { get; set; }
        [Inject] public NavigationManager navigationManager { get; set; }
        List<Employee>? employees;
        
        protected override async Task OnInitializedAsync() => employees = await GetEmployees();
        
        protected override async Task OnParametersSetAsync()
        {
            employees = await GetEmployees();
            StateHasChanged();
        }

        public async Task<List<Employee>?> GetEmployees()
        {
            return await client.GetFromJsonAsync<List<Employee>>("api/employees");
        }
        
        public void AddEmployee() => navigationManager.NavigateTo("AddEmployee");
        
        public async void Delete(int id)
        {
           await  client.DeleteAsync($"api/employees/{id}");
            employees = await GetEmployees();
            StateHasChanged();
        }
        public async void Update(int id)
        {
            navigationManager.NavigateTo($"EditEmployee/{id}");
            StateHasChanged();
        }
    }
}
