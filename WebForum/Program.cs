using WebForum.Repository.Contracts;
using WebForum.Repository;
using WebForum.Services;
using WebForum.Helpers.Mappers;
using WebForum.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using WebForum.Helpers.Authentication;

namespace WebForum
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Register AutoMapper
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<ForumContext>(options =>
            {


                string connectionString = @"Server=FREAKY\MSSQLSERVER2022;Database=ForumDataBase;Trusted_Connection=True;Encrypt=False;";
                //string connectionString = @"Server=MILA-V15G2\SQLEXPRESS;Database=ForumDataBase;Trusted_Connection=True;Encrypt=False;";
                //string connectionString = @"Server=VILIMOV-PC;Database=ForumDataBase;Trusted_Connection=True;Encrypt=False;";
                //string connectionString = @"Server=localhost;Database=ForumDataBase;Trusted_Connection=True;Encrypt=False;";

                options.UseSqlServer(connectionString);
                options.EnableSensitiveDataLogging();

            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Repository
            builder.Services.AddScoped<ICommentRepository, CommentRepository>();
            builder.Services.AddScoped<IPostRepository, PostRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ITagRepository, TagRepository>();

            // Services
            builder.Services.AddScoped<ICommentsServices, CommentsServices>();
            builder.Services.AddScoped<IPostServices, PostServices>();
            builder.Services.AddScoped<IUserServices, UserServices>();
            builder.Services.AddScoped<ITagService, TagService>();

            //Helpers
            builder.Services.AddScoped<AuthManager>();
            //builder.Services.AddScoped<PostCreatUpdateMapper>();
            //builder.Services.AddScoped<IMapper>();

            builder.Services.AddScoped<CommentMapper>();

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