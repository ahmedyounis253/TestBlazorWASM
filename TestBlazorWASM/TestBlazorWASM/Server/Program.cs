using TestBlazorWASM.Server;


WebApplicationBuilder webApplicationbuilder = WebApplication.CreateBuilder(args);



string connectionString = webApplicationbuilder.Configuration.GetConnectionString("DefaultConnection");
webApplicationbuilder.Services.AddDbContext<ApplicationDbContext>(options=>
                                                    options.UseSqlServer(connectionString)
                                                           .EnableSensitiveDataLogging()
                                                           .EnableDetailedErrors()
                                                           .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                                                           );
webApplicationbuilder.Services.AddControllersWithViews();
webApplicationbuilder.Services.AddRazorPages();

webApplicationbuilder.Services.AddScoped<IStudentRepository, StudentRepository>();
webApplicationbuilder.Services.AddScoped<IStudentUnitOfWork, StudentUnitOfWork>();

webApplicationbuilder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
webApplicationbuilder.Services.AddScoped<IEmployeeUnitOfWork, EmployeeUnitOfWork>();

var app = webApplicationbuilder.Build();

if (app.Environment.IsDevelopment())
    app.UseWebAssemblyDebugging();
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
