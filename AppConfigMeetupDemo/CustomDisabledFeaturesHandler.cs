using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.FeatureManagement.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppConfigMeetupDemo
{
    public class CustomDisabledFeaturesHandler : IDisabledFeaturesHandler
    {
        public Task HandleDisabledFeatures(IEnumerable<string> features, ActionExecutingContext context)
        {
            context.Result = new ViewResult() { ViewName = "FeatureDisabled" };
            return Task.CompletedTask;
        }
    }
}
