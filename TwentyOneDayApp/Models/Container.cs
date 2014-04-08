using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TwentyOneDayApp.Models
{
    public enum ContainerType
    {
        Green,
        Purple,
        Red,
        Yellow,
        Blue,
        Orange,
        Teaspoon
    }

    public class Container
    {
        public ContainerType ContainerType { get; set; }

        public bool Checked { get; set; }
        public string Description { get; set; }

    }
}