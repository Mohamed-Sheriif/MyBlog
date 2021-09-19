namespace MyBlog.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class news
    {
        public int ID { get; set; }

        [StringLength(150)]
        [Required(ErrorMessage ="*")]
        public string title { get; set; }
        [Required(ErrorMessage ="*")]
        [StringLength(250)]
        public string bref { get; set; }
        [Required(ErrorMessage ="*")]
        public string des { get; set; }

        public DateTime? date { get; set; }
        
        public string photo { get; set; }

        public int? cat_id { get; set; }

        public int? user_id { get; set; }

        public virtual catalog catalog { get; set; }

        public virtual user user { get; set; }
    }
}
