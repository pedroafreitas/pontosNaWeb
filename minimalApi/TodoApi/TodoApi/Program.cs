var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext(opt => opt.UseInMemoryDatabase("TodoList"));
