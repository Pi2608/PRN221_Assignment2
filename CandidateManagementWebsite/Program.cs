using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CandidateManagementWebsite.Data;
using Candidate_Repository;
using Candidate_Service;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddScoped<ICandidateProfifeRepo, CandidateProfileRepo>();
builder.Services.AddScoped<ICandidateProfileService, CandidateProfileService>();

builder.Services.AddDbContext<CandidateManagementWebsiteContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnect") ?? throw new InvalidOperationException("Connection string 'DBConnect' not found.")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
