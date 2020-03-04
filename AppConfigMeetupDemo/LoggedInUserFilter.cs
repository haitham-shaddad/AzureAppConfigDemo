using Microsoft.AspNetCore.Http;
using Microsoft.FeatureManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppConfigMeetupDemo
{
    [FilterAlias("LoggedInOnly")]
    public class LoggedInUserFilter : IFeatureFilter
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public LoggedInUserFilter(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }
        public Task<bool> EvaluateAsync(FeatureFilterEvaluationContext context)
        {
            return Task.FromResult(this.httpContextAccessor.HttpContext.User.Identity.IsAuthenticated);
        }
    }
}
