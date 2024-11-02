using Candidate_DAO;
using Candidate_Repository;
using Candidate_Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<IHRAccountService, HRAccountService>();
builder.Services.AddScoped<IHRAccountRepo, HRAccountRepo>();
builder.Services.AddScoped<ICandidateProfileService, CandidateProfileService>();
builder.Services.AddScoped<ICandidateProfifeRepo, CandidateProfileRepo>();
builder.Services.AddScoped<IJobPostingService, JobPostingService>();
builder.Services.AddScoped<IJobPostingRepo, JobPostingRepo>();
builder.Services.AddDbContext<CandidateManagementContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnect")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    endpoints.MapGet("/", async context =>
    {
        context.Response.Redirect("/Login");
    });
});

app.UseAuthorization();

app.MapRazorPages();

app.Run();
