namespace TestBlazorWASM.Client.Pages.Students;

public partial class Students
{
    [Inject] public HttpClient client { get; set; }
    [Inject] public NavigationManager navigationManager { get; set; }
    public string searchText { get; set; }

    List<Student>? students;

    protected override async Task OnInitializedAsync()  
    {
        students = await GetStudents(); 
        searchText="";  
    }
    
    protected override async Task OnParametersSetAsync()
    {
        students = await GetStudents();
        StateHasChanged();
    }

    public async Task<List<Student>?> GetStudents()
    {
        return await client.GetFromJsonAsync<List<Student>>("api/students");
    }
    
    public void AddStudent() => navigationManager.NavigateTo("AddStudent");
    
    public async void Delete(Guid? id)
    {
       await  client.DeleteAsync($"api/employees/{id.ToString()}");
        students = await GetStudents();
        StateHasChanged();
    }
    public void Update(Guid? id)
    {
        navigationManager.NavigateTo($"EditStudent/{id.ToString()}");
        StateHasChanged();
    }
    public async Task Search()
    {
        students = await client.GetFromJsonAsync<List<Student>>($"api/students/Search/{searchText}");
        StateHasChanged();
    }
}
