using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Serialization;
using TwentyOneDayApp.Models;

namespace TwentyOneDayApp.ViewModels
{
    public class SaveCollectionViewModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var obj = new SaveCollectionViewModel();
            long _id;
            if (long.TryParse(GetValue(bindingContext, "Id"), out _id))
            {
                obj.Id = _id;
            }

            obj.Containers = new List<Container>();
            foreach (var key in HttpContext.Current.Request.Form.AllKeys.Where(k => k.StartsWith("Containers")))
            {
                
            }

            //obj.Containers = new List<Container>();
            //obj.Containers.Add(new Container() { Checked = true, ContainerType = ContainerType.Blue});
            return obj;
        }

        private string GetValue(ModelBindingContext bindingContext, string key)
        {
            var result = bindingContext.ValueProvider.GetValue(key);
            return (result == null) ? null : result.AttemptedValue;
        }
    }
}