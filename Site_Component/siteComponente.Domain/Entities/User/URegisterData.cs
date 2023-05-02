using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace siteComponente.Domain.Entities.User
{
     public class URegisterData
     {
          public string Username { get; set; }
          public string Password { get; set; }
          public string Email { get; set; }
          public DateTime RegisterDateTime { get; set; }
     }
}
