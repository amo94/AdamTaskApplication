using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdamTaskApplication.Data.Models
{
    public enum AttachmentTypes { PDF , JPG , ZIP}
    public enum OwnerTypes { Empolyee}
    public class Files : BaseEntity<long>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public long EmployeeID { get; set; }
        public OwnerTypes OwnerType { get; set; }
        public AttachmentTypes AttachmentType { get; set; }
    }
}
