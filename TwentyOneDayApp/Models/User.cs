using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TwentyOneDayApp.Models
{
    public class User
    {
        public long Id { get; set; }
        [MaxLength(50)]
        public string Username { get; set; }
        [MaxLength(100)]
        public string Password { get; set; }
        [MaxLength(100)]
        public string FirstName { get; set; }
        [MaxLength(100)]
        public string LastName { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }

        public List<ContainerCollection> ContainerCollections { get; set; }

    }
}