using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SportsStore.Models;


var builder = WebApplication.CreateBuilder(args);

//The builder.Service property is used to set up objects, known as services, that can be used throughout the application
//and that are accessed through a feature called dependency injection.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<StoreDbContext>(opts => { opts.UseSqlServer(builder.Configuration["ConnectionStrings:SportsStoreConnection"]); });

builder.Services.AddScoped<IStoreRepository, EFStoreRepository>();

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

// Each middleware component is able to inspect requests, modify them, generate a response, or modify the responses that other
// components have produced. The request pipeline is the heart of ASP.NET Core.
// The UseStaticFiles method enables support for serving static content from the wwwroot folder
app.UseStaticFiles();
app.MapDefaultControllerRoute();
app.Run();
