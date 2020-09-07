namespace News.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class News
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public News()
        {
            News_comments = new HashSet<News_comments>();
        }

        [Key]
        [Display(Name = "News ID")]
        public int News_id { get; set; }

        [StringLength(500)]
        [Display(Name = "News title")]
        public string News_title { get; set; }

        [Column(TypeName = "text")]
        [Display(Name = "News content")]
        public string News_content { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{yyyy-MM-dd}")]
        [Display(Name = "News date")]
        public DateTime? News_date { get; set; }

        [Display(Name = "Category ID")]
        public int? Cat_id { get; set; }

        
        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<News_comments> News_comments { get; set; }
    }
}
