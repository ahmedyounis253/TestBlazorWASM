namespace TestBlazorWASM.Client.Pages
{
    public partial class AddEmployee
    {
        [Parameter] public int id { get; set; } = 0;
        [Inject] public HttpClient client { get; set; }
        [Inject] public NavigationManager navigationManager { get; set; }
        public Employee _employee { get; set; } = new();
        protected override  async Task OnParametersSetAsync()
        {
            if (id != 0)
            {
                _employee =  await client.GetFromJsonAsync<Employee>($"api/Employees/{id}");

            }
            else
            {
                _employee = new();
            }
        }
        public async void Submit()
        {
            if (id == 0)
            {
                await client.PostAsJsonAsync<Employee>("api/employees", _employee);
                navigationManager.NavigateTo("employees");
            }
            else
            {
                await client.PutAsJsonAsync<Employee>($"api/employees/{id}", _employee);
                navigationManager.NavigateTo("employees");
            }
        }
    }
}
