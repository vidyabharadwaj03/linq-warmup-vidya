using OutpatientsAnalytics.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IDataContext, InMemoryDataContext>();
builder.Services.AddScoped<ReportsService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var reportsService = scope.ServiceProvider.GetRequiredService<ReportsService>();

    Console.WriteLine("No-show rates by department:");
    foreach (var report in reportsService.GetNoShowRatesByDepartment())
    {
        Console.WriteLine($"  {report.DepartmentName}: {report.NoShowRate:P0} ({report.NoShowCount}/{report.TotalAppointments})");
    }

    Console.WriteLine("Top clinicians this month:");
    foreach (var report in reportsService.GetTopCliniciansThisMonth())
    {
        Console.WriteLine($"  {report.ClinicianName} ({report.Specialty}): {report.CompletedAppointments} completed");
    }

    Console.WriteLine("Average wait time by specialty:");
    foreach (var report in reportsService.GetAverageWaitTimesBySpecialty())
    {
        Console.WriteLine($"  {report.Specialty}: {report.AverageWaitTimeDays:F1} days");
    }
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
