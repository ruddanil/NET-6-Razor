var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddMvc();

builder.Services.AddMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(1800);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/Error");

app.UseHttpsRedirection(); // ��������������� �������� �� HTTPS

app.UseStaticFiles(); // ��������� ��������� ����������� ������ (WWW)

app.UseRouting(); // �������������

app.UseAuthorization();

app.UseSession();



app.MapRazorPages();

app.Run();
