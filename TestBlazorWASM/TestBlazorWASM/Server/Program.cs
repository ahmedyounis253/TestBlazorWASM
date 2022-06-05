var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options=>
                                                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
                                                    .EnableSensitiveDataLogging()
                                                    .EnableDetailedErrors()
                                                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                                                     );
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

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
