using RequestBoard.BusinessLayer;
using RequestBoard.DataAccess;
using RequestBoard.Models.Interfaces.IRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddTransient<IRequestToRestoreRepository, RequestToRestoreRepository>();
builder.Services.AddTransient<IRequestTypeRepository, RequestTypeRepository>();
RequestBoard.IServiceCollectionExtensions.AddIdentityConfiguration(builder.Services, builder.Configuration);
builder.Services.AddTransient<IBusinessLayer, BusinessLayerClass>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
