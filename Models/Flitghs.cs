using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace POntheFly.Models
{
    public class Flitghs
    {
        [Required]
        public string Destiny { get; set; }

        [Required]
        public string Plane { get; set; }

        [Required]
        public int Sales { get; set; }

        [Required]
        public DateTime Departure { get; set; }

        [Required]
        public bool Status { get; set; }

    }
}
