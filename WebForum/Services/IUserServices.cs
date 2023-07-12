﻿using WebForum.Models;
using WebForum.Models.Dtos;

namespace WebForum.Services
{
    public interface IUserServices
    {
        List<User> GetAllUsers();
        User GetUserById(int id);
        User GetByUsername(string username);
        User GetByEmail(string email);
        User Register(User newUser);
        User Login(string username, string password);
        User UpdateProfile(User userUpdate);
        void UpdatePassword(int userId, string plainTextPassword);
        void DeleteUser(int id);
        IList<Post> GetUserPosts(int userId);
        IList<Post> GetAllPosts();
    }
}
