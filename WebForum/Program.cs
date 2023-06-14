using WebForum.Repository.Contracts;
using WebForum.Repository;
using WebForum.Services;
using WebForum.Helpers.Mappers;
using WebForum.Data;
using Microsoft.EntityFrameworkCore;

namespace WebForum
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<ForumContext>(options =>
            {
                //string connectionString = @"Server=MILA-V15G2\SQLEXPRESS;Database=EFCtestDB;Trusted_Connection=True;Encrypt=False;";
                //string connectionString = @"Server=MILA-V15G2\SQLEXPRESS;Database=ForumDataBase;Trusted_Connection=True;Encrypt=False;";
                //string connectionString = @"Server=VILIMOV-PC;Database=ForumDataBase;Trusted_Connection=True;Encrypt=False;";
                string connectionString = @"Server=localhost;Database=ForumDataBase;Trusted_Connection=True;Encrypt=False;";
                options.UseSqlServer(connectionString);
                options.EnableSensitiveDataLogging();

            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Repository
            builder.Services.AddScoped<ICommentRepository, CommentRepository>();
            builder.Services.AddScoped<IPostRepository, PostRepository>();

            // Services
            builder.Services.AddScoped<ICommentsServices, CommentsServices>();
            builder.Services.AddScoped<IPostServices, PostServices>();

            //Helpers
            builder.Services.AddScoped<PostCreatUpdateMapper>();


            var app = builder.Build();

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