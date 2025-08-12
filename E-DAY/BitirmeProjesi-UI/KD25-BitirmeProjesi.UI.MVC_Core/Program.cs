var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Eklediðimiz Servisler
//builder.Services.AddHttpClient();
builder.Services.AddHttpClient("APIClient", client =>
{
    client.BaseAddress = new Uri("https://localhost:7071");
});

//CustomHttpClientHelper için
builder.Services.AddHttpContextAccessor();



// Add session services
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Session süresi
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});







var app = builder.Build();
















// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
// Add session middleware
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

// Area'larý etkinleþtirmek için
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseCors(x => x.AllowAnyHeader()
          .AllowAnyOrigin()
          .AllowAnyMethod()
          );

app.Run();
