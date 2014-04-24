using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Xml.Linq;
using Newtonsoft.Json;

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

        //[NotMapped]
        //public int Order
        //{
        //    get
        //    {
        //        switch (ContainerType)
        //        {
        //            case ContainerType.Green:
        //                return 1;
        //            case ContainerType.Purple:
        //                return 2;
        //            case ContainerType.Red:
        //                return 3;
        //            case ContainerType.Yellow:
        //                return 4;
        //            case ContainerType.Blue:
        //                return 5;
        //            case ContainerType.Orange:
        //                return 6;
        //            case ContainerType.Teaspoon:
        //                default:
        //                return 7;
        //        }
        //    }
        //}

    }

    public static class ContainerExtensions
    {
        public static XDocument ToXDocument(this IEnumerable<Container> containers)
        {
            var xDoc = XDocument.Parse("<root/>");
            xDoc.Root.Add(containers.Select(c => c.ToXElement()));
            return xDoc;
        }

        public static XElement ToXElement(this Container container)
        {
            var x = new XElement("Container",
                new XElement("Type") { Value = container.ContainerType.ToString() },
                new XElement("Checked") { Value = container.Checked.ToString() },
                new XElement("Description") { Value = container.Description ?? string.Empty }
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

        public static string ToJson(this IEnumerable<Container> containers)
        {
            return JsonConvert.SerializeObject(containers
                                                   .GroupBy(c => c.ContainerType)
                                                   .ToDictionary(c => c.Key.ToString(),
                                                                 c => c.Select(f => new
                                                                 {
                                                                     ContainerType = f.ContainerType.ToString(),
                                                                     f.Checked,
                                                                     f.Description
                                                                 })));
        }

        public static string JsonContainerTypes()
        {
            return
                JsonConvert.SerializeObject(new List<string>
                    {
                        ContainerType.Green.ToString(),
                        ContainerType.Purple.ToString(),
                        ContainerType.Red.ToString(),
                        ContainerType.Yellow.ToString(),
                        ContainerType.Blue.ToString(),
                        ContainerType.Orange.ToString(),
                        ContainerType.Teaspoon.ToString()
                    });
        }

    }
}