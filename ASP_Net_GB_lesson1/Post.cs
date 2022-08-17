using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Net_GB_lesson1
{
    internal class Post
    {
        private int UserId;
        private int Id;
        private string Title;
        private string Body;

        public Post(int userId,int id,string title, string body )
        {
            UserId = userId;
            Id = id;
            Title = title;
            Body = body;
        }
    }
}
