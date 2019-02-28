using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdamTaskApplication.Data.Models
{
    public class DailyReport  
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        [DataType(DataType.Text)]
        public string Description { get; set; }
        public DateTime date { get; set; }
        public ApplicationUser applicationUser { get; set; }
        public Files File { get; set; }
    }
}
