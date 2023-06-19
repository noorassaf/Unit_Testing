using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Testing
{
    public class User
    {
        public int Id { get; set; }
        public string Naem { get; set; }
        public string Email { get; set; }
        public DateTime DateTime { get; set; }
      
    }
}
