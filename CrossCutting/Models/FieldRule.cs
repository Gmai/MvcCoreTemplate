using System;
using System.Collections.Generic;
using System.Text;

namespace CrossCutting.Models
{
	public class FieldRule
	{
		public delegate RuleResult Validate(object value);
	}
}
