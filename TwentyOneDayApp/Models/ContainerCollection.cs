using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TwentyOneDayApp.Models
{
    public class ContainerCollection
    {
        public DateTime Date { get; set; }
        public List<Container> Containers { get; set; }

        public static ContainerCollection CreateDefault(DateTime? date = null)
        {
            var cc = new ContainerCollection();
            cc.Date = date ?? DateTime.UtcNow.Date;
            cc.Containers = new List<Container>
                {
                    // Green
                    new Container { Checked = false, ContainerType = ContainerType.Green },
                    new Container { Checked = false, ContainerType = ContainerType.Green },
                    new Container { Checked = false, ContainerType = ContainerType.Green },
                    new Container { Checked = false, ContainerType = ContainerType.Green },
                    new Container { Checked = false, ContainerType = ContainerType.Green },
                    new Container { Checked = false, ContainerType = ContainerType.Green },
                    // Purple
                    new Container { Checked = false, ContainerType = ContainerType.Purple },
                    new Container { Checked = false, ContainerType = ContainerType.Purple },
                    new Container { Checked = false, ContainerType = ContainerType.Purple },
                    new Container { Checked = false, ContainerType = ContainerType.Purple },

                    // Red
                    new Container { Checked = false, ContainerType = ContainerType.Red },
                    new Container { Checked = false, ContainerType = ContainerType.Red },
                    new Container { Checked = false, ContainerType = ContainerType.Red },
                    new Container { Checked = false, ContainerType = ContainerType.Red },
                    new Container { Checked = false, ContainerType = ContainerType.Red },
                    new Container { Checked = false, ContainerType = ContainerType.Red },

                    // Yellows
                    new Container { Checked = false, ContainerType = ContainerType.Yellow },
                    new Container { Checked = false, ContainerType = ContainerType.Yellow },
                    new Container { Checked = false, ContainerType = ContainerType.Yellow },
                    new Container { Checked = false, ContainerType = ContainerType.Yellow },
                    new Container { Checked = false, ContainerType = ContainerType.Yellow },
                    new Container { Checked = false, ContainerType = ContainerType.Yellow },

                    // blue
                    new Container { Checked = false, ContainerType = ContainerType.Blue },

                    // orange
                    new Container { Checked = false, ContainerType = ContainerType.Orange },

                };
            return cc;
        }
    }
}