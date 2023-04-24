using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageLogger
{
    public class Message
    {
        public string Content;
        public DateTime CreatedAt;
        public string formattedTime;

        public Message(string content)
        {
            Content = content;
            CreatedAt = DateTime.Now;
            formattedTime = CreatedAt.ToString("h:mm tt");
        }














    }
}
