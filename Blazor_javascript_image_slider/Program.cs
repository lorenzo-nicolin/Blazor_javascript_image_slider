using System.Runtime;
using Blazor_javascript_image_slider.Components;
using Blazor_javascript_image_slider.Components.Data;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

//var mySetting = builder.Configuration["ConnectionStrings"];

var connection = new Connection();
connection.connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// or
var defaultConn2 = builder.Configuration["ConnectionStrings:DefaultConnection"];



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
