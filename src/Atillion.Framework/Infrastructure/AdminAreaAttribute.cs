using Microsoft.AspNet.Mvc;
using System;

namespace Atillion.Framework.Infrastructure
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class AdminAreaAttribute : RouteConstraintAttribute
    {
        public AdminAreaAttribute(string areaName)
            : base("admin_area", areaName, blockNonAttributedActions: true)
        {
            if (string.IsNullOrEmpty(areaName))
            {
                throw new ArgumentException("Area name must not be empty", nameof(areaName));
            }
        }

    }
}
