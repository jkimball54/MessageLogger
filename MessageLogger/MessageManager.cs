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
            List<Message> recentMessages = new List<Message>();
            int numOfMessages = AllMessages().Count();


            if (num > numOfMessages)
            {
                return AllMessages();
            }
            else
            {
                for (int i = 0; i < num; i++)
                {
                    recentMessages.Add(AllMessages()[numOfMessages - (i+1)]);
                }
            }
            return recentMessages;
        }


    }
}
