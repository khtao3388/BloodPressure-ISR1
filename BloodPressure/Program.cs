using BloodPressure.Components;
using BloodPressure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FluentUI.AspNetCore.Components;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("BPReadingContext");
builder.Services.AddSqlServer<BPReadingContext>(connString);
builder.Services.AddScoped<IBPReadingRepository, BPReadingRepository>();
    
    //builder.Services.AddDbContextFactory<BPReadingContext>(options =>
    //options.UseSqlServer(builder.Configuration.GetConnectionString("BPReadingContext") ?? throw new InvalidOperationException("Connection string 'BPReadingContext' not found.")));

builder.Services.AddQuickGridEntityFrameworkAdapter();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddFluentUIComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseMigrationsEndPoint();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
