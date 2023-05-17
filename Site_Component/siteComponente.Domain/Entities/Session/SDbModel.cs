using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace siteComponente.Domain.Entities
{
     public class SDbModel
     {
          [Key]
          [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
          public int SessionId { get; set; }

          [Required]
          [StringLength(30)]
          public string Username { get; set; }

          [Required]
          public string CookieString { get; set; }

          [Required]
          public DateTime ExpireTime { get; set; }
     }
}

