using ExampleGraphQL;
using ExampleGraphQL.DAO;
using ExampleGraphQL.Data;
using Microsoft.EntityFrameworkCore;
string AllowedOrigin = "allowedOrigin";
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BlogDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddGraphQLServer().AddQueryType<Query>().
    AddMutationType<Mutation>().AddProjections().
    AddSorting().AddFiltering().AddInMemorySubscriptions();
builder.Services.AddCors(option =>
{
    option.AddPolicy("allowedOrigin",
        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
        );
});
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}
app.UseHttpsRedirection();
app.UseRouting();
//app.UseCors(cors => cors
//.AllowAnyMethod()
//.AllowAnyHeader()
//.SetIsOriginAllowed(origin => true)
//.AllowCredentials()
//);
app.UseCors(AllowedOrigin);
app.UseWebSockets();
using (var scope=app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<BlogDbContext>();
    dbContext?.Database.EnsureCreated();
    DataSeeder.SeedData(dbContext!);
}

app.MapGraphQL("/graphgl");

app.Run();
