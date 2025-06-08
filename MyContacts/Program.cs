using MyContacts.Services;

var builder = WebApplication.CreateBuilder(args);

// Configure routing options (optional, but nice for clean URLs)
builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true;
    options.AppendTrailingSlash = true;
});

// Register MVC services
builder.Services.AddControllersWithViews();

// Register the in-memory ContactService
builder.Services.AddSingleton<ContactService>();

var app = builder.Build();

// Middleware configuration
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// MVC Route config
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}/{slug?}");

app.Run();
