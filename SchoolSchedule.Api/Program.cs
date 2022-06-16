using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using SchoolSchedule.Api.Filters;
using SchoolSchedule.Application;
using SchoolSchedule.Infrastructure;
using SchoolSchedule.Infrastructure.Data;
using System.Text.Json.Serialization.Metadata;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddRepository(builder.Configuration);


builder.Services
       .AddControllers(options => options.Filters.Add<ApplicationExceptionFilterAttribute>())
       .AddNewtonsoftJson(options =>
       {
           options.SerializerSettings.Converters.Add(new StringEnumConverter());
           //options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
           options.SerializerSettings.DateParseHandling = DateParseHandling.DateTimeOffset;
           options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
           options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
           options.SerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;
       });

builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.IncludeFields = true;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "SchoolSchedule.Api", Version = "v1" }));

var app = builder.Build();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;


var context = services.GetRequiredService<ApplicationDbContext>();

if (context.Database.IsSqlServer())
{
    context.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    //app.UseExceptionHandler("/Error");
    app.UseHsts();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "SchoolSchedule v1");
    });
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller}/{action=Index}/{id?}");
});

app.Run();
