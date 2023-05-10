using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace siteComponente.Domain.Entities.Response
{
     public class CookieResponse
     {
          public HttpCookie Cookie { get; set; }
          public DateTime Data { get; set; }
     }
}