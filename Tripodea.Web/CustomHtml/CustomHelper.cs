using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Tripodea.Web.CustomHtml
{
    public static class CustomHelper
    {
        public static IHtmlString CustomMenu(this HtmlHelper helper,
                                        string linkText,
                                        string actionName,
                                        string controllerName)

        {
            string currentAction = helper.ViewContext.RouteData.GetRequiredString("action");
            string currentController = helper.ViewContext.RouteData.GetRequiredString("controller");

            var menuLink = helper.ActionLink(linkText, actionName, controllerName);
            var result = String.Format("<li>{0}</li>", menuLink);

            if (actionName == currentAction && controllerName == currentController)
            {
                result = String.Format("<li class=\"active\">{0}</li>", menuLink);
            }
            
            return new HtmlString(result);
        }
    }
}