using thirdAssignment.Aplication;
using thirdAssignment.Infrastructure;
using thirdAssignment.Presentation.Utils;
using thirdAssignment.Presentation.Utils.UserValidations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSession();

builder.Services.AddControllersWithViews();

builder.Services.AddInfraestructuraPersistenceLayer(builder.Configuration);

builder.Services.AddAplicationLayer();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddTransient<UserValidations, UserValidations>();

builder.Services.AddTransient<GenerateSelectList>();

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

app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Login}/{id?}");

app.Run();
