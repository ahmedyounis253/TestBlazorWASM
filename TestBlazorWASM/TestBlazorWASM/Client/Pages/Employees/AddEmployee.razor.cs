namespace TestBlazorWASM.Client.Pages.Employees;

public partial class AddEmployee
{
    [Parameter] public string id { get; set; } 
    [Inject] public HttpClient client { get; set; }
    [Inject] public NavigationManager navigationManager { get; set; }
    public Employee _employee { get; set; } = new();
    protected override  async Task OnParametersSetAsync()
    {
        if (!String.IsNullOrEmpty(id))
            _employee = await client.GetFromJsonAsync<Employee>($"api/employees/{id}");

        else
            _employee= new Employee();    
    }
    public async void Submit()
    {
        if (String.IsNullOrEmpty(id))
        {
            await client.PostAsJsonAsync<Employee>("api/employees", _employee);
            navigationManager.NavigateTo("employees");
        }
        else
        {
            await client.PutAsJsonAsync<Employee>($"api/employees", _employee);
            navigationManager.NavigateTo("employees");
        }
    }
}
