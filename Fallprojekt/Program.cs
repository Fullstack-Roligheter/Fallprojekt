using DAL;
using DAL.Repositories;
using DAL.Repositories.Interfaces;
using Service;
using Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IBudgetService, BudgetService>();
builder.Services.AddScoped<ISavingPlanService,SavingPlanService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IDebitService, DebitService>();

builder.Services.AddScoped<IBudgetRepo, BudgetRepo>();
builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
builder.Services.AddScoped<IDebitRepo, DebitRepo>();
builder.Services.AddScoped<ISavingPlanRepo, SavingPlanRepo>();
//builder.Services.AddScoped<IUserCategoryRepo, UserCategoryRepo>();
builder.Services.AddScoped<IUserRepo, UserRepo>();

builder.Services.AddScoped<ProjectContext>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("corsapp");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();