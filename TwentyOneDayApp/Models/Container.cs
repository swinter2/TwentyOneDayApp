using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Xml.Linq;

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

    public static class ContainerExtensions
    {
        public static XDocument ToXDocument(this IEnumerable<Container> containers)
        {
            var x = new XDocument();
            x.Add(containers.Select(c => c.ToXElement()));
            return x;
        }

        public static XElement ToXElement(this Container container)
        {
            var x = new XElement("Container",
                new XElement("Type") { Value = container.ContainerType.ToString() },
                new XElement("Checked") { Value = container.Checked.ToString() },
                new XElement("Description") { Value = container.Description }
            );
            return x;
        }

        public static Container ToContainerObj(this XElement element)
        {
            if (element == null)
                return null;

            var container = new Container();
            var type = element.Descendants("Type").FirstOrDefault();
            if (type != null)
            {
                ContainerType _type;
                if (ContainerType.TryParse(type.Value, out _type))
                {
                    container.ContainerType = _type;
                }
            }

            var checkedElement = element.Descendants("Checked").FirstOrDefault();
            if (checkedElement != null)
            {
                bool _checked;
                if (bool.TryParse(checkedElement.Value, out _checked))
                {
                    container.Checked = _checked;
                }
            }

            var desc = element.Descendants("Description").FirstOrDefault();
            if (desc != null)
            {
                container.Description = desc.Value;
            }

            return container;
        }
    }
}