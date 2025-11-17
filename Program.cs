using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Interfaces;
using Server.Services;
using Server.Type;
using Server.Query;
using Server.Schema;
using GraphQL;
using GraphQL.Server;
using GraphQL.Types;
using GraphiQl;
using Server.Mutation;
using GraphQLProject.Mutation;

var builder = WebApplication.CreateBuilder(args);

// Register repositories
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IMessageRepository, MessageRepository>();

// Register GraphQL types
builder.Services.AddTransient<UserType>();
builder.Services.AddTransient<UserInputType>();
builder.Services.AddTransient<MessageInputType>();
builder.Services.AddTransient<MessageType>();



// Register queries
builder.Services.AddTransient<UserQuery>();
builder.Services.AddTransient<MessageQuery>();
builder.Services.AddTransient<RootQuery>();

// register the mutations 
builder.Services.AddTransient<UserMutation>();
builder.Services.AddTransient<MessageMutation>();
builder.Services.AddTransient<RootMutation>();


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

// cors policy 
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularClient",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200") // only allow Angular app
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});
var app = builder.Build();

// using cors policy 
app.UseCors("AllowAngularClient");

// GraphQL endpoint
// app.UseGraphQL<ISchema>("/graphql");

// GraphiQL UI (browser IDE)
app.UseGraphiQl("/graphql"); // thi sis the api end point here 
 // UI at /ui/graphql, API at /graphql
app.UseGraphQL<ISchema>();

// Simple test endpoint

app.Run();
