using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebForum.Models.Dtos;
using WebForum.Models;
using WebForum.Helpers.Mappers;

namespace WebForum.Tests.Services.AutoMapper
{
    [TestClass]
    public class AutoMapperShould
    {
        [TestMethod]
        public void Map_PostToPostShowDto_Success()
        {
            // Arrange
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            var mapper = configuration.CreateMapper();

            var post = new Post
            {
                Id = 1,
                Title = "Test Post",
                Content = "This is a test post."
            };

            // Act
            var postShowDto = mapper.Map<PostShowDto>(post);

            // Assert
            Assert.IsNotNull(postShowDto);
            //Assert.AreEqual(post.Id, postShowDto.Id);
            Assert.AreEqual(post.Title, postShowDto.Title);
            Assert.AreEqual(post.Content, postShowDto.Content);
        }

    }
}
