using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdamTaskApplication.Data.Models
{
    public class BaseEntity<T>
    {
        public BaseEntity()
        {
            CreationDate = DateTime.Now;
            LastModifiedDate = DateTime.Now;
            IsDeleted = false;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public T Id { get; set; }

        [ScaffoldColumn(false)]
        [Column(TypeName = "datetime2")]
        //[Display(ResourceType = typeof(System.Resources._BaseEntity), Name = "CreationDate")]
        public DateTime CreationDate { get; set; }

        [ScaffoldColumn(false)]
        //[Display(ResourceType = typeof(Resources._BaseEntity), Name = "CreatedBy")]
        public string CreatedBy { get; set; }

        [ScaffoldColumn(false)]
        [Column(TypeName = "datetime2")]
        //[Display(ResourceType = typeof(Resources._BaseEntity), Name = "LastModifiedDate")]
        public DateTime LastModifiedDate { get; set; }

        [ScaffoldColumn(false)]
        //[Display(ResourceType = typeof(Resources._BaseEntity), Name = "ModifiedBy")]
        public string ModifiedBy { get; set; }

        [ScaffoldColumn(false)]
        [Column(TypeName = "datetime2")]
        //[Display(ResourceType = typeof(Resources._BaseEntity), Name = "DeletionDate")]
        public DateTime DeletionDate { get; set; }

        [ScaffoldColumn(false)]
        //[Display(ResourceType = typeof(Resources._BaseEntity), Name = "DeletedBy")]
        public string DeletedBy { get; set; }

        [ScaffoldColumn(false)]
        //[Display(ResourceType = typeof(Resources._BaseEntity), Name = "IsDeleted")]
        public bool IsDeleted { get; set; }


    }
}
