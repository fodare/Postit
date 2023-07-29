using Postit.Models;
using Postit.PostService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllers().AddJsonOptions(
    options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
builder.Services.Configure<PostDatabaseSettings>(
    builder.Configuration.GetSection("PostDatabase")
);

builder.Services.AddSingleton<IPostService, PostService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/View/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=View}/{action=Index}/{id?}");

app.Run();
