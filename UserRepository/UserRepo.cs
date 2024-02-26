﻿using Hostapiauthentication.Data;
using Hostapiauthentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hostapiauthentication.UserRepository
{
    public class UserRepo : IDisposable
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();
        public User ValidateUser(string username, string password)
        {
            return dbContext.Users.FirstOrDefault(user =>user.UserName.Equals(username, StringComparison.OrdinalIgnoreCase) && user.Password==password);
        }
        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}