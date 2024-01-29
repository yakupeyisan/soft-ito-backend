using System.Text.Json.Serialization;
using ExampleAPI.Business.Abstracts;
using ExampleAPI.Business.Concretes;
using ExampleAPI.Business.Validations;
using ExampleAPI.Contexts;
using ExampleAPI.Core.Abstracts;
using ExampleAPI.Core.Adapters;
using ExampleAPI.Repositories.Abstracts;
using ExampleAPI.Repositories.Concretes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ExampleDbContext>();
builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductTransactionRepository, ProductTransactionRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
builder.Services.AddScoped<IAccountTransactionRepository, AccountTransactionRepository>();
builder.Services.AddKeyedScoped<ICheckIdentityService, CheckIdentityAdapter>("TURKEY");
builder.Services.AddKeyedScoped<ICheckIdentityService, CheckIdentityAdapterUSA>("USA");
builder.Services.AddKeyedScoped<ICheckIdentityService, CheckIdentityAdapterENG>("ENG");
builder.Services.AddKeyedScoped<ICheckIdentityService, CheckIdentityAdapterFR>("FR");
builder.Services.AddScoped<UserValidations>();
builder.Services.AddScoped<IUserService,UserManager>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.Run();

