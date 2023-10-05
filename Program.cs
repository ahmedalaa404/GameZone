

var builder = WebApplication.CreateBuilder(args);
#region ConnectionString
var ConnectionsString = builder.Configuration.GetConnectionString("GameZone") ??
    throw new InvalidOperationException("Not Have Connection String");
builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(ConnectionsString));
builder.Services.AddScoped<ICategorieyServices, CategorieyServices>();
builder.Services.AddScoped<IGameService, GameServices>();

#endregion








// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
