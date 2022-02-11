using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;
using System.Linq;
using UniClub.Application.Helpers;

namespace UniClub.HttpApi
{
    public class ConvertKebabParameterToPascalCaseRule : IRule
    {
        public void ApplyRule(RewriteContext context)
        {
            Dictionary<string, StringValues> newQueryCollection = context.HttpContext.Request.Query.ToDictionary(
                kv => kv.Key.FromKebabToPascalCase(),
                kv => kv.Value
            );

            context.HttpContext.Request.Query = new QueryCollection(newQueryCollection);
        }
    }
}
