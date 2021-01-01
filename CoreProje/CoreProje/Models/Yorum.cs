using System;
using System.Collections.Generic;

#nullable disable

namespace CoreProje.Models
{
    public partial class Yorum
    {
        public int YorumId { get; set; }
        public string Yicerik { get; set; }
        public DateTime? Tarih { get; set; }
        public int? AdminId { get; set; }
        public int? BlogId { get; set; }

        public virtual Admin Admin { get; set; }
        public virtual Blog Blog { get; set; }
    }
}
