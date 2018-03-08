using System;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoftBreeze.BlueHrm.Web.Filters
{
    public class AuthorizeIpAddressAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var ipAddress = HttpContext.Current.Request.UserHostAddress;

            if (ipAddress != null && !IsIpAddressAllowed(ipAddress.Trim()))
            {
                context.Result = new HttpStatusCodeResult(403);
            }

            base.OnActionExecuting(context);
        }

        private static bool IsIpAddressAllowed(string ipAddress)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(ipAddress)) return false;
                var addresses = Convert.ToString(ConfigurationManager.AppSettings["AllowedIPAddresses"]).Split(',');
                return addresses.Any(a => a.Trim().Equals(ipAddress, StringComparison.InvariantCultureIgnoreCase));

            }
            catch
            {
                return true;
            }
        }
    }
}