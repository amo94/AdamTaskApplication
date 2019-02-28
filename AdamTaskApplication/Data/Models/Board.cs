using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdamTaskApplication.Data.Models
{
    public class Board :BaseEntity<long>
    {
        
        public string Name { get; set; }
        public string BoardType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Projects Project { get; set; }

        ICollection<BoardSubscriber>boardSubscribers { get; set; }
    }
}
