using Microsoft.EntityFrameworkCore;
using SignalR_Cshar_DB.DB;
using SignalR_Cshar_DB.Hubs;
using SignalR_Cshar_DB.Service;
using SignalR_Cshar_DB.Service.Interface;

var builder = WebApplication.CreateBuilder(args);

//conexion con DB.
var connectionString = builder.Configuration.GetConnectionString("DevConnection");

////add service to the container.
builder.Services.AddDbContext<LpProductDB>(opt => opt.UseSqlServer(connectionString));

//builder.Services.Configure<ConnectionSetting>(builder.Configuration.GetSection("ConnectionStrings"));


// Add services to the container.
builder.Services.AddControllersWithViews();

//> signalR.
builder.Services.AddSignalR();

//> se ejecute en segundo plano.
//builder.Services.AddHostedService<ProductHostedService>().AddSingleton<IDatasServices, DatasServices>();
//builder.Services.AddHostedService<WorkerService>().AddSingleton<IProductService, ProductService>();

//> controllers
builder.Services.AddControllers();

//services e interfaces.
builder.Services.AddScoped<IProductService, ProductService>();

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

//creamos la dirección donde se va ajecutar el hub-> url.
app.MapHub<ProductsHub>("/productHub");

app.Run();
