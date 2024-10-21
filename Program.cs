// File: Program.cs
// Project: ProjectReviewFormApp

using ProjectReviewFormApp.Components;
using Microsoft.EntityFrameworkCore;
using ProjectReviewFormApp.Data;
using ProjectReviewFormApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add Razor Components and Interactive Server Components
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<FeedbackService>();


// Configure SQLite database context with the connection string from appsettings.json
builder.Services.AddDbContext<FeedbackContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Error handling for non-development environments
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

// Middleware configuration
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

// Database initialization logic
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<FeedbackContext>();
    
    try
    {
        dbContext.Database.EnsureCreated(); // Creates the database if it doesn't exist
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Database initialization failed: {ex.Message}");
    }
}

// Map Razor Components to the application
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Run the application
app.Run();
