# Outpatients Analytics

ASP.NET Core MVC app answering three questions about outpatient appointment data using LINQ.

- No-show rate by department
- Top 3 clinicians this month
- Average wait time by specialty

Run with `dotnet run` from `OutpatientsAnalytics/`. Answers print to console on startup, and are also available as JSON at `/Reports/NoShowRates`, `/Reports/TopClinicians`, and `/Reports/WaitTimes`.
