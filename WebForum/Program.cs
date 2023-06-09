using WebForum.Repository.Contracts;
using WebForum.Repository;
using WebForum.Services;

namespace WebForum
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Repository
            builder.Services.AddSingleton<ICommentRepository, CommentRepository>();

            // Services
            builder.Services.AddScoped<ICommentsServices, CommentsServices>();

            var app = builder.Build();
            //Test
            IUserRepository userRepository = new UserRepository();
            var users = userRepository.GetAllUsers();

            foreach (var user in users)
            {
                Console.WriteLine($"ID: {user.Id}, FirstName: {user.FirstName}, LastName: {user.LastName}, Email: {user.Email}, Username: {user.Username}");
            }
            


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}