using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EggTracker.Web.Models.Chicken
{
    public class ChickenModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Required]
        [Display(Name="Name")]
        [BsonElement("Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Breed")]
        [BsonElement("Breed")]
        public string Breed { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "DOB")]
        [BsonElement("Dob")]
        public DateTime Dob { get; set; }
    }
}
