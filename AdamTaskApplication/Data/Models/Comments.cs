using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdamTaskApplication.Data.Models
{
    public class Comments 
    {
        [Key]
        public long ID { get; set; }
        public string TableName { get; set; }
        [DataType(DataType.Text)]
        public string Comment { get; set; }
        public Files Files { get; set; }
        public ApplicationUser applicationUser { get; set; }
        public string UserID { get; set; }
    }
}
