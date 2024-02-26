using BookStoreApp.Data.Abstract;
using BookStoreApp.Data.Concrete.Contexts;
using BookStoreApp.Data.Concrete.Repositories;
using BookStoreApp.Services.Abstract;
using BookStoreApp.Services.Concrete;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
//context
builder.Services.AddDbContext<BookStoreAppContext>(options =>
options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection"))
);

//repositories
builder.Services.AddScoped<IGenreRepository,GenreRepository>();
builder.Services.AddScoped<IAuthorRepository,AuthorRepository>();
builder.Services.AddScoped<IBookRepository,BookRepository>();
builder.Services.AddScoped<IPublisherRepository,PublisherRepository>();

//services
builder.Services.AddScoped<IGenreService,GenreService>();
builder.Services.AddScoped<IAuthorService,AuthorService>();
builder.Services.AddScoped<IBookService,BookService>();
builder.Services.AddScoped<IPublisherService,PublisherService>();




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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
