using PRJAPPTURNOS.Client.Pages;
using PRJAPPTURNOS.Components;
using PRJAPPTURNOS.Services;
using Repositorio;
using System.Data;
using System.Data.SqlClient;
using Radzen;
using Blazored.Modal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddSingleton<IDbConnection>((sp) => new SqlConnection(builder.Configuration.GetConnectionString("CONEXIONSQL")));
//se agrego al contenedor de dependencias el nuevo servicio
builder.Services.AddScoped<IGrabarClientes, GrabarClientes>();
builder.Services.AddScoped<IListasRepositorio, ListaRepositorio>();
//se agrego al contenedor de dependencias el nuevo servicio
builder.Services.AddScoped<IlistaServicio, listaServicio>();
builder.Services.AddScoped<IgrabarClienteServicio, grabarClienteServicio>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddBlazoredModal();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(PRJAPPTURNOS.Client._Imports).Assembly);

app.Run();
