using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TwentyOneDayApp.Models
{
    public class ContainerTypeModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            return ContainerType.Blue;
        }

        private string GetValue(ModelBindingContext bindingContext, string key)
        {
            var result = bindingContext.ValueProvider.GetValue(key);
            return (result == null) ? null : result.AttemptedValue;
        }
    }
}