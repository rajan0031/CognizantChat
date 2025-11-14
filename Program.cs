using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.interfaces;
using Server.Services;
using Server.Type;
using Server.Query;
using Server.Schema;
using GraphQL;
using GraphQL.Server;
using GraphQL.Types;
using GraphiQl;

var builder = WebApplication.CreateBuilder(args);

// Register repositories
builder.Services.AddTransient<IUserRepository, UserRepository>();

// Register GraphQL types
builder.Services.AddTransient<UserType>();
builder.Services.AddTransient<UserInputType>();

// Register queries
builder.Services.AddTransient<UserQuery>();
builder.Services.AddTransient<RootQuery>();

// Register schema
builder.Services.AddTransient<ISchema, RootSchema>();

// Configure GraphQL.NET
builder.Services.AddGraphQL(b =>
{
    b.AddAutoSchema<ISchema>()   // auto-wire RootSchema
     .AddSystemTextJson();       // use System.Text.Json serializer
});

// Register EF Core DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// GraphQL endpoint
// app.UseGraphQL<ISchema>("/graphql");

// GraphiQL UI (browser IDE)
app.UseGraphiQl("/graphql"); // thi sis the api end point here 
 // UI at /ui/graphql, API at /graphql
app.UseGraphQL<ISchema>();

// Simple test endpoint

app.Run();
