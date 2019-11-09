using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Milestone_1.models
{
    public class UserData : IValidatableObject
    {
        private const int _yearOK = 2015;

        [Key]
        public int UserDataId { get; set; }

        public int UserForeignKey { get; set;}
        [ForeignKey("UserForeignKey")]
        public User User { get; set; }
        [Required]
        public string name{get;set;}
        [Required]
        public string surname { get; set; }
        [Required]
        public string gender { get; set; }
        [Required]
        public string country { get; set; }
        [Required]
        public string city { get; set; }
        [Required]
        public int birthDate { get; set; }

        public ICollection<Tweets> Tweets { get; set; }

        public ICollection<Followers> Followers { get; set; }

        public List<UserDataGroup> UserDataGroups { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (birthDate == _yearOK || birthDate > _yearOK)
            {
                yield return new ValidationResult(
                    $"Classic movies must have a release year earlier than {_yearOK}.",
                    new[] { "ReleaseDate" });
            }
        }
    }
}