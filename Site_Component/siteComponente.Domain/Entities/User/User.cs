using siteComponente.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace siteComponente.Domain.Entities.User
{
     public class User
     {
          [Key]
          [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
          public int Id { get; set; }
          [Required]
          public string Username { get; set; }
          [Required]
          public string Password { get; set; }
          [Required]
          public string Email { get; set; }

          [DataType(DataType.Date)]
          public DateTime LoginDateTime { get; set; }

          [DataType(DataType.Date)]
          public DateTime RegisterDateTime { get; set; }

          [Required]
          public URole AccessLevel { get; set; }
     }
}