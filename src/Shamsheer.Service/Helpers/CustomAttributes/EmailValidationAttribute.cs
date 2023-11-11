using System;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class EmailValidationAttribute : ValidationAttribute
{
    private readonly Regex _emailRegex;

    public ShEmailAttribute()
    {
        _emailRegex = new Regex(@"^(?!.*--)([a-zA-Z0-9_.+-]+)@gmail\.com$", RegexOptions.Compiled);
    }

    public override bool IsValid(object value)
    {
        if (value is string email)
        {
            if (_emailRegex.IsMatch(email))
            {
                try
                {
                    var mail = new MailAddress(email);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        return false;
    }
}
