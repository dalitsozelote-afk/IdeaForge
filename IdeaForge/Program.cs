var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();
app.MapGet("/api/ai/status", async (IHttpClientFactory factory) =>
{
    var client = factory.CreateClient();

    try
    {
        var response = await client.GetAsync("http://127.0.0.1:8000/");

        var result = await response.Content.ReadAsStringAsync();

        return Results.Content(result, "application/json");
    }
    catch
    {
        return Results.Problem("Python AI service is not available.");
    }
});

app.Run();
