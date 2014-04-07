using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MongoDB.Bson.Serialization.Attributes;

namespace TwentyOneDayApp.Models
{
    public class User
    {
        [BsonId]
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public List<ContainerCollection> ContainerCollections { get; set; }

    }
}