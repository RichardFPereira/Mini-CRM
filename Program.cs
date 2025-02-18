using MiniCRM.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MiniCRMContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoPadrao")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(p => 
    {
        p.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "Mini CRM API",
            Description = "API para gerenciar um mini CRM com clientes, contatos, endereços e situação de cadastro do cliente.",
            Contact = new OpenApiContact
            {
                Name = "Richard",
                Email = "richard.frei@hotmail.com"
            }
            
        });
    });

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
