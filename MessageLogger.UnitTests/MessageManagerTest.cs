using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageLogger.UnitTests
{
    public class MessageManagerTest
    {
        [Fact]
        public void MessageManager_Constructor_CreatesNewObject()
        {
            //Arrange
            MessageManager messManage1 = new MessageManager();
            //Assert
            Assert.Equal(new List<User>(), messManage1.Users);
        }
        
        [Fact]
        public void MessageManager_AllMessages_ReturnsListOfAllUsersMessages()
        {
            //Arrange
            User user1 = new User("test1", "test111");
            Message test1 = new Message("test1Message");
            User user2 = new User("test2", "test222");
            Message test2 = new Message("test2Message");
            MessageManager messManage1 = new MessageManager();
            List<Message> allMessages = new List<Message>();
           
            //Act
            user1.UserMessages.Add(test1);
            user2.UserMessages.Add(test2);
            messManage1.Users.Add(user1);
            messManage1.Users.Add(user2);
            allMessages = messManage1.AllMessages();
            
            //Assert
            Assert.Equal(test1, allMessages[0]);
            Assert.Equal(test2, allMessages[1]);
        }
        [Fact]
        public void MessageManager_RecentMessages_ReturnsSubsetOrFullList()
        {
            //Arrange
            User user1 = new User("test1", "test111");
            Message test1 = new Message("test1Message");
            User user2 = new User("test2", "test222");
            Message test2 = new Message("test2Message");
            MessageManager messManage1 = new MessageManager();
            List<Message> allMessages = new List<Message>();
            List<Message> subsetMessages = new List<Message>();
            
            //Act
            user1.UserMessages.Add(test1);
            user2.UserMessages.Add(test2);
            messManage1.Users.Add(user1);
            messManage1.Users.Add(user2);
            allMessages = messManage1.RecentMessages(5);
            subsetMessages = messManage1.RecentMessages(1);

            //Assert
            Assert.Equal(test1, allMessages[0]);
            Assert.Equal(test2, allMessages[1]);
            Assert.Equal(test2, subsetMessages[0]);

        }
    }
}
