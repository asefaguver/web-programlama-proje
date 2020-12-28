using System;
using System.Collections.Generic;

#nullable disable

namespace CoreProje.Models
{
    public partial class Kategori
    {
        public Kategori()
        {
            Blogs = new HashSet<Blog>();
        }

        public int KategoriId { get; set; }
        public string KategoriAdi { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }
    }
}
