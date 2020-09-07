namespace News.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class News_comments
    {
        [Key]
        [Display(Name = "Comment_id")]
        public int Comment_id { get; set; }

        [Display(Name ="Comment email")]
        [StringLength(500)]
        public string Comment_name { get; set; }

        [StringLength(500)]
        [Display(Name = "Comment email")]
        public string Comment_email { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Comment date")]
        public DateTime? Comment_date { get; set; }

        [Display(Name = "News ID")]
        public int? News_id { get; set; }

        public virtual News News { get; set; }
    }
}
