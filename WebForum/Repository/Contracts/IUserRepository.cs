﻿using WebForum.Models;

namespace WebForum.Repository.Contracts
{
    public interface IUserRepository
    {
        User GetUserById(int id);
        IEnumerable<User> GetAllUsers();
        void AddUser(User user);
        User CreateUser(User newUser);
        User UpdateUser(User user);
        void DeleteUser(int id);
        User GetByEmail(string email);
    }
}