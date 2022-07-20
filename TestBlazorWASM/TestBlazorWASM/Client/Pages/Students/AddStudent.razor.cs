namespace TestBlazorWASM.Client.Pages.Students;

public partial class AddStudent
{
    [Parameter] public string id { get; set; } 
    [Inject] public HttpClient client { get; set; }
    [Inject] public NavigationManager navigationManager { get; set; }
    public Student _student { get; set; } = new();
    protected override  async Task OnParametersSetAsync()
    {
        if (!String.IsNullOrEmpty(id))
            _student = await client.GetFromJsonAsync<Student>($"api/students/{id}");
        else
            _student = new Student();
    }
    public async void Submit()
    {
        if (String.IsNullOrEmpty(id))
        {
            await client.PostAsJsonAsync<Student>("api/students", _student);
            navigationManager.NavigateTo("students");
        }
        else
        {
            await client.PutAsJsonAsync<Student>($"api/students", _student);
            navigationManager.NavigateTo("students");
        }
    }
}
