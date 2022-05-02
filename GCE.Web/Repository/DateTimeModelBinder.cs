using System;
using System.Globalization;
using System.Web.Mvc;

public class DateTimeModelBinder : IModelBinder
{
    public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
    {
        ValueProviderResult valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

        ModelState modelState = new ModelState { Value = valueResult };

        object actualValue = null;

        try
        {
            actualValue = DateTime.Parse(valueResult.AttemptedValue, CultureInfo.CurrentCulture);
        }
        catch (FormatException e)
        {
            modelState.Errors.Add(e);
        }

        bindingContext.ModelState.Add(bindingContext.ModelName, modelState);

        return actualValue;
    }
}

public class NullableDateTimeModelBinder : IModelBinder
{
    public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
    {
        ValueProviderResult valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

        ModelState modelState = new ModelState { Value = valueResult };

        object actualValue = null;

        try
        {
            if (valueResult == null || string.IsNullOrEmpty(valueResult.AttemptedValue))
            {
                actualValue = null;
            }
            else
            {
                actualValue = DateTime.Parse(valueResult.AttemptedValue, CultureInfo.CurrentCulture);
            }
        }
        catch (FormatException e)
        {
            modelState.Errors.Add(e);
        }

        bindingContext.ModelState.Add(bindingContext.ModelName, modelState);

        return actualValue;
    }
}
