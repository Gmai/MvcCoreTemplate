using CrossCutting.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrossCutting.Validation
{
    public class Email
    {
		public static RuleResult Validate(bool required,string email) {
			RuleResult result = new RuleResult();
			result.Valid = true;
			email = email.Trim();

			if (required) {
				if (string.IsNullOrEmpty(email))
				{
					result.Valid = false;
					result.Errors.Add("Email_is_mandatory");
				}
				else {
					//validate format
				}
			}

			return result;
		}
	}
}
