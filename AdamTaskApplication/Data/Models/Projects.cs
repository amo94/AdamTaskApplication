using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdamTaskApplication.Data.Models
{
    public class Projects : BaseEntity<long> 
    {
        
        public string Name { get; set; }
        public Files Files { get; set; }

        public ICollection<Board> boards { get; set; }
    }
}
