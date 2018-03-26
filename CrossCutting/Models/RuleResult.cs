using System;
using System.Collections.Generic;
using System.Text;

namespace CrossCutting.Models
{
	public class RuleResult
	{
		public bool Valid { get; set; }
		public List<string> Errors { get; set; }

		public RuleResult()
		{
			Errors = new List<string>();
		}
	}
}
