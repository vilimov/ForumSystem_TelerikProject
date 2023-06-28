using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebForum.Helpers.Authentication;
using WebForum.Models;

namespace WebForum.Tests.TestHelper
{
    internal class UsersHelper
    {

        public static User GetTestUser()
        {
            return new User
            {
                Id = 1,
                FirstName = "Julius",
                LastName = "Caesar",
                Username = "JuliusCaesar",
                Email = "JC@roman.im",
                Salt = "hgao85Qg9j0urKyL1stcjw==",
                Password = AuthManager.HashPassword("Cleopatra", "hgao85Qg9j0urKyL1stcjw=="),
                IsAdmin = true
            };
        }

        public static List<User> GetTestUsersList()
        {
            return new List<User>
            {
                new User
                {
                    Id = 1, 
                    FirstName = "Julius", 
                    LastName = "Caesar", 
                    Username = "JuliusCaesar", 
                    Email = "JC@roman.im", 
                    Salt = "hgao85Qg9j0urKyL1stcjw==", 
                    Password = AuthManager.HashPassword("Cleopatra", "hgao85Qg9j0urKyL1stcjw=="), 
                    IsAdmin = true
                },

                new User
                {
                    Id = 2, 
                    FirstName = "Marcus", 
                    LastName = "Aurelius", 
                    Username = "MarcusAurelius", 
                    Email = "MA@roman.im", 
                    Salt = "hgao85Qg9j0urKyL1stcjw==", 
                    Password = AuthManager.HashPassword("Antoninus", "hgao85Qg9j0urKyL1stcjw=="), 
                    IsAdmin = true
                },

                new User
                {
                    Id = 3, 
                    FirstName = "MarcusTullius", 
                    LastName = "Cicero", 
                    Username = "MarcusTulliusCicero", 
                    Email = "MTC@roman.im", 
                    Salt = "hgao85Qg9j0urKyL1stcjw==", 
                    Password = AuthManager.HashPassword("Tullius123", "hgao85Qg9j0urKyL1stcjw=="), 
                    IsAdmin = false
                }
            };
        }

    }
}
