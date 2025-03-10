using Plugins.DataStore.InMemory;
using UseCases.CategoriesUseCases;
using UseCases.DataStorePluginInterfaces;
using UseCases.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<ICategoryRepository, CategoriesInMemoryRepository>();
builder.Services.AddTransient<IViewCategoriesUseCase, ViewCategoriesUseCase>();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
