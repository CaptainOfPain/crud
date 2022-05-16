using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using CRUD.Application.Items.Commands;
using CRUD.Application.Items.DTOs;
using CRUD.Application.Items.Queries;
using CRUD.Web.Middlewares;
using CRUD.Web.Requests;
using Microsoft.AspNetCore.Mvc;
using PlaygroundShared.Application.CQRS;
using PlaygroundShared.Domain.Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new RootModule(builder.Configuration)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapPost("/items/", async (ItemRequest request, ICommandQueryDispatcherDecorator dispatcher) =>
{
    var command = new CreateItemCommand(request.Name, request.Description, request.ExpirationDate);
    await dispatcher.DispatchAsync(command);

    return Results.Created($"/items/{command.Id.Id}", command.Id.Id);
});
app.MapPut("/items/{id}", async (Guid id, ItemRequest request, ICommandQueryDispatcherDecorator dispatcher) =>
{
    var command = new UpdateItemCommand(new AggregateId(id), request.Name, request.Description, request.ExpirationDate);
    await dispatcher.DispatchAsync(command);

    return Results.Created($"/items/{command.Id.Id}", command.Id.Id);
});
app.MapGet("/items/{id}", async (Guid id, ICommandQueryDispatcherDecorator dispatcher) =>
{
    var query = new GetItemQuery(new AggregateId(id));
    var result = await dispatcher.DispatchAsync<GetItemQuery, ItemDto>(query);

    return Results.Ok(result);
});
app.MapDelete("/items/{id}", async (Guid id, ICommandQueryDispatcherDecorator dispatcher) =>
{
    var command = new DeleteItemCommand(new AggregateId(id));
    await dispatcher.DispatchAsync(command);

    return Results.Accepted();
});

app.UseApiExceptionMiddleware();

app.Run();