namespace ApiDoble.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class Random
    {
        [Key]
        public string Name { get; set; }

        [DataType(DataType.DateTime)]
        [Required]
        public DateTime DateTime { get; set; }
        
        [Required]
        public Random NumRandom { get; set; }
    }

}
