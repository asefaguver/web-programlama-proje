using System;
using System.Collections.Generic;

#nullable disable

namespace CoreProje.Models
{
    public partial class Blog
    {
        public int BlogId { get; set; }
        public int? KategoriId { get; set; }
        public string Baslik { get; set; }
        public int? AdminId { get; set; }
        public string Icerik { get; set; }

        public virtual Admin Admin { get; set; }
        public virtual Kategori Kategori { get; set; }
    }
}
