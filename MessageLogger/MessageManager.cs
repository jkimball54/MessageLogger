using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageLogger
{
    public class MessageManager
    {
        public List<User> Users;

        public MessageManager()
        {
            Users = new List<User>();
        }

        public List<Message> AllMessages()
        {
            List<Message> allMessages = new List<Message>();
            foreach(User user in Users)
            {
                allMessages.AddRange(user.UserMessages);
            }
            return allMessages;
        }

        public List<Message> RecentMessages(int num)
        {
            //New List Containing Most recent messages first
            List<Message> recentMessages = AllMessages();
            recentMessages.Reverse();

            if (num > recentMessages.Count())
            {
                return recentMessages;
            }
            else
            {
                recentMessages = recentMessages.GetRange(0, num);
                return recentMessages;
            }
        }

        //List All users to console with their total number of messages
        public void PrintTotalMessages()
        {
            foreach (var existingUser in Users)
            {
                Console.WriteLine($"{existingUser.Name} wrote {existingUser.UserMessages.Count()} messages.");
            }
        }
        
        //Write to console all current users
        public void ListAllUsers()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Current Users");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            foreach (User user in Users)
            {
                Console.WriteLine($"-{user.UserName}");
            }
            Console.WriteLine();
        }
    }

}

