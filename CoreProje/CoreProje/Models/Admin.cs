using System;
using System.Collections.Generic;

#nullable disable

namespace CoreProje.Models
{
    public partial class Admin
    {
        public Admin()
        {
            Blogs = new HashSet<Blog>();
            Yorums = new HashSet<Yorum>();
        }

        public int AdminId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Yetki { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }
        public virtual ICollection<Yorum> Yorums { get; set; }
    }
}
