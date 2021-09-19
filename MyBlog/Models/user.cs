namespace MyBlog.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("user")]
    public partial class user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public user()
        {
            news = new HashSet<news>();
        }

        public int id { get; set; }

        [Required(ErrorMessage ="*")]
        [StringLength(50)]
        public string username { get; set; }

        [Required(ErrorMessage ="*")]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$" , ErrorMessage ="not valid !")]
        [StringLength(50)]
        
        public string email { get; set; }

        [Required(ErrorMessage ="*")]
        [StringLength(50)]
        public string password { get; set; }
        [NotMapped]
        [Display(Name = "confirm password")]
        [Compare("password" , ErrorMessage ="not matching")]
        public string confirm_password { set; get; }
        [Range(6,50)]
        public int? age { get; set; }

        public string address { get; set; }

        public string photo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<news> news { get; set; }
    }
}
