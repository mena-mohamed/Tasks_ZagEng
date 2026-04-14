using System.ComponentModel.DataAnnotations.Schema;

namespace Task2_API.Models
{
        public class JobListing
        {
            public int Id { get; set; }
            public string? Title { get; set; }  
            public string? Company { get; set; }   
            public string? Location { get; set; }

            [Column(TypeName = "decimal(18,2)")]
            public decimal Salary { get; set; }                    
            public bool IsActive { get; set; }                     
            public DateTime PostedAt { get; set; }                 
        }
}

