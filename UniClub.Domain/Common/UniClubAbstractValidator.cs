using FluentValidation;
using System;
using System.Linq;

namespace UniClub.Domain.Common
{
    public class UniClubAbstractValidator<T> : AbstractValidator<T>
    {
        protected virtual bool BeAValidName(string name)
        {
            if (name.Contains("  "))
            {
                return false;
            }
            name = name.Replace(" ", "");
            name = name.Replace("_", "");
            name = name.Replace("-", "");
            name = name.Replace(".", "");
            name = name.Replace(",", "");

            return name.All(Char.IsLetterOrDigit);
        }

        protected virtual bool BeAFutureDate(DateTime date) => date == default(DateTime) ? false : (date <= DateTime.Today);

        protected virtual bool BeAPastDate(DateTime date) => date == default(DateTime) ? false : (date <= DateTime.Today);

        protected virtual bool BeAPresentDate(DateTime date) => date != default(DateTime) && (date >= DateTime.Today.AddDays(-1) && date <= DateTime.Today.AddDays(1));
        protected virtual bool BeAPresentYear(DateTime date) => date.Year == DateTime.Now.Year;
    }
}
