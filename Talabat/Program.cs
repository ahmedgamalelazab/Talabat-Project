using Contracts;
using Entities.Identity;
using Entities.Models;
using Imagekit.Sdk;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;
using NLog;
using Repository;
using Repository.Data.Identity;
using Talabat;
using Talabat.ActionFilters;
using Talabat.Extensions;


var builder = WebApplication.CreateBuilder(args);
LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

// Add services to the container.
builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureRepositoryBase();
builder.Services.ConfigureRepositoryBasket();
builder.Services.ConfigureTokenService();
builder.Services.ConfigureResponseCacheService();
builder.Services.ConfigureUnitOfWork();
builder.Services.ConfigureOrderService();
builder.Services.ConfigureStripeService();
builder.Services.ConfiguraSqlContext(builder.Configuration);
builder.Services.ConfigureIdentityDbContext(builder.Configuration);
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<ValidationFilterAttribute>();
builder.Services.AddAuthentication();
builder.Services.ConfigureRedisConnection(builder.Configuration);
builder.Services.ConfigureIdentity();
builder.Services.ConfigureJWT(builder.Configuration);
builder.Services.ConfigureImageKitService(builder.Configuration); // configuration the service with the credential store from the applicaiton settings
// Add Stripe Infrastructure
/*builder.Services.AddStripeInfrastructure(builder.Configuration);*/
builder.Services.Configure<FormOptions>(o =>
{
    o.ValueLengthLimit = int.MaxValue;
    o.MultipartBodyLengthLimit = int.MaxValue;
    o.MemoryBufferThreshold = int.MaxValue;
});
builder.Services.AddControllers(config =>
{
    config.InputFormatters.Insert(0, MyJPIF.GetJsonPatchInputFormatter());
}).AddApplicationPart(typeof(Talabat.Presentation.AssemblyReference).Assembly);


var app = builder.Build();
var logger = app.Services.GetRequiredService<ILoggerManager>();
app.ConfigureExeptionHandler(logger);


var scope = app.Services.CreateScope();
var service = scope.ServiceProvider;

try
{
    var context = service.GetRequiredService<RepositoryContext>();
    await context.Database.MigrateAsync();

    var Identitycontext = service.GetRequiredService<AppIdentityDbContext>();
    await Identitycontext.Database.MigrateAsync();

    await StoreContextSeed.SeedAsync(context, logger);

    // seeding for user manager
    var userManager = service.GetRequiredService<UserManager<AppUser>>();
    await AppIdentityDbContextSeed.SeedUsersAsync(userManager);
}
catch (Exception ex)
{

    throw ex;
}

if (app.Environment.IsProduction())
    app.UseHsts();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});

app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseAuthorization();
app.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
    {
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsync("{\"message\":\"hello world\"}");
    }
    else
    {
        await next();
    }
});

// app.Use(async (context, next) =>
// {
//     var imagekit = app.Services.GetRequiredService<ImagekitClient>();

//     if (context.Request.Path == "/upload")
//     {
//         FileCreateRequest request = new FileCreateRequest
//         {
//             file = "https://www.orimi.com/pdf-test.pdf",
//             fileName = "hamadaPdf.pdf",
//             tags = new List<string>{"hamada","pdf","khaled"}             
//         };

//         try
//         {
//             Result resp1 = imagekit.Upload(request);

//             // Serialize the Result object to JSON
//             string jsonResponse = JsonConvert.SerializeObject(new { message = "Image uploaded", result = resp1 });

//             // Set content type to JSON
//             context.Response.ContentType = "application/json";

//             // Write the JSON response
//             await context.Response.WriteAsync(jsonResponse);
//         }
//         catch (Exception ex)
//         {
//             // Handle exceptions and return an error JSON response
//             string errorResponse = JsonConvert.SerializeObject(new { error = ex.Message });
//             context.Response.ContentType = "application/json";
//             context.Response.StatusCode = 500; // Internal Server Error
//             await context.Response.WriteAsync(errorResponse);
//         }
//     }
//     else
//     {
//         await next();
//     }
// });

app.MapControllers();

app.Run();
