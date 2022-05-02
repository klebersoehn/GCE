using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


public enum NotifyStatus
{
    Success,
    Error,
    Warning,
    Information
}

public class NotifyFilter : ActionFilterAttribute
{
    public override void OnActionExecuted(ActionExecutedContext filterContext)
    {
        if (filterContext.HttpContext.Request.IsAjaxRequest())
        {
            var tempData = filterContext.Controller.TempData;

            if (tempData.ContainsKey("notify-status") && tempData.ContainsKey("notify-message"))
            {
                var response = filterContext.HttpContext.Response;

                response.AddHeader("X-Notify-Status", tempData["notify-status"] as string);
                response.AddHeader("X-Notify-Message", tempData["notify-message"] as string);
            }
        }
    }
}

public static class NotifyExtensions
{
    public static void Notify(this Controller controller, NotifyStatus status, string message, bool timeout = true)
    {
        controller.TempData["notify-status"] = status.ToString();
        controller.TempData["notify-message"] = message;

        if (!timeout)
        {
            controller.TempData["notify-infinite"] = "infinite";
        }
    }
}
