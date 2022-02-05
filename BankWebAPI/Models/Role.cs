using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Models
{
    public class Role
    {
        public Guid Id { get; set; }
        [Required]
        public string RoleName { get; set; }
    }
}
