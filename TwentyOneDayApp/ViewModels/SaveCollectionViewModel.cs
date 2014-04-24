using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TwentyOneDayApp.Models;

namespace TwentyOneDayApp.ViewModels
{
    public class SaveCollectionViewModel
    {
        public long Id { get; set; }
        public List<Container> Containers { get; set; }

    }
}