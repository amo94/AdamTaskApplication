using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdamTaskApplication.Data.Models
{
    public enum JobTitles { TeamLeader , Manager , Employee }
    public enum Gender { Male , Female }
    public enum Nationalies { Turksih , Syrian }
    public enum Country { Turkey }
    public enum City {Istanbul , Ankara , Bursa , Siirt , Antakia , Trabzon , Adana }

    public class Employee : BaseEntity<long> 
    {   
        [Required]
        [DataType(DataType.Text)]
        [MaxLength(30 , ErrorMessage ="This Value should not be exced 30 char")]
        public string FirstName { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [MaxLength(30, ErrorMessage = "This Value should not be exced 30 char")]
        public string LastName { get; set; }
        [EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; }
        [EnumDataType(typeof(JobTitles))]
        public JobTitles ? JobTitle { get; set; }
        [EnumDataType(typeof(Country))]
        public Country Country { get; set; }
        public City CityID { get; set; }
      //  [DisplayFormat(DataFormatString = "{0:dd-MM-yy}",ApplyFormatInEditMode = true )]
        public DateTime BirthDate { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [MaxLength(100, ErrorMessage = "This Value should not be exced 100 char")]
        public string Address { get; set; }
        public Nationalies ? Nationalty1 { get; set; }
        public Nationalies ? Nationalty2 { get; set; }
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }
        public Files Files { get; set; }
        public ApplicationUser applicationUser { get; set; }
   }
}
