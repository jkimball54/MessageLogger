﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageLogger.UnitTests
{
    public class UserTest
    {
        [Fact]
        public void User_Constructor_CreatesUserObject()
        {
            User user1 = new User("jeremy", "jeremy123");

            var name = "jeremy";
            var username = "jeremy123";

            Assert.Equal(name, user1.Name);
            Assert.Equal(username, user1.UserName);
            Assert.Equal(new List<Message>(), user1.UserMessages);
        }
        
     


    }
}