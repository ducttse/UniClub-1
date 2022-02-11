using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Globalization;
using UniClub.Application.Helpers;

namespace UniClub.HttpApi.Helper.KebabCase
{
    public class KebabCaseQueryValueProvider : QueryStringValueProvider, IValueProvider
    {
        public KebabCaseQueryValueProvider(
            BindingSource bindingSource,
            IQueryCollection values,
            CultureInfo culture)
            : base(bindingSource, values, culture)
        {
        }

        public override bool ContainsPrefix(string prefix)
        {
            return base.ContainsPrefix(prefix.FromPascalToKebabCase());
        }

        public override ValueProviderResult GetValue(string key)
        {
            return base.GetValue(key.FromPascalToKebabCase());
        }
    }
}
