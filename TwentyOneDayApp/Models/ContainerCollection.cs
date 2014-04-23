using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Xml.XPath;
using Newtonsoft.Json;

namespace TwentyOneDayApp.Models
{
    [Table("Collection")]
    public class ContainerCollection
    {
        private XDocument _xDoc;
        private List<Container> _containers;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public DateTime Date { get; set; }

        [Column(TypeName = "xml")]
        public string ContainerData { get; set; }

        [NotMapped]
        public XDocument ContainerXml
        {
            get
            {
                if (_xDoc == null)
                {
                    try
                    {
                        if (string.IsNullOrWhiteSpace(ContainerData))
                        {
                            ContainerData = "<root />";
                        }
                        _xDoc = XDocument.Parse(ContainerData);
                    }
                    catch
                    {
                        throw;
                    }
                }
                return _xDoc;
            }
            set { _xDoc = value; }
        }

        [NotMapped]
        public List<Container> Containers 
        {
            get
            {
                if (_containers == null)
                {
                    _containers = ContainerXml.XPathSelectElements("/root/Container")
                        .Select(e => e.ToContainerObj())
                        .ToList();
                }
                return _containers;
            }
            set { _containers = value; }
        }

        public long UserId { get; set; }
        public virtual User User { get; set; }

        /// <summary>
        /// Call to update the underlying XML structure based on the current state of the list of containers.
        /// </summary>
        public void UpdateXml()
        {
            ContainerXml = Containers.ToXDocument();
            ContainerData = ContainerXml.ToString();
        }

        public ContainerCollection()
        {
        }

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

                    // teaspoons
                    new Container() { Checked = false, ContainerType = ContainerType.Teaspoon },
                    new Container() { Checked = false, ContainerType = ContainerType.Teaspoon },
                    new Container() { Checked = false, ContainerType = ContainerType.Teaspoon },
                    new Container() { Checked = false, ContainerType = ContainerType.Teaspoon },
                    new Container() { Checked = false, ContainerType = ContainerType.Teaspoon },
                    new Container() { Checked = false, ContainerType = ContainerType.Teaspoon },

                };
            return cc;
        }
    }
}