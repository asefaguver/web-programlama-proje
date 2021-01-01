using System;
using System.Collections.Generic;

#nullable disable

namespace CoreProje.Models
{
    public partial class Blog
    {
        public Blog()
        {
            Yorums = new HashSet<Yorum>();
        }

        public int BlogId { get; set; }
        public int? KategoriId { get; set; }
        public string Baslik { get; set; }
        public int? AdminId { get; set; }
        public string Icerik { get; set; }
        public string Resim { get; set; }

        public virtual Admin Admin { get; set; }
        public virtual Kategori Kategori { get; set; }
        public virtual ICollection<Yorum> Yorums { get; set; }
    }
}
